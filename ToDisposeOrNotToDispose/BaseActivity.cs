using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ReactiveUI;
using Shared;

namespace ToDisposeOrNotToDispose
{
    public class BaseActivity : ReactiveActivity<MyModel1>
    {
        private TextView _nameView;

        private CompositeDisposable _cd = new CompositeDisposable();

        private Button _button;

        private Button _boundButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _nameView = this.FindViewById<TextView>(Resource.Id.nameTextView);

            _button = this.FindViewById<Button>(Resource.Id.moveForwardButton);
            _button.Click += Button_Click;

            _boundButton = this.FindViewById<Button>(Resource.Id.boundButton);
            AddToDisposable(this.BindCommand (ViewModel, vm => vm.DoIt, v => v._boundButton), true);
            AddToDisposable(this.OneWayBind (ViewModel, vm => vm.Name, v => v._nameView.Text), true);

            this.ViewModel = Shared.Models.GetModel(1);

            AddToDisposable(this.WhenAnyValue (v => v.ViewModel.Name).LogDispose ("Activity WAV").Subscribe (), true);
        }

        private void AddToDisposable(IDisposable disposable,bool add=true)
        {
            if (add)
            {
                _cd.Add(disposable);
            }
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            _button.Click -= Button_Click;
            MoveFoward();
            this.Finish();
        }

        protected virtual void MoveFoward()
        {            
        }


        protected override void OnDestroy()
        {
            _cd.Dispose();
            base.OnDestroy();
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
