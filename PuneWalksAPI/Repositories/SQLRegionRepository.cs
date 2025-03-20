using Microsoft.EntityFrameworkCore;
using PuneWalksAPI.Data;
using PuneWalksAPI.Models.Domain;

namespace PuneWalksAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly PuneWalksDbContext dbContext;
        public SQLRegionRepository( PuneWalksDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion != null)
            {
                dbContext.Regions.Remove(existingRegion);
                await dbContext.SaveChangesAsync();
                return existingRegion;
            }
            return null;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetSingleAsync(Guid id)
        {
            
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await GetSingleAsync(id);
            if (existingRegion != null)
            {
                existingRegion.Code = region.Code;
                existingRegion.Name = region.Name;
                existingRegion.RegionImageUrl = region.RegionImageUrl;
                await dbContext.SaveChangesAsync();
                return existingRegion;
            }
            return null; 
        }
    }
}
