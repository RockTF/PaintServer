using DAL.Models.Entity;
using PaintServer.Models.DTO;

namespace PaintServer.Interfaces
{
    public interface IPictureService
    {
        int AddPictureToDatabase(PictureDTO picture);

        PictureModel GetPictureByID(int pictureId);
    }
}
