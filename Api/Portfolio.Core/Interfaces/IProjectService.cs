using Portfolio.Domain.Dtos;
using Portfolio.Domain.Dtos.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> Get();

        Task<ProjectDto> Create(ProjectDto model);

        Task<ProjectDto> Update(ProjectDto model);

        Task<ProjectDto> UpdateSkills(int projectId, IEnumerable<SkillDto> skills);

        Task Delete(int id);

    }
}
