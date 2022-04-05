using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_2;

namespace Presentation
{
    class DataControl : IDataAccessObserver
    {
        byte[] Blob;


        public DataControl(DataAccess dataAccess)
        {

            dataAccess.Attach(this);

        }

        public void Update(byte[] blob, bool fileType, uint personID)
        {
            int length = blob.Length;
            Blob = new byte[length];
            Blob = blob;
        }
    }
}
