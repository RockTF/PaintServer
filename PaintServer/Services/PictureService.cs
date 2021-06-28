using DTO;
using PaintServer.Interfaces;

namespace PaintServer.Services
{
    public class PictureService : IPictureService
    {
        IDAL _dal;
        public PictureService (IDAL DAL)
        {
            _dal = DAL;
        }
        public int AddPictureToDatabase(PictureDTO pictureDto)
        {
            return _dal.AddPictureModelToPerson(pictureDto);
        }
    }
}
