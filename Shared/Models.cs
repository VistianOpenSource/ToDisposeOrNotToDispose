using System;
namespace Shared
{
    public static class Models
    {
        private static MyModel1 [] _models = new [] { new MyModel1 ("number1"), new Shared.MyModel1 ("Number 2") };


        public static MyModel1 GetModel (int instance)
        {
            return _models [instance - 1];
        }

    }
}
