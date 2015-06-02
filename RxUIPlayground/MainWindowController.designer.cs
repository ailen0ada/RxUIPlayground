// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace RxUIPlayground
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		AppKit.NSTextField GreetingLabel { get; set; }

		[Outlet]
		AppKit.NSTextField NameField { get; set; }

		[Outlet]
		AppKit.NSButton NotifyButton { get; set; }

		[Outlet]
		AppKit.NSButton UpperButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (GreetingLabel != null) {
				GreetingLabel.Dispose ();
				GreetingLabel = null;
			}

			if (NameField != null) {
				NameField.Dispose ();
				NameField = null;
			}

			if (UpperButton != null) {
				UpperButton.Dispose ();
				UpperButton = null;
			}

			if (NotifyButton != null) {
				NotifyButton.Dispose ();
				NotifyButton = null;
			}
		}
	}
}
