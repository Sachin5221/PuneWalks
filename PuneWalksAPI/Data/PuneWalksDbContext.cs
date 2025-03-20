using Microsoft.EntityFrameworkCore;
using PuneWalksAPI.Models.Domain;

namespace PuneWalksAPI.Data
{
    public class PuneWalksDbContext:DbContext
    {
        public PuneWalksDbContext(DbContextOptions<PuneWalksDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Data for Difficulties
            var difficulties = new List<Difficulty>
            {
                new Difficulty ()
                {
                Id = Guid.Parse("8eb4ee42-2d96-4deb-94da-0a7334555205"),
                Name = "Easy"
                },
                new Difficulty()
               {
                   Id = Guid.Parse("5bdd875a-4391-41bd-b698-9a28eb69483d"),
                   Name = "Medium"
               },
               new Difficulty()
               {
                   Id = Guid.Parse("eb94d7d8-be39-4d8f-b6f1-260bcdfa0bb3"),
                   Name = "Difficult"
               }
            };
             //Seed Difficulties to the Database  
             modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed Data for Regions
            var regions = new List<Region>
            {
                new Region()
                {
                    Id = Guid.Parse("24723eba-058c-4582-a179-6b8a81da14f1"),
                    Code = "B1",
                    Name = "Pune Central",
                    RegionImageUrl = "https://images.unsplash.com/photo-1504674900247-0877df9cc836?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
                },
                new Region()
                {
                    Id = Guid.Parse("430e0cd7-0d20-4890-91e0-f8af8e787b85"),
                    Code = "B2",
                    Name = "Pune North",
                    RegionImageUrl = "https://images.unsplash.com/photo-1504674900247-0877df9cc836?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
                },
                 new Region()
                 {
                     Id = Guid.Parse("bd16b915-ae4a-4d6f-a008-eee0b90cf4f0"),
                     Code = "B3",
                     Name = "Pune South",
                     RegionImageUrl = "https://images.unsplash.com/photo-1504674900247-0877df9cc836?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"

                 },
                  

            };
                modelBuilder.Entity<Region>().HasData(regions);
        }     

    }
}
