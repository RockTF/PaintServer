using System;

namespace PaintServer.Models.DTO
{
    public class PictureDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PictureName { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public EPictureTypes PictureType { get; set; }
        public int Curve { get; set; }
        public int Dot { get; set; }
        public int Ellipse { get; set; }
        public int Line { get; set; }
        public int Triangle { get; set; }
        public int Polygon { get; set; }
        public int Rectangle { get; set; }
        public int SmoothCurve { get; set; }
        public int RoundedRectangle { get; set; }
    }
}
