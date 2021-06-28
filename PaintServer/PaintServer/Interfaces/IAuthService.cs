using DAL.Models;
using DTO;
using PaintServer.Models.DTO;

namespace PaintServer.Interfaces
{
    public interface IAuthService
    {
        PersonModel Login(UserAutorizationData userAutorizationData);

        bool UpdatePassword(UpdatePasswordDTO userAutorizationData);
    }
}
