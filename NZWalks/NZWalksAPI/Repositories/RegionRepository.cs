using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalkDbContext nZWalkDbContext;
        public RegionRepository(NZWalkDbContext nZWalkDbContext)
        {
            this.nZWalkDbContext = nZWalkDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
           region.Id = Guid.NewGuid();

           await nZWalkDbContext.AddAsync(region);

           await nZWalkDbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await nZWalkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }

            // Delete the Region
             nZWalkDbContext.Regions.Remove(region);
            await nZWalkDbContext.SaveChangesAsync(); 
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
          return await nZWalkDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
           return await nZWalkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

           // return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
           var existingRegion = await nZWalkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await nZWalkDbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
