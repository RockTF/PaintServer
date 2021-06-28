using System;

namespace DTO
{
    public class PictureDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PictureName { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
