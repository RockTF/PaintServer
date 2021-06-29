using Microsoft.AspNetCore.Mvc;
using PaintServer.Interfaces;
using PaintServer.Models.DTO;

namespace PaintServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpGet("{id}")]
        public IActionResult GetPictureByID([FromQuery] int id)
        {
            var picture = _pictureService.GetPictureByID(id);
            return Ok(picture);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PictureDTO pictureDto)
        {
            var result = _pictureService.AddPictureToDatabase(pictureDto);

            return Ok();
        }
        
    }
}
