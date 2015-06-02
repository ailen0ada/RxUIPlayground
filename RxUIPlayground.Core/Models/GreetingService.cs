using System;

namespace RxUIPlayground.Core.Models
{
    public class GreetingService : NotificationObject
    {
        readonly IDialogService _dialog;

        public GreetingService(IDialogService dialog)
        {
            _dialog = dialog;
            Name = "Xamarin";
        }

        string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public void ChangeNameUpper()
        {
            Name = _name.ToUpperInvariant();
        }

        public void Notify()
        {
            _dialog.Notify(_name, "Greeting.");
        }
    }
}

