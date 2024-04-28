using System;
using TalkingAboutAvalonia.Messages;

namespace TalkingAboutAvalonia.Browser;

public class WindowExchange : IWindowExchange
{
  public void OpenSpeakerPad(Action onOpenComplete)
  {
    Interop.OpenLinkedWindowCallback = _ => onOpenComplete();
    Interop.OpenLinkedWindow("?speaker");
  }

  public void SendMessage(IMessage message)
  {
    TheApp.ReceiveMessage(message);
    Interop.Send(_encodeDecode.ToJson(message));
  }

  public void ReceiveMessage(string json)
  {
    TheApp.ReceiveMessage(_encodeDecode.FromJson(json));
  }

  private readonly EncoderDecoder _encodeDecode = new(
    typeof(SetPageMessage),
    typeof(SwitchThemeMessage),
    typeof(TimeLineToggleMessage)
  );
}