namespace TalkingAboutAvalonia.ViewModels.Pages;

public class TitlePageViewModel(string title) : Page("")
{
  public string Text { get; } = title;
}

internal class DesignTitlePageViewModel() : TitlePageViewModel("Ceci est un titre");