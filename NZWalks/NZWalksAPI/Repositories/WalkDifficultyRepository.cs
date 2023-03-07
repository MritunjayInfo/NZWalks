using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalkDbContext nZWalkDbContext;
        public WalkDifficultyRepository(NZWalkDbContext nZWalkDbContext)
        {
            this.nZWalkDbContext = nZWalkDbContext;
        }
        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
           walkDifficulty.Id = Guid.NewGuid();
            await nZWalkDbContext.WalksDifficulty.AddAsync(walkDifficulty);
            await nZWalkDbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var existingWalkDifficulty = await nZWalkDbContext.WalksDifficulty.FindAsync(id);
            if (existingWalkDifficulty != null)
            {
                nZWalkDbContext.WalksDifficulty.Remove(existingWalkDifficulty);
                await nZWalkDbContext.SaveChangesAsync();
                return existingWalkDifficulty;
            }
            return null;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await nZWalkDbContext.WalksDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await nZWalkDbContext.WalksDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await nZWalkDbContext.WalksDifficulty.FindAsync(id);

            if (existingWalkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code  = walkDifficulty.Code;
            await nZWalkDbContext.SaveChangesAsync();
            return existingWalkDifficulty;
        }
    }
}
