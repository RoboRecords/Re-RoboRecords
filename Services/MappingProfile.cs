using ReRoboRecords.Areas.Games.Models;
using ReRoboRecords.Areas.Games.ViewModels;
using ReRoboRecords.Areas.Leaderboards.Models;
using ReRoboRecords.Areas.Leaderboards.ViewModels;

namespace ReRoboRecords.Services
{
    using AutoMapper;
    
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Run, RunViewModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time))
                .ForMember(dest => dest.CharacterName, opt => opt.MapFrom(src => src.Character.Name))
                .ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.Level.Name))
                .ForMember(dest => dest.DateSubmitted, opt => opt.MapFrom(src => src.DateSubmitted))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl));
            
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Game, DisplayGameViewModel>()
                .ForMember(dest => dest.GameName, opt => opt.MapFrom(src => src.GameName))
                .ForMember(dest => dest.GameDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.GameIconUrl, opt => opt.MapFrom(src => src.GameImagePath))
                .ForMember(dest => dest.GameAcronym, opt => opt.MapFrom(src => src.GameAcronym));
        }
    }
}
