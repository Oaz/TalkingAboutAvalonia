using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using Avalonia.ReactiveUI;
using TalkingAboutAvalonia;
using TalkingAboutAvalonia.Browser;

[assembly: SupportedOSPlatform("browser")]

internal partial class Program
{
  private static async Task Main(string[] args) => await BuildAvaloniaApp()
    .WithInterFont()
    .WithInterWindowsCommunication(new WindowExchange())
    .AfterSetup(_ => TheApp.IsWasm = true)
    .UseReactiveUI()
    .StartBrowserAppAsync("out");

  public static AppBuilder BuildAvaloniaApp()
    => AppBuilder.Configure<App>();
}