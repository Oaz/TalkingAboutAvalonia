using Avalonia.Media;

namespace TalkingAboutAvalonia.ViewModels.Pages;

public class TextPageViewModel(
  string title = "",
  string text = "",
  FontStyle fontStyle = FontStyle.Normal,
  TextAlignment textAlignment = TextAlignment.Left)
  : Page(title)
{
  public string Text { get; } = text;
  public FontStyle FontStyle { get; } = fontStyle;
  public TextAlignment TextAlignment { get; } = textAlignment;
}