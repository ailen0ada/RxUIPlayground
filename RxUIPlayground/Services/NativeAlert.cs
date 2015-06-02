using System;
using RxUIPlayground.Core.Models;
using AppKit;

namespace RxUIPlayground.Services
{
    public class NativeAlert : IDialogService
    {
        #region IDialogService implementation

        public void Notify(string msg, string title)
        {
            var wnd = NSApplication.SharedApplication.MainWindow;
            if (wnd == null)
                return;

            using (var alert = new NSAlert())
            {
                alert.MessageText = title;
                alert.InformativeText = msg;
                alert.RunSheetModal(wnd);
            }
        }

        #endregion
    }
}

