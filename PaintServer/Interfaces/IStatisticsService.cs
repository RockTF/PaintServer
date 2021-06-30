using DAL.Models.Entity;
using System.Collections.Generic;

namespace PaintServer.Interfaces
{
    public interface IStatisticsService
    {
        IEnumerable<PersonModel> GetStatistic(int? id);
    }
}
