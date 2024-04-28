using System;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace TalkingAboutAvalonia.ViewModels.Pages;

public class ImagePageViewModel : Page
{
  public ImagePageViewModel(string title, string filename) : base(title)
  {
    var uri = new Uri($"avares://TalkingAboutAvalonia/Assets/{filename}");
    Image = new Bitmap(AssetLoader.Open(uri));
  }

  public IImage Image { get; }
}