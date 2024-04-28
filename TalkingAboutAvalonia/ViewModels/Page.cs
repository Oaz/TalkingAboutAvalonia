using Avalonia;

namespace TalkingAboutAvalonia.ViewModels;

public class Page(string title) : ViewModelBase
{
  public SpeakerDetailsViewModel Details { get; protected set; } = new ("--------");

  public string Title { get; } = title;

  public double? AllMargins { get; init; } = null;
  public double HMargin { get; init; } = 0;
  public double VMargin { get; init; } = 0;
  public Thickness Margins =>
    AllMargins.HasValue ? new Thickness(AllMargins.Value) : new Thickness(HMargin, VMargin);

  public Page Notes(string notes)
  {
    Details = new SpeakerDetailsViewModel(notes);
    return this;
  }
}