using System;
using ReactiveUI;
using Splat;
using System.Reactive.Linq;
using RxUIPlayground.Core.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace RxUIPlayground.Core.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public ReactiveProperty<string> Name{ get; private set; }

        public ReadOnlyReactiveProperty<string> Greeting{ get; private set; }

        public ReactiveUI.ReactiveCommand<object> UpperCommand{ get; private set; }

        public ReactiveUI.ReactiveCommand<object> NotifyCommand{ get; private set; }

        readonly GreetingService _service;

        public MainViewModel()
        {
			var dlg = Locator.CurrentMutable.GetService<IDialogService> ();
            _service = new GreetingService(dlg);

            Name = _service.ToReactivePropertyAsSynchronized(m => m.Name);
            Greeting = Name.Sample(TimeSpan.FromMilliseconds(1000)).Select(x => string.Format("Hello, {0}!", x)).ToReadOnlyReactiveProperty("Waiting");

            UpperCommand = ReactiveUI.ReactiveCommand.Create(Name.Select(x => !string.IsNullOrEmpty(x)));
            UpperCommand.Subscribe(_ => _service.ChangeNameUpper());

            NotifyCommand = ReactiveUI.ReactiveCommand.Create();
            NotifyCommand.Subscribe(_ => _service.Notify());
        }
    }
}

