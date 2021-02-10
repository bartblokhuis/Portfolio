using AutoMapper;
using Portfolio.Domain.Dtos;
using Portfolio.Domain.Models;

namespace Portfolio.Core.AutoMapper
{
    public class PortfolioMappings : Profile
    {
        public PortfolioMappings()
        {
            CreateMap<AboutMe, AboutMeDto>();
            CreateMap<AboutMeDto, AboutMe>();

            CreateMap<Message, MessageDto>();
            CreateMap<MessageDto, Message>();

            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();

            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>();

            CreateMap<SkillGroup, SkillGroupDto>();
            CreateMap<SkillGroupDto, SkillGroup>();
        }
    }
}
