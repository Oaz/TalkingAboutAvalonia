namespace TalkingAboutAvalonia.ViewModels;

public class SpeakerDetailsViewModel(string notes) : ViewModelBase
{
  public string Notes { get; } = notes;
}