using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Shared
{
    public static class ObservableLog
    {
        public static IObservable<T> LogDispose<T>(this IObservable<T> source,string message)
        {
            return Observable.Create<T>((o) =>
            {
                var cd = new CompositeDisposable();

                var sub = source.Subscribe((s) => o.OnNext(s),(Exception e) => o.OnError(e),() => o.OnCompleted());

                cd.Add(sub);

                cd.Add(Disposable.Create(() => {
                    System.Diagnostics.Debug.WriteLine($"{message} Disposed"); }
                ));

                return cd;
            });
        }
    }
}