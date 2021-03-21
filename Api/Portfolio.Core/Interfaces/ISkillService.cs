using Portfolio.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Core.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillDto>> GetAll();

        Task Insert(SkillDto skillDto);

        Task Update(SkillDto skillDto);

        Task Delete(int id);

        Task<bool> Exists(int id);

        Task<bool> IsExistingSkill(string name, int skillGroup, int idToIgnore = 0);

        Task<IEnumerable<SkillDto>> GetSkillsByIds(IEnumerable<int> ids);
    }
}
