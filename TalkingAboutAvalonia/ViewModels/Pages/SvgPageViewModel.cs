namespace TalkingAboutAvalonia.ViewModels.Pages;

public class SvgPageViewModel : Page
{
  public SvgPageViewModel(string title, string filename) : base(title)
  {
    Path = $"/Assets/{filename}";
  }

  public string Path { get; }
}