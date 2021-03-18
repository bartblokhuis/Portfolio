using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Interfaces;
using Portfolio.Core.Interfaces.Common;
using Portfolio.Domain.Dtos;
using Portfolio.Domain.Models;

namespace Portfolio.Core.Services
{
    public class SkillGroupService : ISkillGroupService
    {

        #region Fields

        private readonly IBaseRepository<SkillGroup, SkillGroupDto> _skillGroupRepository;

        #endregion

        #region Constructor

        public SkillGroupService(IBaseRepository<SkillGroup, SkillGroupDto> skillGroupRepository)
        {
            _skillGroupRepository = skillGroupRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<SkillGroupDto>> GetAll()
        {
            var skillGroups = await _skillGroupRepository.GetAsync(orderBy: (s) => s.OrderBy(x => x.DisplayNumber));
            return skillGroups;
        }

        public async Task Insert(SkillGroupDto skillGroupDto)
        {
            await _skillGroupRepository.InsertAsync(skillGroupDto);
        }

        public Task Update(SkillGroupDto skillGroupDto)
        {
            return _skillGroupRepository.UpdateAsync(skillGroupDto);

        }

        public Task Update(IEnumerable<SkillGroupDto> skillGroupsDto)
        {
            return _skillGroupRepository.UpdateRangeAsync(skillGroupsDto);
        }
        
        public Task Delete(int id)
        {
            return _skillGroupRepository.DeleteAsync(id);
        }

        #region Utils

        public Task<bool> IsExistingTitle(string title, int idToIgnore = 0)
        {
            return _skillGroupRepository.Table.AnyAsync(skillGroup => skillGroup.Title.ToLower() == title.ToLower() 
                    && (idToIgnore == 0 || skillGroup.Id == idToIgnore));
        }

        public Task<bool> Exists(int id)
        {
            return _skillGroupRepository.Table.AnyAsync(skillGroup => skillGroup.Id == id);
        }

        #endregion

        #endregion
    }
}
