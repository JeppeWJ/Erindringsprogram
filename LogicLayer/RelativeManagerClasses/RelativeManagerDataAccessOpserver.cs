using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTOs;

namespace LogicLayer.RelativeManagerClasses
{
    public class RelativeManagerDataAccessOpserver : IDataAccessObserver
    {
        private DataAccess dataAccess = new DataAccess();
        public List<RelativeDTO> Relatives { get; set; }
        private byte[] Blob;
        private bool FileType;
        private uint PersonID;

        public RelativeManagerDataAccessOpserver()
        {
            DataAccessSubject dataAccessSubject = new DataAccessSubject();
            dataAccessSubject.Attach(this);
            DataAccess dataAccess = new DataAccess();
        }

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

            FileType = fileType;
        }

        public void UpdateFile(bool fileType, uint id)
        {
            throw new NotImplementedException(); //hvad skal denne metode gøre?
        }

        public void CreateProfile(RelativeDTO newProfile)
        {
            throw new NotImplementedException();
        }

        public void DeleteProfile(uint id)
        {
            throw new NotImplementedException();
        }

        public void EditProfile(RelativeDTO person)
        {
            dataAccess.UploadImageOrAudioToDB(FileType,person.PersonID);
            RelativeDTO relativeDto = new RelativeDTO();
            if (FileType)
            {
                Relatives.Add(new RelativeDTO() {PersonID = relativeDto.PersonID, Audio = relativeDto.Audio}); //Adding PersonID and audio path to DTO List
            }
            else if (FileType != true)
            {
                Relatives.Add(new RelativeDTO() { PersonID = relativeDto.PersonID, Picture = relativeDto.Picture }); //Adding PersonID and image path to DTO List
            } // Skal Person ID tilføjes til DTO listen?
        }

    }
}
