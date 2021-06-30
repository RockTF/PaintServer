using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Models.DTO
{
    public class PictureToClientDTO
    {
        public string Picture { get; set; }
        public EPictureTypes PictureType { get; set; }
    }
}
