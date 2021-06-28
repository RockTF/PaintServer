using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class PictureModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PictureName { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public PersonModel personModel { get; set; }
    }
}
