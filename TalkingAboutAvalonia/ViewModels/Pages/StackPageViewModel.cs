using Avalonia.Collections;

namespace TalkingAboutAvalonia.ViewModels.Pages;

public class StackPageViewModel : Page
{
  public AvaloniaList<Page> Items { get; }

  public StackPageViewModel(string title, int margin, params Page[] items) : base(title)
  {
    AllMargins = margin;
    Items = new AvaloniaList<Page>(items);
  }
}

