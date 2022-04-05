using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_2
{
    public class DataAccessSubject
    {
        private readonly List<IDataAccessObserver> observers = new List<IDataAccessObserver>();

        public void Attach(IDataAccessObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IDataAccessObserver observer)
        {
            observers.Remove(observer);
        }


        public void NotifyObservers(byte[] blob, bool fileType, uint personID)
        {
            foreach (var observer in observers)
            {
                observer.Update(blob, fileType, personID);
            }
        }
    }
}
