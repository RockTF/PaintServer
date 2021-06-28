using DAL.Models;
using DTO;
using System.Collections.Generic;

namespace PaintServer.Interfaces
{
    public interface IDAL
    {
        PersonModel GetUserByAuthData(UserAutorizationData userAutorizationData);





        PersonModel Get(int id);

        PersonModel Get(string email);

        bool UpdatePassword(PersonModel person);

        IEnumerable<PersonModel> Get();

        PersonModel Delete(int id);

        void Create(UserRegistrationData userRegistrationData);
    }
}
