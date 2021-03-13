using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Core.Interfaces;
using Portfolio.Domain.Dtos;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillGroupController : ControllerBase
    {
        #region Fields

        private ILogger<SkillGroupController> _logger;
        private readonly ISkillGroupService _skillGroupService;

        #endregion

        #region Constructor

        public SkillGroupController(ILogger<SkillGroupController> logger, ISkillGroupService skillGroupService)
        {
            _logger = logger;
            _skillGroupService = skillGroupService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IEnumerable<SkillGroupDto>> Get()
        {
            return await _skillGroupService.GetAll();
        }
 
        [HttpPost]
        public async Task<IActionResult> Create(SkillGroupDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _skillGroupService.IsUniqueTitle(model.Title))
                return BadRequest("There is already a skill group with the same title");

            await _skillGroupService.Insert(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(SkillGroupDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _skillGroupService.Exists(model.Id))
                 return BadRequest($"No skill group for id: {model.Id} found");

            if (!await _skillGroupService.IsUniqueTitle(model.Title, model.Id))
                return BadRequest("There is already a skill group with the same title");

            await _skillGroupService.Update(model);
            return Ok();
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _skillGroupService.Exists(id))
                return BadRequest($"No skill group for id: {id} found");

            await _skillGroupService.Delete(id);

            return Ok();
        }

        #endregion

    }
}
