using DTO;

namespace PaintServer.Interfaces
{
    public interface IPictureService
    {
        int AddPictureToDatabase(PictureDTO picture);
    }
}
