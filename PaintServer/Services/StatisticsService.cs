using DAL.Models.Entity;
using Exeptions;
using PaintServer.Interfaces;
using PaintServer.Models.DTO;
using System;
using System.Collections.Generic;

namespace PaintServer.Services
{
    public class StatisticsService : IStatisticsService
    {
        private IDAL _dal;

        public StatisticsService(IDAL DAL)
        {
            _dal = DAL;
        }

        public IEnumerable<PersonModel> GetStatistic(int? id) 
        {
            if (id == null) throw new ArgumentException(nameof(id));

            var statistic = _dal.Get();

            if (statistic == null) throw new AccessLevelException("No statistics for this user(");

            return statistic;
        }

        public void UpdateStatistics(PictureDTO pictureDto)
        {
            var person = _dal.GetPersonById(pictureDto.UserId);

            person.StatisticModel.FullPictureSize += pictureDto.PictureSize;
            person.StatisticModel.LastActivity = DateTime.Now;
            person.StatisticModel.FillFigures(pictureDto.Figures);
            person.StatisticModel.FillFavoriteFigures();

            _dal.UpdateStatistics(person.StatisticModel);
        }
    }
}
