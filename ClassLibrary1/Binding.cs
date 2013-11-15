using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding
{
    public interface IObserver<in T>
        where T : EventArgs
    {
        void Update(Object sender, T e);
    }

    public interface ISubject<out T>
        where T : EventArgs
    {
        void Attach(IObserver<T> observer); 
        void Detach(IObserver<T> observer);
    }
}
