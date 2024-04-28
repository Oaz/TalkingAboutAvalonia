using Avalonia;

namespace TalkingAboutAvalonia.Messages;

public record SwitchThemeMessage : IMessage
{
  public SwitchThemeMessage()
  {
    var appContext = (AppContext)Application.Current!.DataContext!;
    Variant = appContext.ThemeVariant == "Dark" ? "Light" : "Dark";
  }
  
  public string Variant { get; set; }
}