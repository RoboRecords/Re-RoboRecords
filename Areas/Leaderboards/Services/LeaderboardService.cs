using AutoMapper;
using ReRoboRecords.Areas.Games.Data;
using ReRoboRecords.Areas.Leaderboards.Data;
using ReRoboRecords.Areas.Leaderboards.Interfaces;
using ReRoboRecords.Areas.Leaderboards.ViewModels;

namespace ReRoboRecords.Areas.Leaderboards.Services;

public class LeaderboardService : ILeaderboardService
{
    private readonly IGameRepository _gameRepository;
    private readonly IRunRepository _runRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public LeaderboardService(
        IGameRepository gameRepository,
        IRunRepository runRepository,
        ICategoryRepository categoryRepository,
        IMapper mapper
    )
    {
        _gameRepository = gameRepository;
        _runRepository = runRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<LeaderboardViewModel> GetViewModelAsync(string gameName)
    {
        var viewModel = new LeaderboardViewModel
        {
            GameName = gameName,
            Runs = new List<RunViewModel>(),
            Categories = new List<CategoryViewModel>()
        };


        var game = await _gameRepository.GetGameByNameAsync(gameName);
        
        if (game != null)
        {
            viewModel.GameName = game.GameName;
            
            var runs = await _runRepository.GetRunsByGameIdAsync(game.GameId);
            viewModel.Runs = _mapper.Map<List<RunViewModel>>(runs);

            var categories = await _categoryRepository.GetCategoriesByGameIdAsync(game.GameId);
            viewModel.Categories = _mapper.Map<List<CategoryViewModel>>(categories);
            
        }

        return viewModel;
    }
}