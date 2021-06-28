using DTO;
using Microsoft.AspNetCore.Mvc;
using PaintServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaintServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }
        // GET: api/<PictureController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PictureController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PictureController>
        [HttpPost]
        public IActionResult Post([FromBody] PictureDTO pictureDto)
        {
            var result = _pictureService.AddPictureToDatabase(pictureDto);

            return Ok();
        }

        // PUT api/<PictureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PictureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
