using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace TalkingAboutAvalonia.ViewModels;

public class SpeakerViewModel : ViewModelBase
{
  public SpeakerViewModel(Page[] pages)
  {
    Driver = new(pages);

    Observable
      .Interval(TimeSpan.FromSeconds(1))
      .Subscribe(_ => Time = DateTime.Now.ToString("HH:mm:ss"));
  }
  
  public DriverViewModel Driver { get; }
  
  public string Time
  {
    get => _time;
    set => this.RaiseAndSetIfChanged(ref _time, value);
  }

  private string _time = "";
}

internal class DesignSpeakerViewModel() : SpeakerViewModel(AllPages._);