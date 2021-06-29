using DAL.Models.Entity;
using Exeptions;
using PaintServer.Interfaces;
using PaintServer.Models.DTO;
using System;

namespace PaintServer.Services
{
    public class AuthService : IAuthService
    {
        private IDAL _DAL;

        public AuthService(IDAL DAL)
        {
            _DAL = DAL;
        }

        public PersonModel Login(UserAutorizationData userAutorizationData)
        {
            if (userAutorizationData == null) throw new ArgumentException(nameof(userAutorizationData));

            var person = _DAL.GetUserByAuthData(userAutorizationData);

            if (person == null) throw new AccessLevelException("Discription");

            return person;
        }

        public PersonModel Signup(UserRegistrationData userRegistrationData)
        {
            if (userRegistrationData == null) throw new ArgumentException(nameof(userRegistrationData));

            if (_DAL.GetUserByEmail(userRegistrationData.Login) != null) throw new AccessLevelException("User with this email exist!");

            var person = _DAL.AddNewUser(userRegistrationData);

            if (person == null) throw new AccessLevelException("Database not response");

            return person;

        }

        public bool UpdatePassword(UpdatePasswordDTO userAutorizationData)
        {
            if (userAutorizationData == null) throw new ArgumentException(nameof(userAutorizationData));

            var person = _DAL.GetUserByAuthData(userAutorizationData);

            if (person == null) throw new AccessLevelException("Discription");

            person.Password = userAutorizationData.NewPassword;

            return _DAL.UpdatePassword(person);
        }
    }
}
