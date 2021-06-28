using DAL.Models.Entity;
using PaintServer.Models.DTO;

namespace PaintServer.Interfaces
{
    public interface IAuthService
    {
        PersonModel Login(UserAutorizationData userAutorizationData);

        PersonModel Signup(UserRegistrationData userRegistrationData);

        bool UpdatePassword(UpdatePasswordDTO userAutorizationData);
    }
}
