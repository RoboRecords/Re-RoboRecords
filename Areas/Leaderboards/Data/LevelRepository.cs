using Microsoft.EntityFrameworkCore;
using ReRoboRecords.Areas.Leaderboards.Interfaces;
using ReRoboRecords.Areas.Leaderboards.Models;
using ReRoboRecords.Data;

namespace ReRoboRecords.Areas.Leaderboards.Data
{
    public class LevelRepository : ILevelRepository
    {
        private readonly ApplicationDbContext _context;

        public LevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Level>> GetAllLevelsAsync()
        {
            return await _context.Levels.ToListAsync();
        }

        public async Task<IEnumerable<Level>> GetLevelsByGameIdAsync(int gameId)
        {
            return await _context.Levels
                .Where(level => level.GameId == gameId)
                .ToListAsync();
        }

        public async Task<Level> GetLevelByIdAsync(int levelId)
        {
            return await _context.Levels.FindAsync(levelId);
        }

        public async Task<Level> AddLevelAsync(Level level)
        {
            _context.Levels.Add(level);
            await _context.SaveChangesAsync();
            return level; // The level will have an ID after saving changes.
        }

        public async Task<Level> UpdateLevelAsync(Level level)
        {
            _context.Entry(level).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return level;
        }

        public async Task DeleteLevelAsync(int levelId)
        {
            var level = await _context.Levels.FindAsync(levelId);
            if (level != null)
            {
                _context.Levels.Remove(level);
                await _context.SaveChangesAsync();
            }
        }
    }
}