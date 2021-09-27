// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using WebKit;

namespace Rui.Issue.Reproduce
{
    [Register("ViewController")]
    partial class ViewController
    {
        [Outlet]
        WKWebView MyWebView { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (MyWebView != null)
            {
                MyWebView.Dispose();
                MyWebView = null;
            }
        }
    }
}
