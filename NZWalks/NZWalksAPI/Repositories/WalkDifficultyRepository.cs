using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        public Task<WalkDifficulty> AddAsync(WalkDifficulty walk)
        {
            throw new NotImplementedException();
        }

        public Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WalkDifficulty> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walk)
        {
            throw new NotImplementedException();
        }
    }
}
