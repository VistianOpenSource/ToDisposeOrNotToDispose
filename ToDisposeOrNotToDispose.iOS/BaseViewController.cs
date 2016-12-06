using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;
using ReactiveUI;
using Shared;
using UIKit;

namespace ToDisposeOrNotToDispose.iOS
{
public class BaseViewController:ReactiveViewController,IViewFor<MyModel1>
    {


        MyModel1 _ViewModel;
    public MyModel1 ViewModel
    {
        get { return _ViewModel; }
        set { this.RaiseAndSetIfChanged(ref _ViewModel, value); }
    }

    object IViewFor.ViewModel
    {
        get { return _ViewModel; }
        set { _ViewModel = (MyModel1)value; }
    }

    public BaseViewController()
    {
    }

    public BaseViewController(IntPtr handle) : base(handle)
        {
    }

    public override void DidReceiveMemoryWarning()
    {
        // Releases the view if it doesn't have a superview.
        base.DidReceiveMemoryWarning();

        // Release any cached data, images, etc that aren't in use.
    }

    #region View lifecycle

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        // Perform any additional setup after loading the view, typically from a 
    }

    private CompositeDisposable _cd = new CompositeDisposable();

    public override void ViewWillAppear(bool animated)
    {
        base.ViewWillAppear(animated);

        Setup();

        this.ViewModel = new MyModel1(this.GetType().Name);

        AddToDisposable(this.WhenAnyValue (v => v.ViewModel.Name).LogDispose ("Activity WAV").Subscribe (), false);
    }

        protected virtual void Setup()
        {
            
        }

    protected void AddToDisposable(IDisposable disposable,bool add=true)
    {
            if (add) {
                _cd.Add(disposable);
            }
    }

    protected void MoveFoward(string sbName,string viewId)
    {
        UIStoryboard sb = UIStoryboard.FromName(sbName, null);

        var view = sb.InstantiateViewController(viewId);

        NavigationController.SetViewControllers(new UIViewController[] { view }, false);
    }





    public override void ViewDidAppear(bool animated)
    {
        base.ViewDidAppear(animated);
    }

    public override void ViewWillDisappear(bool animated)
    {
        base.ViewWillDisappear(animated);
    }

    public override void ViewDidDisappear(bool animated)
    {
        base.ViewDidDisappear(animated);
    }

    public override void ViewDidUnload ()
    {
            _cd.Dispose ();

            base.ViewDidUnload ();
    }
    #endregion
}}
