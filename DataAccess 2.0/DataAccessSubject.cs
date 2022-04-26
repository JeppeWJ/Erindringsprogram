using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace DataAccessLayer
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


        public void NotifyObservers(RelativeDTO relativeDto, bool fileType)
        {
            foreach (var observer in observers)
            {
                observer.Update(relativeDto, fileType);
            }
        }
    }
}
