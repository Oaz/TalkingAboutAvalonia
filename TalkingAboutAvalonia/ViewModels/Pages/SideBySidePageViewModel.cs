namespace TalkingAboutAvalonia.ViewModels.Pages;

public class SideBySidePageViewModel(Page left, Page right) : Page(left.Title)
{
  public Page Left { get; } = left;
  public Page Right { get; } = right;
}

public class DesignSideBySidePageViewModel() : SideBySidePageViewModel(
  new CodePageViewModel("Toujours et encore XAML", "example.xaml_"),
  new ImagePageViewModel("Un exemple", "example.png"));