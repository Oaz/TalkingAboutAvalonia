namespace TalkingAboutAvalonia.Messages;

public record TimeLineToggleMessage(int Index, bool IsVisible) : IMessage;