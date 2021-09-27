using AppKit;
using Foundation;

namespace Rui.Issue.Reproduce
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            RuiIssueRepro.ReproduceIssue();
            //RuiIssueWorkaroubd.Workaround();
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
