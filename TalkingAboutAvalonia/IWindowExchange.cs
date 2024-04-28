using System;
using TalkingAboutAvalonia.Messages;

namespace TalkingAboutAvalonia;

public interface IWindowExchange
{
  void OpenSpeakerPad(Action onOpenComplete);
  void SendMessage(IMessage message);
}