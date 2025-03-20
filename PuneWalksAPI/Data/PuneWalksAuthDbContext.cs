using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PuneWalksAPI.Data
{
    public class PuneWalksAuthDbContext : IdentityDbContext
    {
        public PuneWalksAuthDbContext(DbContextOptions<PuneWalksAuthDbContext> options) : base(options)
        {
        }

        //        protected override void OnModelCreating(ModelBuilder builder)
        //        {
        //            base.OnModelCreating(builder);

        //            var readerRoleId = "72d3a5d4-bb19-4305-817c-550c91c63c74";
        //            var writerRoleId = "2b2bf046-5529-4aa5-ab0a-c6d227eaceda";

        //            var role = builder.Entity<IdentityRole>();
        //            {
        //                new IdentityRole
        //                {
        //                    Id = readerRoleId,
        //                    ConcurrencyStamp = readerRoleId,
        //                    Name = "Reader",
        //                    NormalizedName = "READER".ToUpper()
        //                };
        //                new IdentityRole
        //                {
        //                    Id = writerRoleId,
        //                    ConcurrencyStamp = writerRoleId,
        //                    Name = "Writer",
        //                    NormalizedName = "WRITER".ToUpper()
        //                };

        //            }
        //            builder.Entity<IdentityRole>().HasData(role);
        //        }
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "72d3a5d4-bb19-4305-817c-550c91c63c74";
            var writerRoleId = "2b2bf046-5529-4aa5-ab0a-c6d227eaceda";

            var roles = new[]
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "READER".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
}
}