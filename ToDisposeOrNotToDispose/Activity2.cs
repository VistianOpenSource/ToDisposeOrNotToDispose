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

namespace ToDisposeOrNotToDispose
{
    [Activity(Label = "Activity2")]
    public class Activity2 : BaseActivity
    {
        protected override void MoveFoward()
        {
            this.StartActivity(typeof(MainActivity));
        }
    }
}