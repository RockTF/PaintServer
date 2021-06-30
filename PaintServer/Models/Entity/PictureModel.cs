﻿using PaintServer.Models.DTO;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entity
{
    public class PictureModel
    {
        public int Id { get; set; }

        [ForeignKey("PersonModel")]
        public int PersonId { get; set; }
        public string PictureName { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public EPictureTypes PictureType { get; set; }
        public PersonModel PersonModel { get; set; }

        public PictureModel()
        {

        }

        public PictureModel(PictureDTO pictureDto)
        {
            PersonId = pictureDto.UserId;
            PictureName = pictureDto.PictureName;
            Picture = pictureDto.PictureContent;
            CreationDate = pictureDto.CreationDate;
            PictureType = pictureDto.PictureType;
        }
    }
}
