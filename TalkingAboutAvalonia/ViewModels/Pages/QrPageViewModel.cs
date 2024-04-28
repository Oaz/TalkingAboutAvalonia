using Avalonia.Media;

namespace TalkingAboutAvalonia.ViewModels.Pages;

public class QrPageViewModel(string text, IImmutableSolidColorBrush color) : Page(text)
{
  public string Text { get; } = text;
  public IImmutableSolidColorBrush Color { get; } = color;
}

public class DesignQrPageViewModel() : QrPageViewModel("Hello, World!", Brushes.Blue)
{
  
}