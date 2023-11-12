using Microsoft.EntityFrameworkCore;
using ReRoboRecords.Areas.Games.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReRoboRecords.Data;

namespace ReRoboRecords.Areas.Games.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int gameId)
        {
            return await _context.Games.FirstOrDefaultAsync(g => g.GameId == gameId);
        }
        
        public async Task<Game> GetGameByNameAsync(string gameName)
        {
            return await _context.Games.FirstOrDefaultAsync(g => g.GameName == gameName);
        }

        public async Task<Game> AddGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game> UpdateGameAsync(Game game)
        {
            var gameToUpdate = await _context.Games.FirstOrDefaultAsync(g => g.GameId == game.GameId);
            if (gameToUpdate != null)
            {
                gameToUpdate.GameName = game.GameName;
                gameToUpdate.Description = game.Description;


                _context.Games.Update(gameToUpdate);
                await _context.SaveChangesAsync();
            }
            return gameToUpdate;
        }

        public async Task DeleteGameAsync(int gameId)
        {
            var gameToDelete = await _context.Games.FirstOrDefaultAsync(g => g.GameId == gameId);
            if (gameToDelete != null)
            {
                _context.Games.Remove(gameToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}