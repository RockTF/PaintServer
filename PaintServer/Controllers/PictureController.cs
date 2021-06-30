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

        [HttpGet]
        public IActionResult GetPicturesByUserId([FromQuery] int userId)
        {
            var picture = _pictureService.GetAllPicturesForUser(userId);
            return Ok(picture);
        }

        [HttpGet]
        [Route("picture")]
        public IActionResult GetPictureByID([FromQuery]int pictureeId)
        {
            var picture = _pictureService.GetPictureByID(pictureeId);
            return Ok(picture);
        }

        [HttpPost]
        public IActionResult SavePicture([FromBody] PictureDTO pictureDto)
        {
            var result = _pictureService.AddPictureToDatabase(pictureDto);

            return Ok("Successfully saved");
        }
        
    }
}
