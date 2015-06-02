using System;
using Foundation;
using AppKit;
using ReactiveUI;
using RxUIPlayground.Core.ViewModels;
using System.Reactive;
using System.Reactive.Subjects;
using RxUIPlayground.Services;

namespace RxUIPlayground
{
    public partial class MainWindowController : NSWindowController, IViewFor<MainViewModel>
    {
        public MainWindowController(IntPtr handle)
            : base(handle)
        {
        }

        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder)
            : base(coder)
        {
        }

        public MainWindowController()
            : base("MainWindow")
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            VM = new MainViewModel();
            this.Bind(ViewModel, vm => vm.Name.Value, v => v.NameField.StringValue);
            this.OneWayBind(ViewModel, vm => vm.Greeting.Value, v => v.GreetingLabel.StringValue);

            this.BindCommand(ViewModel, vm => vm.UpperCommand, v => v.UpperButton);
            this.BindCommand(ViewModel, vm => vm.NotifyCommand, v => v.NotifyButton);
        }

        public new MainWindow Window
        {
            get { return (MainWindow)base.Window; }
        }

        #region IViewFor implementation

        public MainViewModel VM{ get; set; }

        public MainViewModel ViewModel
        {
            get
            {
                return VM;
            }
            set
            {
                VM = value;
            }
        }

        object IViewFor.ViewModel
        {
            get
            {
                return VM;
            }
            set
            {
                VM = (MainViewModel)value;
            }
        }

        #endregion

        IObservable<Unit> hookTextField(NSTextField textField)
        {
            var ret = new Subject<Unit>();
            textField.Delegate = new BlockDidChangeTextFieldDelegate(() => ret.OnNext(Unit.Default));
            return ret;
        }

        class BlockDidChangeTextFieldDelegate : NSTextFieldDelegate
        {
            Action block;

            public BlockDidChangeTextFieldDelegate(Action block)
            {
                this.block = block;
            }

            public override void Changed(NSNotification notification)
            {
                block();
            }
        }
    }
}
