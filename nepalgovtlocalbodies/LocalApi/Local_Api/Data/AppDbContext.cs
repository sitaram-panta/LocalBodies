using Local_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Local_Api.Data
{
    public class AppDbContext: DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> context): base(context) 
        {
            
        }

        public DbSet<Province> provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<OldDistrict> OldDistricts { get; set; }
        public DbSet<OldMunicipality> OldMunicipalities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

    

}
