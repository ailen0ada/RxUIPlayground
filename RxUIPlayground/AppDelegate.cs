using System;

using Foundation;
using AppKit;
using Splat;
using RxUIPlayground.Core.Models;

namespace RxUIPlayground
{
    public partial class AppDelegate : NSApplicationDelegate
    {
        MainWindowController mainWindowController;

        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
			var loca = Locator.CurrentMutable;
			loca.RegisterLazySingleton (() => new Services.NativeAlert (), typeof(IDialogService));

            mainWindowController = new MainWindowController();
            mainWindowController.Window.MakeKeyAndOrderFront(this);
        }

		public override bool ApplicationShouldHandleReopen (NSApplication sender, bool hasVisibleWindows)
		{
			if (mainWindowController != null && !hasVisibleWindows)
				mainWindowController.Window.MakeKeyAndOrderFront (this);

			return true;
		}
    }
}

