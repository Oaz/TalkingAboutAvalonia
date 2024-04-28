using TalkingAboutAvalonia.ViewModels.Pages;

namespace TalkingAboutAvalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
  public MainViewModel(bool isPublic = true)
  {
    if (isPublic)
      SelectedContent = new PublicViewModel(AllPages._);
    else
      SelectedContent = new SpeakerViewModel(AllPages._);
  }
  
  public ViewModelBase SelectedContent { get; }

}