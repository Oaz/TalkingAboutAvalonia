using TalkingAboutAvalonia.Messages;

namespace TalkingAboutAvalonia.ViewModels;

public class PublicViewModel : ViewModelBase
{
  public PublicViewModel(Page[] pages)
  {
    Driver = new(pages);
  }
  
  public DriverViewModel Driver { get; }

  public void OpenSpeakerPad()
  {
    TheApp.OpenSpeakerPad(() => TheApp.SendMessage(new SetPageMessage(Driver.Index)));
  }
}

public class DesignPublicViewModel() : PublicViewModel(AllPages._);