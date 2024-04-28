using System;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace TalkingAboutAvalonia.Browser;

[SupportedOSPlatform("browser")]
internal static partial class Interop
{
  static Interop()
  {
    Eval(@"
    window.openLinkedWindow = function (args) {
      if(window.other && !window.other.closed)
        return;
      var url = window.location.href+args;
      var w = window.open(url, '_blank', 'popup');
      w.other = window;
      window.other = w;
      var iid = window.setInterval(function () {
        if(window.other.interop) {
          window.clearInterval(iid);
          window.interop.OpenLinkedWindowComplete(args);
        }
      }, 100);
    };

    window.sendMessage = function (args) {
      if(window.other && !window.other.closed && window.other.interop) {
        window.other.interop.ReceiveMessage(args);
      }
    };
");
  }

  [JSImport("globalThis.eval")]
  public static partial JSObject Eval(string eval);

  [JSImport("globalThis.openLinkedWindow")]
  public static partial void OpenLinkedWindow(string args);

  public static Action<string> OpenLinkedWindowCallback { get; set; }
  
  [JSExport]
  public static void OpenLinkedWindowComplete(string args) => OpenLinkedWindowCallback(args);

  [JSImport("globalThis.open")]
  public static partial void OpenUrl(string url);

  [JSImport("globalThis.sendMessage")]
  public static partial void Send(string message);

  [JSExport]
  public static void ReceiveMessage(string message)
  {
    try
    {
      Exchange.ReceiveMessage(message);
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
    }
  }

  private static WindowExchange Exchange => (WindowExchange)TheApp.WindowExchange;
}