using System.Collections.Generic;

namespace ClockObserver
{
    public abstract class Subject
    {
        private readonly List<IObserver> observers = new();

        public void Attach(IObserver observer)
        {
            lock (observers)
            {
                observers.Add(observer);
            }
        }
        public void Detach(IObserver observer)
        {
            lock (observers)
            {
                observers.Remove(observer);
            }
        }
        public void Notify()
        {
            lock (observers)
            {
                observers.ForEach(observer => observer.Update());
            }
        }
    }
}
