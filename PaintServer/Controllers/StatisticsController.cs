using Microsoft.AspNetCore.Mvc;
using PaintServer.Interfaces;

namespace PaintServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet("{id}")]
        public IActionResult GetStatistic([FromQuery] int id)
        {
            var statistic = _statisticsService.GetStatistic(id);
            return Ok(statistic);
        }
    }
}
