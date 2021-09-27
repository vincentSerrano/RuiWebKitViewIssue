using System.Reactive.Linq;
using AppKit;
using System;
using System.Threading.Tasks;
using System.Threading;
using ReactiveUI;

namespace Rui.Issue.Reproduce
{
    public static class RuiIssueRepro
    {
        public static void ReproduceIssue()
        {
            Observable.FromAsync(DoBusinessLogic).
                ObserveOn(RxApp.MainThreadScheduler).
                Subscribe(
                    _ => { },
                    OnBusinessLogicFailed,
                    () => { });
        }

        private static MyWindowController CreateWindow()
        {
            var storyboard = NSStoryboard.FromName("Main", null);
            var nSWindowController = storyboard.InstantiateControllerWithIdentifier("MyWindowController") as MyWindowController;
            var contentController = storyboard.InstantiateControllerWithIdentifier("MyViewController") as ViewController;
            nSWindowController.ContentViewController = contentController;
            return nSWindowController;
        }

        private static async Task DoBusinessLogic(CancellationToken token)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), token);
            throw new Exception();
        }

        private static void OnBusinessLogicFailed(Exception e)
        {
            var nSWindowController = CreateWindow();
            _ = NSApplication.SharedApplication.RunModalForWindow(nSWindowController.Window);
            nSWindowController.Close();
        }
    }
}
