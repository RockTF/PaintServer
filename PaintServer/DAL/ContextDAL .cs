using DAL.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ContextDAL : DbContext
    {
        public ContextDAL(DbContextOptions<ContextDAL> options) : base(options)
        {
        }

        public DbSet<PersonModel> Persons { get; set; }

        public DbSet<PictureModel> Pictures { get; set; }

        public DbSet<StatisticsModel> Statistics { get; set; }
    }
}
