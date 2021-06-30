using DAL.Models.Entity;
using PaintServer.Models.DTO;
using System.Collections.Generic;

namespace PaintServer.Interfaces
{
    public interface IStatisticsService
    {
        IEnumerable<PersonModel> GetStatistic(int? id);

        void UpdateStatistics(PictureDTO pictureDto);
    }
}
