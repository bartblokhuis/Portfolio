using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Domain.Dtos;

namespace Portfolio.Core.Interfaces
{
    public interface ISkillGroupService
    {
        Task<IEnumerable<SkillGroupDto>> GetAll();

        Task Insert(SkillGroupDto skillGroupDto);

        Task Update(SkillGroupDto skillGroupDto);

        Task Update(IEnumerable<SkillGroupDto> skillGroupDto);

        Task Delete(int id);

        Task<bool> IsExistingTitle(string title, int idToIgnore = 0);

        Task<bool> Exists(int id);
    }
}
