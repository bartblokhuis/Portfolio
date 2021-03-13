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
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public SkillGroupService(IBaseRepository<SkillGroup, SkillGroupDto> skillGroupRepository, IMapper mapper)
        {
            _skillGroupRepository = skillGroupRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<SkillGroupDto>> GetAll()
        {
            var skillGroups = await _skillGroupRepository.Table
                .OrderByDescending(skillGroup => skillGroup.DisplayNumber).ToListAsync();

            return _mapper.Map<IEnumerable<SkillGroupDto>>(skillGroups);

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

        public Task<bool> IsUniqueTitle(string title, int idToIgnore = 0)
        {
            return _skillGroupRepository.Table.AllAsync(skillGroup => skillGroup.Title.ToLower() != title.ToLower()
                        && skillGroup.Id != idToIgnore);
        }

        public Task<bool> Exists(int id)
        {
            return _skillGroupRepository.Table.AnyAsync(skillGroup => skillGroup.Id == id);
        }

        #endregion

        #endregion
    }
}
