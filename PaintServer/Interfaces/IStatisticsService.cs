using DAL.Models.Entity;

namespace PaintServer.Interfaces
{
    public interface IStatisticsService
    {
        StatisticsModel GetStatistic(int? id);
    }
}
