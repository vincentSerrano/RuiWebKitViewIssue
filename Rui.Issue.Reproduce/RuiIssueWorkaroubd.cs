using System.Reactive.Linq;
using AppKit;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Rui.Issue.Reproduce
{
    public static class RuiIssueWorkaroubd
    {
        public static void Workaround()
        {
            Observable.FromAsync(DoBusinessLogic).
                Subscribe(
                    _ => { },
                    OnBusinessLogicFailed,
                    () => { });
        }

        private static void OnBusinessLogicFailed(Exception e)
        {
            NSApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                var storyboard = NSStoryboard.FromName("Main", null);
                var nSWindowController = storyboard.InstantiateControllerWithIdentifier("MyWindowController") as MyWindowController;
                var contentController = storyboard.InstantiateControllerWithIdentifier("MyViewController") as ViewController;
                nSWindowController.ContentViewController = contentController;
                var result = NSApplication.SharedApplication.RunModalForWindow(nSWindowController.Window);
                nSWindowController.Close();
            });
        }

        private static async Task DoBusinessLogic(CancellationToken token)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), token);
            throw new Exception();
        }
    }
}
