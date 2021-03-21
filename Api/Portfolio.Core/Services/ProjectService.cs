using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Interfaces;
using Portfolio.Core.Interfaces.Common;
using Portfolio.Domain.Dtos;
using Portfolio.Domain.Dtos.Projects;
using Portfolio.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Core.Services
{
    public class ProjectService : IProjectService
    {
        #region Fields

        private readonly IBaseRepository<Project, ProjectDto> _projectRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ProjectService(IBaseRepository<Project, ProjectDto> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<ProjectDto>> Get()
        {
            var projects = await _projectRepository.Table.AsQueryable().AsNoTracking().Include(x => x.Skills).ToListAsync();

             return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public Task<ProjectDto> Create(ProjectDto model)
        {
            return _projectRepository.InsertAsync(model);
        }

        public Task<ProjectDto> Update(ProjectDto model)
        {
            return _projectRepository.UpdateAsync(model);
        }

        public async Task<ProjectDto> UpdateSkills(int projectId, IEnumerable<SkillDto> skills)
        {
            var project = _projectRepository.Table.Include(x => x.Skills).FirstOrDefault(x => x.Id == projectId);

            var skillIds = skills.Select(x => x.Id);

            project.Skills ??= new List<Skill>();

            foreach(var skill in project.Skills.Where(x => !skillIds.Contains(x.Id)))
            {
                project.Skills.Remove(skill);
            }

            foreach (var skill in skills.Where(x => project.Skills.All(y => y.Id != x.Id)))
            {
                project.Skills.Add(_mapper.Map<Skill>(skill));
            }

            return await _projectRepository.UpdateAsync(project);
        }

        public Task Delete(int id)
        {
            return _projectRepository.DeleteAsync(id);
        }

        #region Utils

        #endregion

        #endregion
    }
}
