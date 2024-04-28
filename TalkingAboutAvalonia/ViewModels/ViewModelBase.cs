using System.Reactive.Disposables;
using ReactiveUI;

namespace TalkingAboutAvalonia.ViewModels;

public class ViewModelBase : ReactiveObject
{
  protected CompositeDisposable Me { get; } = new();

}