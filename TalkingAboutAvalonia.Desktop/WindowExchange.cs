using System;
using TalkingAboutAvalonia.Messages;
using TalkingAboutAvalonia.ViewModels;
using TalkingAboutAvalonia.Views;

namespace TalkingAboutAvalonia.Desktop;

public class WindowExchange : IWindowExchange
{
  private MainWindow? _pad;

  public void OpenSpeakerPad(Action onOpenComplete)
  {
    _pad ??= new MainWindow()
    {
      DataContext = new MainViewModel(false)
    };
    _pad.Closed += (_, _) => _pad = null;
    _pad.Show();
    onOpenComplete();
  }

  public void SendMessage(IMessage message)
  {
    TheApp.ReceiveMessage(message);
  }
  
  
}