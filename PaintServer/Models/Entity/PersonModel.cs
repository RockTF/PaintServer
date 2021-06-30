using PaintServer.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entity
{
    public class PersonModel
    {
        public PersonModel()
        {
             PictureModel = new List<PictureModel>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastVisitDate { get; set; }
        public ICollection<PictureModel> PictureModel { get; set; }
        public virtual StatisticsModel StatisticModel { get; set; }

        public PersonModel(UserRegistrationData userRegistrationData)
        {
            Name = userRegistrationData.Name;
            Lastname = userRegistrationData.LastName;
            Email = userRegistrationData.Login;
            Password = userRegistrationData.Password;
            Admin = false;
            RegisterDate = DateTime.Now;
            LastVisitDate = DateTime.Now;
        }
    }
}
