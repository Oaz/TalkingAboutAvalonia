using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaEdit;
using AvaloniaEdit.TextMate;
using TalkingAboutAvalonia.ViewModels.Pages;
using TextMateSharp.Grammars;

namespace TalkingAboutAvalonia.Views.Pages;

public partial class CodePageView : UserControl
{
  public CodePageView()
  {
    InitializeComponent();
    
    var textEditor = this.FindControl<TextEditor>("Editor")!;
    var colorSyntax = TheApp.IsWasm ? (IColorSyntax) new NoColorSyntax() : new ColorSyntax(textEditor);
    DataContextChanged += (s, e) =>
    {
      if (DataContext == null)
        return;
      var viewModel = (CodePageViewModel)DataContext!;
      textEditor.Text = viewModel.Code;
      colorSyntax.SetGrammar(viewModel.Extension);
    };
    ActualThemeVariantChanged += (s, e) =>
    {
      var variant = (string?)ActualThemeVariant?.Key;
      if(variant != null)
        colorSyntax.SetTheme(variant);
    };
  }

  interface IColorSyntax
  {
    void SetGrammar(string extension);
    void SetTheme(string variant);
  }

  class ColorSyntax : IColorSyntax
  {
    private readonly RegistryOptions _registryOptions;
    private readonly TextMate.Installation _textMateInstallation;

    public ColorSyntax(TextEditor textEditor)
    {
      _registryOptions = new RegistryOptions(ThemeName.Abbys);
      _textMateInstallation = textEditor.InstallTextMate(_registryOptions);
    }

    public void SetGrammar(string extension)
    {
      _textMateInstallation.SetGrammar(
        _registryOptions.GetScopeByLanguageId(_registryOptions.GetLanguageByExtension(extension).Id));
    }

    public void SetTheme(string variant)
    {
      if(variant == "Light")
        _textMateInstallation.SetTheme(_registryOptions.LoadTheme(ThemeName.Light));
      if(variant == "Dark")
        _textMateInstallation.SetTheme(_registryOptions.LoadTheme(ThemeName.Dark));
    }
  }

  class NoColorSyntax : IColorSyntax
  {
    public void SetGrammar(string extension){}
    public void SetTheme(string variant) {}
  }
  
}