using DAL.Models.Entity;
using PaintServer.Interfaces;
using PaintServer.Models.DTO;
using System;

namespace PaintServer.Services
{
    public class PictureService : IPictureService
    {
        private IDAL _dal;
        public PictureService (IDAL DAL)
        {
            _dal = DAL;
        }
        public int AddPictureToDatabase(PictureDTO pictureDto)
        {
            return _dal.AddPictureModelToPerson(pictureDto);
        }

        public PictureModel GetPictureByID(int pictureId) 
        {
            var picture = _dal.GetPictureByID(pictureId);

            if (picture == null) 
            {
                throw new ArgumentException("Not valid picture ID");
            }

            return picture;
        }
    }
}
