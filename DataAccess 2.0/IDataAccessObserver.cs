using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataAccessObserver
    {

        void Update(byte[] blob, bool fileType, uint personID);

    }
}
