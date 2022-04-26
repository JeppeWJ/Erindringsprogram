using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTOs;

namespace LogicLayer.RelativeManagerClasses
{
    class RelativeManagerDataAccessOpserver : IDataAccessObserver
    {
        public RelativeManagerDataAccessOpserver()
        {
            DataAccessSubject dataAccessSubject = new DataAccessSubject();
            dataAccessSubject.Attach(this);
        }

        public List<RelativeDTO> Relatives { get; set; }
        private byte[] Blob;
        private bool FileType;
        private uint PersonID;




        public void Update(RelativeDTO updateRelativeDto, bool fileType)
        {
            


            RelativeDTO personDto = Relatives.Find(PersonDTO => PersonDTO.PersonID == updateRelativeDto.PersonID);


            if (fileType)
            {
                personDto.Audio = updateRelativeDto.Audio;
            }
            if (fileType != true)
            {
                personDto.Picture = updateRelativeDto.Picture;
            }

            Relatives.Insert(Convert.ToInt32(updateRelativeDto.PersonID - 1), personDto);



            var obj = Relatives.FirstOrDefault(PersonDTO => PersonDTO.PersonID == updateRelativeDto.PersonID);
            if (obj != null && fileType == true) obj.Audio = updateRelativeDto.Audio;
            else if (obj != null && fileType != true) obj.Picture = updateRelativeDto.Picture;
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
