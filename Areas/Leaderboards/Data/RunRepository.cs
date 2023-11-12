using Microsoft.EntityFrameworkCore;
using ReRoboRecords.Areas.Leaderboards.Models;
using ReRoboRecords.Data;

namespace ReRoboRecords.Areas.Leaderboards.Data
{
    public class RunRepository : IRunRepository
    {
        private readonly ApplicationDbContext _context;

        public RunRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Run>> GetAllRunsAsync()
        {
            return await _context.Runs.ToListAsync();
        }

        public async Task<IEnumerable<Run>> GetRunsByLevelIdAsync(int levelId)
        {
            return await _context.Runs.Where(r => r.LevelId == levelId).ToListAsync();
        }

        public async Task<IEnumerable<Run>> GetRunsByCharacterIdAsync(int characterId)
        {
            return await _context.Runs.Where(r => r.CharacterId == characterId).ToListAsync();
        }

        public async Task<IEnumerable<Run>> GetRunsByPlayerIdAsync(string playerId)
        {
            // Assuming 'UserId' in 'Run' is a string that matches the user's ID
            return await _context.Runs.Where(r => r.UserId == playerId.ToString()).ToListAsync();
        }

        public async Task<IEnumerable<Run>> GetRunsByGameIdAsync(int gameId)
        {
            return await _context.Runs.Where(r => r.GameId == gameId).ToListAsync();
        }

        public async Task<IEnumerable<Run>> GetRunsByCategoryIdAsync(int categoryId)
        {
            return await _context.Runs.Where(r => r.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Run>> GetRunsByCategoryIdAndLevelIdAsync(int categoryId, int levelId)
        {
            return await _context.Runs.Where(r => r.CategoryId == categoryId && r.LevelId == levelId).ToListAsync();
        }

        public async Task<IEnumerable<Run>> GetRunsByCategoryIdAndPlayerIdAsync(int categoryId, string playerId)
        {
            return await _context.Runs.Where(r => r.CategoryId == categoryId && r.UserId == playerId.ToString())
                .ToListAsync();
        }

        public async Task<IEnumerable<Run>> GetRunsByCategoryIdAndGameIdAsync(int categoryId, int gameId)
        {
            return await _context.Runs.Where(r => r.CategoryId == categoryId && r.GameId == gameId).ToListAsync();
        }

        public async Task<Run> GetRunByIdAsync(int runId)
        {
            return await _context.Runs.FindAsync(runId);
        }

        public async Task<Run> AddRunAsync(Run run)
        {
            _context.Runs.Add(run);
            await _context.SaveChangesAsync();
            return run;
        }

        public async Task<Run> UpdateRunAsync(Run run)
        {
            _context.Entry(run).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return run;
        }

        public async Task<Run> DeleteRunAsync(int runId)
        {
            var run = await _context.Runs.FindAsync(runId);
            if (run != null)
            {
                _context.Runs.Remove(run);
                await _context.SaveChangesAsync();
            }

            return run;
        }
    }
}