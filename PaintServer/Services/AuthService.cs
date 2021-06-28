using AskMe.Common.Exceptions;
using DAL.Models;
using DTO;
using PaintServer.Interfaces;
using PaintServer.Models.DTO;
using System;

namespace PaintServer.Services
{
    public class AuthService : IAuthService
    {
        public IDAL _DAL;

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
