using DAL.Models.Entity;
using PaintServer.Models.DTO;

namespace PaintServer.Interfaces
{
    public interface IPictureService
    {
        int AddPictureToDatabase(PictureDTO picture);

        PictureToClientDTO GetPictureByID(int pictureId);

        PictureListDTO GetAllPicturesForUser(int userId);
    }
}
