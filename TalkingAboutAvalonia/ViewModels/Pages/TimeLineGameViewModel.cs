using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia;
using ReactiveUI;
using TalkingAboutAvalonia.Messages;

namespace TalkingAboutAvalonia.ViewModels.Pages;

public class TimeLineGameViewModel : Page
{
  public TimeLineGameViewModel(params (string Text, int X, int Row)[] items)
    : base("")
  {
    var centerY = 100;
    var tlItems = items
      .Select(item => new TimeLineItem(item.Text, item.X, item.Row, centerY))
      .ToArray();
    Items = tlItems.Cast<TimeLinePart>().Prepend(new TimeLineAxis(centerY, Width));
    Details = new TimeLineGameSpeakerViewModel(tlItems.Select(x => x.Text));
    
    TheApp.Messages.OfType<TimeLineToggleMessage>()
      .Subscribe(m => tlItems[m.Index].Shown = m.IsVisible)
      .DisposeWith(Me);
  }

  public IEnumerable<TimeLinePart> Items { get; }
  public int Width => 700;
  public int Height => 210;
}

public abstract class TimeLinePart : ViewModelBase
{
  public abstract Point Origin { get; }
}

public class TimeLineItem(string text, int x, int row, int yAxis) : TimeLinePart
{
  private const int PivotRow = 2;
  private const int Spacing = 50;
  private const int Gap = 23;

  public string Text { get; } = text;
  public bool IsAbove => row < PivotRow;
  public bool IsBelow => !IsAbove;
  private int RowDistanceToAxis => IsAbove ? PivotRow - 1 - row : row - PivotRow;
  public int LineSize => RowDistanceToAxis * Spacing + Gap;
  public override Point Origin => IsAbove ? new Point(x, row * Spacing) : new Point(x, yAxis);
  
  public bool Shown
  {
    get => _shown;
    set => this.RaiseAndSetIfChanged(ref _shown, value);
  }

  private bool _shown = false;

}

public class TimeLineAxis(int centerY, int width) : TimeLinePart
{
  public int Width { get; } = width;
  public override Point Origin => new Point(0, centerY);
}

internal class DesignTimeLineGameViewModel() : TimeLineGameViewModel(AllPages.NetUi);