using DAL.Models;
using DTO;
using PaintServer.Interfaces;
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
            return _context.Persons.Find(id);
        }

        public PersonModel Get(string email)
        {
            var person = _context.Persons.Where(s => s.Email == email).FirstOrDefault<PersonModel>();
            return person;
        }

        public bool UpdatePassword(PersonModel person)
        {
            if (person == null) throw new ArgumentException(nameof(person));

            _context.Persons.Update(person);
            _context.SaveChanges();

            return true;
        }
    }
}
