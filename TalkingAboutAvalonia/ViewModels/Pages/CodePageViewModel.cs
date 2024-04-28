using System;
using System.IO;
using System.Reflection;
using System.Text;
using Avalonia.Platform;

namespace TalkingAboutAvalonia.ViewModels.Pages;

public class CodePageViewModel : Page
{
  public CodePageViewModel(string title, string filename) : base(title)
  {
    var uri = new Uri($"avares://TalkingAboutAvalonia/Assets/{filename}");
    using var reader = new StreamReader(AssetLoader.Open(uri), Encoding.UTF8);
    Code = reader.ReadToEnd();
    
    // var resourceName = $"TalkingAboutAvalonia.Files.{filename}";
    // using var stream =
    //   Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName) 
    //   ?? throw new Exception($"Missing {resourceName}");
    // using var reader = new StreamReader(stream, Encoding.UTF8);
    // Code = reader.ReadToEnd();

    Extension = Path.GetExtension(filename).Replace("_", string.Empty);
  }

  public string Code { get; }
  public string Extension { get; }
}