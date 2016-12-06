
using System;
using System.Drawing;
using System.Reactive.Disposables;
using Foundation;
using ReactiveUI;
using Shared;
using UIKit;

namespace ToDisposeOrNotToDispose.iOS
{
    public partial class ViewController1 : BaseViewController
    {
        public ViewController1():base()
        {            
        }

        public ViewController1(IntPtr handle) : base(handle)
        {
        }


        protected override void Setup()
        {
            this.moveForwardButton.TouchUpInside += Button_Click;

            AddToDisposable(this.BindCommand (ViewModel, vm => vm.DoIt, v => v.boundButton));
            AddToDisposable(this.OneWayBind (ViewModel, vm => vm.Name, v => v.nameLabel.Text));
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            this.moveForwardButton.TouchUpInside -= Button_Click;

            MoveFoward("ViewController2","1");
        }
    }
}