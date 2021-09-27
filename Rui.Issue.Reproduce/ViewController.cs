using System;
using ReactiveUI;
using AppKit;
using Foundation;

namespace Rui.Issue.Reproduce
{
    public partial class ViewController : ReactiveViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
            var request = new NSMutableUrlRequest(new NSUrl("https://google.com"));
            MyWebView.LoadRequest(request);
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
