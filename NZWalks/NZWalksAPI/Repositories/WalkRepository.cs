using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalkDbContext nZWalkDbContext;
        public WalkRepository(NZWalkDbContext nZWalkDbContext)
        {
            this.nZWalkDbContext = nZWalkDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            // Assign New Id
            walk.Id = Guid.NewGuid();
            await nZWalkDbContext.Walks.AddAsync(walk);
            await nZWalkDbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var existingWalk = await nZWalkDbContext.Walks.FindAsync(id);

            if (existingWalk == null)
            {
                return null;
            }

            nZWalkDbContext.Walks.Remove(existingWalk);
            await nZWalkDbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
          return await
                nZWalkDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();
        }

        public Task<Walk> GetAsync(Guid id)
        {
           return nZWalkDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await nZWalkDbContext.Walks.FindAsync(id);
            if (existingWalk != null)
            {
                existingWalk.Name = walk.Name;
                existingWalk.Length = walk.Length;
                existingWalk.RegionId = walk.RegionId;
                existingWalk.WalkDifficultyId = walk.WalkDifficultyId;

               await nZWalkDbContext.SaveChangesAsync();
                return existingWalk;
            }

            return null;
        }
    }
}
