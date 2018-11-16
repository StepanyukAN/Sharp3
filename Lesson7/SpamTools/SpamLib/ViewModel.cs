using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SpamLib
{
    public class AsyncSaveViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            var handlers = PropertyChanged;
            if(handlers is null) return;

            var e = new PropertyChangedEventArgs(PropertyName);

            var invocation_list = handlers.GetInvocationList();

            foreach (var d in invocation_list)
                switch (d.Target)
                {
                    default:
                        d.DynamicInvoke(this, e);
                        break;
                    case DispatcherObject dispatcher_object when !dispatcher_object.CheckAccess():
                        dispatcher_object.Dispatcher.Invoke(d, this, e);
                        break;
                }
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string Property = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(Property);
            return true;
        }
    }
}
