using PaintServer.Models.DTO;
using System;
using System.Collections.Generic;

namespace PaintServer.Models.DTO
{
    public class PictureDTO
    {
        public int UserId { get; set; }
        public string PictureName { get; set; }
        public string PictureContent { get; set; }
        public int PictureSize { get; set; }
        public DateTime CreationDate { get; set; }
        public EPictureTypes PictureType { get; set; }
        public Dictionary<string, int> Figures { get; set; }
    }
}
