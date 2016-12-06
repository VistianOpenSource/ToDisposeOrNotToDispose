using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using ReactiveUI;


namespace ToDisposeOrNotToDispose
{
    [Activity(Label = "ToDisposeOrNotToDispose", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {
        protected override void MoveFoward()
        {
            this.StartActivity(typeof(Activity2));
        }
    }
}

