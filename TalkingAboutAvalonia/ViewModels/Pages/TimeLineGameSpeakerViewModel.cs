using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using DynamicData.Binding;
using ReactiveUI;
using TalkingAboutAvalonia.Messages;

namespace TalkingAboutAvalonia.ViewModels.Pages;

public class TimeLineGameSpeakerViewModel : SpeakerDetailsViewModel
{
  public List<TimeLineGameItemVisibility> Items { get; }

  public TimeLineGameSpeakerViewModel(IEnumerable<string> items) : base("")
  {
    Items = new List<TimeLineGameItemVisibility>(
      items.Select((x, i) => new TimeLineGameItemVisibility(i, x))
    );
  }
}

public class TimeLineGameItemVisibility : ViewModelBase
{
  public TimeLineGameItemVisibility(int index, string text)
  {
    Text = text;
    this
      .WhenPropertyChanged(x => x.IsVisible)
      .Skip(1)
      .Subscribe(p =>
      {
        TheApp.SendMessage(new TimeLineToggleMessage(index, p.Value));
      });
  }

  public string Text { get; }

  public bool IsVisible
  {
    get => _isVisible;
    set => this.RaiseAndSetIfChanged(ref _isVisible, value);
  }

  private bool _isVisible = false;
}

internal class DesignTimeLineGameSpeakerViewModel()
  : TimeLineGameSpeakerViewModel(
    ((TimeLineGameSpeakerViewModel)new DesignTimeLineGameViewModel().Details).Items.Select(x => x.Text)
  );