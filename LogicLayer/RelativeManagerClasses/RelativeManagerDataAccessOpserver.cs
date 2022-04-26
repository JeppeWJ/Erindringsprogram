using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTOs;

namespace LogicLayer.RelativeManagerClasses
{
    class RelativeManagerDataAccessOpserver //: IDataAccessObserver
    {
        public List<RelativeDTO> Relatives { get; set; }
        private byte[] Blob;
        private bool FileType;
        private uint PersonID;



        public void Update(byte[] blob, bool fileType, uint personID)
        {
            int length = blob.Length;
            Blob = new byte[length];
            Blob = blob;
            FileType = fileType;
            PersonID = personID;


            //PersonsDTO personDto = PersonsList.Find(PersonDTO => PersonDTO.PersonID == personID);

            //personDto.Image = blob;


            //PersonsList.Insert(Convert.ToInt32(personID - 1), personDto);




            ////var obj = PersonsList.FirstOrDefault(PersonDTO => PersonDTO.PersonID == personID);
            ////if (obj != null && fileType == true)  obj.SoundFile = blob;
            ////else if (obj != null && fileType == false) obj.Image = blob;

            //if (fileType)
            //{
            //    ImagesToGUI(PersonsList);
        }



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
