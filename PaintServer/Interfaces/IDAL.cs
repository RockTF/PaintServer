using DAL.Models.Entity;
using PaintServer.Models.DTO;
using System.Collections.Generic;

namespace PaintServer.Interfaces
{
    public interface IDAL
    {
        PersonModel GetUserByAuthData(UserAutorizationData userAutorizationData);

        PersonModel AddNewUser(UserRegistrationData userRegistrationData);

        PersonModel GetUserByEmail(string email);

        int SavePicture(PictureModel pictureModel);

        PersonModel GetPersonById(int id);

        PersonModel Get(string email);

        bool UpdatePassword(PersonModel person);

        IEnumerable<PersonModel> Get();

        PersonModel Delete(int id);

        void Create(UserRegistrationData userRegistrationData);

        int AddPictureModelToPerson(PictureDTO pictureDto);

        PictureModel GetPictureByID(int pictureId);

        StatisticsModel GetStatisticByUserId(int id);

        PictureListDTO GetAllPicturesForUser(int id);

        void UpdateStatistics(StatisticsModel statistics);
    }
}
