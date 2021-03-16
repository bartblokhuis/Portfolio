using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Interfaces;
using Portfolio.Core.Interfaces.Common;
using Portfolio.Domain.Dtos;
using Portfolio.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Core.Services
{
    public class SkillService : ISkillService
    {
        #region Fields

        private readonly IBaseRepository<Skill, SkillDto> _skillRepository;

        #endregion

        #region Constructor

        public SkillService(IBaseRepository<Skill, SkillDto> skillRepository)
        {
            _skillRepository = skillRepository;
        }

        #endregion

        #region Methods

        public Task Delete(int id)
        {
            return _skillRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<SkillDto>> GetAll()
        {
            return _skillRepository.GetAsync(orderBy: (s) => s.OrderBy(skill => skill.SkillGroupId).ThenBy(skill => skill.DisplayNumber));
        }

        public Task Insert(SkillDto skillDto)
        {
            return _skillRepository.InsertAsync(skillDto);
        }

        public Task Update(SkillDto skillDto)
        {
            return _skillRepository.UpdateAsync(skillDto);
        }

        #region Utils

        public Task<bool> Exists(int id)
        {
            return _skillRepository.Table.AnyAsync(skill => skill.Id == id);
        }

        public Task<bool> IsExistingSkill(string name, int skillGroupId, int idToIgnore = 0)
        {
            return _skillRepository.Table.AnyAsync(skill => skill.Name.ToLower() == name.ToLower() && skill.SkillGroupId == skillGroupId
                    && (idToIgnore == 0 || skill.Id == idToIgnore));
        }

        #endregion

        #endregion
    }
}
