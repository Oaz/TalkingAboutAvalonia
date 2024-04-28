using System;
using System.Linq;
using System.Reactive.Subjects;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using TalkingAboutAvalonia.Messages;
using TalkingAboutAvalonia.ViewModels;
using TalkingAboutAvalonia.Views;

namespace TalkingAboutAvalonia;

public partial class App : Application
{
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
  }

  public override void OnFrameworkInitializationCompleted()
  {
    DataContext = new AppContext();
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      desktop.MainWindow = new MainWindow
      {
        DataContext = new MainViewModel(TheApp.IsPublic),
        SystemDecorations = SystemDecorations.Full
      };
    }
    else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
    {
      singleViewPlatform.MainView = new MainView
      {
        DataContext = new MainViewModel(TheApp.IsPublic)
      };
    }

    base.OnFrameworkInitializationCompleted();
  }
}

public class AppContext : ViewModelBase
{
  public AppContext()
  {
    ThemeVariant = "Light";
  }
  
  public string ThemeVariant
  {
    get => _themeVariant;
    set => this.RaiseAndSetIfChanged(ref _themeVariant, value);
  }

  private string _themeVariant = null!;
}

public static class TheApp
{
  public static AppBuilder WithInterWindowsCommunication(this AppBuilder builder, IWindowExchange windowExchange) =>
    builder.AfterSetup(b => WindowExchange = windowExchange);

  public static IWindowExchange WindowExchange { get; private set; } = null!;
  public static bool IsPublic => !Environment.GetCommandLineArgs().Contains("?speaker");
  public static void OpenSpeakerPad(Action onOpenComplete) => WindowExchange.OpenSpeakerPad(onOpenComplete);

  public static IObservable<IMessage> Messages => MessagesFlow;
  private static readonly Subject<IMessage> MessagesFlow = new();
  public static void ReceiveMessage(IMessage message) => MessagesFlow.OnNext(message);
  public static void SendMessage(IMessage message) => WindowExchange.SendMessage(message);

  public static void SetThemeVariant(string variant)
  {
    var appContext = (AppContext)Application.Current!.DataContext!;
    appContext.ThemeVariant = variant;
  }
  
  public static bool IsWasm { get; set; }
}