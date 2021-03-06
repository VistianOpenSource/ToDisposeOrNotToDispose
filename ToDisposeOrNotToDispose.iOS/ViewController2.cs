
using System;
using System.Drawing;

using Foundation;
using ReactiveUI;
using Shared;
using UIKit;

namespace ToDisposeOrNotToDispose.iOS
{
    public partial class ViewController2 : BaseViewController
    {
        public ViewController2():base()
        {
            
        }
        public ViewController2(IntPtr handle) : base(handle)
        {
        }

        protected override void Setup()
        {
            this.MoveForwardButton.TouchUpInside += Button_Click;

            AddToDisposable(this.BindCommand (ViewModel, vm => vm.DoIt, v => v.BoundButton), true);
            AddToDisposable(this.OneWayBind (ViewModel, vm => vm.Name, v => v.nameLabel.Text), true);

              this.ViewModel = Models.GetModel (2);
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            this.MoveForwardButton.TouchUpInside -= Button_Click;

            MoveFoward("ViewController1", "1");
        }
    }
}