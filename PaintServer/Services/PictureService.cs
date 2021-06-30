﻿using PaintServer.Interfaces;
using PaintServer.Models.DTO;
using System;

namespace PaintServer.Services
{
    public class PictureService : IPictureService
    {
        private IDAL _dal;
        private readonly IStatisticsService _statisticsService;

        public PictureService (IDAL DAL, IStatisticsService statisticsService)
        {
            _dal = DAL;
            _statisticsService = statisticsService;
        }

        public int AddPictureToDatabase(PictureDTO pictureDto)
        {
            if (pictureDto == null)
            {
                throw new ArgumentException("There is no picture recived");
            }

            _statisticsService.UpdateStatistics(pictureDto);

            return _dal.AddPictureModelToPerson(pictureDto);
        }

        public PictureListDTO GetAllPicturesForUser(int userId)
        {
            return _dal.GetAllPicturesForUser(userId);
        }

        public PictureToClientDTO GetPictureByID(int pictureId) 
        {
            var pictureModel = _dal.GetPictureByID(pictureId);

            if (pictureModel == null) 
            {
                throw new ArgumentException("Not valid picture ID");
            }

            PictureToClientDTO picture = new PictureToClientDTO
            {
                Picture = pictureModel.Picture,
                PictureType = pictureModel.PictureType
            };

            return picture;
        }
    }
}
