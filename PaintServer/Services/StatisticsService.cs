using DAL.Models.Entity;
using Exeptions;
using PaintServer.Interfaces;
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
    }
}
