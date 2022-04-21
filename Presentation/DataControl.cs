using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_2;
using Logic_2._0.RelativeManagerClasses;

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

        public List<RelativeDTO> Relatives { get; set; }
        public void UpdateFile(bool fileType, uint id)
        {
           throw new NotImplementedException();
        }

        public void CreateProfile(RelativeDTO newProfile)
        {
           throw new NotImplementedException();
        }

        public void DeleteProfile(uint id)
        {
           throw new NotImplementedException();
        }

        public void EditProfile(RelativeDTO profile)
        {
           throw new NotImplementedException();
        }
    }
}
