using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace Shared
{
    public class MyModel1:ReactiveObject
    {

        private string _name;

        private byte[] _bigArray;

        public string Name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value);
            }
        }

        private SubModel _sub;

        public SubModel Sub
        {
            get { return _sub; }
            set { this.RaiseAndSetIfChanged(ref _sub, value); }
        }

        public ReactiveCommand<Unit,bool> DoIt { get; set; }

        public MyModel1(string inst)
        {          
            // just so I can see that memory is being consumed in the profiler
            _bigArray = new byte[1024*1024];

            ObservableExtensions.Subscribe<string>(Observable.Do<string>(this.WhenAnyValue(vm => vm.Sub.Name), v => Name=v).LogDispose($"MyModel1 {inst}"));

            Sub = new SubModel();

            DoIt = ReactiveCommand.Create(()  => true);

            DoIt.Subscribe();
        }
    }


    public class SubModel : ReactiveObject
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                this.RaiseAndSetIfChanged(ref _name, value);
            }
        }

        public SubModel()
        {
            Name = "initial";
        }
    }




}