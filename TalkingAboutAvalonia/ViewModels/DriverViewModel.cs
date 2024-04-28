using System;
using System.Reactive.Disposables;
using ReactiveUI;

using TalkingAboutAvalonia.Messages;

namespace TalkingAboutAvalonia.ViewModels;

public class DriverViewModel : ViewModelBase
{
  public DriverViewModel(Page[] pages)
  {
    _maxIndex = pages.Length - 1;
    UpdatePages();
    TheApp.Messages.Subscribe(m =>
    {
      switch (m)
      {
        case SetPageMessage setPage:
          Index = setPage.Index;
          UpdatePages();
          break;
        case SwitchThemeMessage t:
          TheApp.SetThemeVariant(t.Variant);
          break;
      }
    }).DisposeWith(Me);

    void UpdatePages()
    {
      CurrentPage = pages[Index];
      if (Index < pages.Length - 1)
        NextPage = pages[Index+1];
    }
  }
  
  public Page CurrentPage
  {
    get => _currentPage;
    set => this.RaiseAndSetIfChanged(ref _currentPage, value);
  }

  private Page _currentPage = null!;
  
  public Page NextPage
  {
    get => _nextPage;
    set => this.RaiseAndSetIfChanged(ref _nextPage, value);
  }

  private Page _nextPage = null!;
  
  public int Index
  {
    get => _index;
    set => this.RaiseAndSetIfChanged(ref _index, value);
  }

  private int _index = 0;

  public void MoveBackward()
  {
    if (Index > 0)
      Index--;
    TheApp.SendMessage(new SetPageMessage(Index));
  }

  public void MoveForward()
  {
    if (Index < _maxIndex)
      Index++;
    TheApp.SendMessage(new SetPageMessage(Index));
  }

  private readonly int _maxIndex;

  public void SwitchTheme() => TheApp.SendMessage(new SwitchThemeMessage());

}