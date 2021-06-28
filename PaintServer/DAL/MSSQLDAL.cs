using DAL.Models.Entity;
using PaintServer.Interfaces;
using PaintServer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class MSSQLDAL : IDAL
    {

        private ContextDAL _context;

        public MSSQLDAL(ContextDAL context) 
        {
            _context = context;
        }

        public PersonModel GetUserByAuthData(UserAutorizationData userAutorizationData)
        {
            if (userAutorizationData == null) throw new ArgumentException(nameof(userAutorizationData));

            var person = _context.Persons.FirstOrDefault(p => p.Email == userAutorizationData.Login &&
                                                       p.Password == userAutorizationData.Password);

            return person;
        }

        public PersonModel GetUserByEmail(string email)
        {
            if (email.Length == 0) throw new ArgumentException(nameof(email));

            var person = _context.Persons.FirstOrDefault(p => p.Email == email);

            return person;
        }

        public PersonModel AddNewUser(UserRegistrationData userRegistrationData)
        {
            if (userRegistrationData == null) throw new ArgumentException(nameof(userRegistrationData));

            if (Get(userRegistrationData.Login) == null)
            {
                PersonModel person = new PersonModel()
                {
                    Name = userRegistrationData.Name,
                    Lastname = userRegistrationData.LastName,
                    Email = userRegistrationData.Login,
                    Password = userRegistrationData.Password,
                    Admin = false,
                    RegisterDate = DateTime.Now,
                    LastVisitDate = DateTime.Now
                };

                _context.Persons.Add(person);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User exist!");
            }

            return _context.Persons.OrderByDescending(p => p.Id).FirstOrDefault();
        }

        public void Create(UserRegistrationData userRegistrationData)
        {

            if (Get(userRegistrationData.Login) == null)
            {
                PersonModel person = new PersonModel()
                {
                    Name = userRegistrationData.Name,
                    Lastname = userRegistrationData.LastName,
                    Email = userRegistrationData.Login,
                    Password = userRegistrationData.Password,
                    Admin = false,
                    RegisterDate = DateTime.Now,
                    LastVisitDate = DateTime.Now
                };

                _context.Persons.Add(person);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User exist!");
            }
        }

        public PersonModel Delete(int id)
        {
            PersonModel todoItem = Get(id);

            if (todoItem != null)
            {
                _context.Persons.Remove(todoItem);
                _context.SaveChanges();
            }

            return todoItem;
        }

        public IEnumerable<PersonModel> Get()
        {
            return _context.Persons;
        }

        public PersonModel Get(int id)
        {
            return _context.Persons.FirstOrDefault(p => p.Id == id);
        }

        public PersonModel Get(string email)
        {
            var person = _context.Persons.FirstOrDefault(s => s.Email == email);
            return person;
        }

        public StatisticsModel GetStatisticByUserId(int? id)
        {
            var staistic = _context.Statistics.FirstOrDefault(s => s.PersonId == id);
            return staistic;
        }

        public bool UpdatePassword(PersonModel person)
        {
            if (person == null) throw new ArgumentException(nameof(person));

            _context.Persons.Update(person);
            _context.SaveChanges();

            return true;
        }

        public int SavePicture(PictureModel pictureModel)
        {
            _context.Add(pictureModel);
            _context.SaveChanges();
            return pictureModel.Id;
        }

        public int AddPictureModelToPerson(PictureDTO pictureDto)
        {
            var person = Get(pictureDto.UserId);
            var picture = new PictureModel
            {
                PersonId = pictureDto.UserId,
                PictureName = pictureDto.PictureName,
                Picture = pictureDto.Picture,
                CreationDate = DateTime.Now,
            };
            person.pictureModel.Add(picture);
            _context.SaveChanges();
            var newint = picture.Id;
            return newint;
        }

        public PictureModel GetPictureByID(int pictureId)
        {
            var picture = _context.Pictures.FirstOrDefault(p => p.Id == pictureId);
            return picture;
        }

    }
}
