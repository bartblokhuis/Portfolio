using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Core.Interfaces;
using Portfolio.Domain.Dtos;
using Portfolio.Helpers;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {
        #region Fields

        private readonly ILogger<SkillController> _logger;
        private readonly ISkillService _skillService;
        private readonly ISkillGroupService _skillGroupService;
        private readonly IUploadImageHelper _uploadImageHelper;

        #endregion

        #region Constructor

        public SkillController(ILogger<SkillController> logger, ISkillService skillService, ISkillGroupService skillGroupService, IUploadImageHelper uploadImageHelper)
        {
            _logger = logger;
            _skillService = skillService;
            _skillGroupService = skillGroupService;
            _uploadImageHelper = uploadImageHelper;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IEnumerable<SkillDto>> Get()
        {
            return await _skillService.GetAll();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]SkillDto model)
        {
            model.Id = 0;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.Icon == null)
                return BadRequest("An icon file must be provided when creating a new skill");

            var errorMessage = _uploadImageHelper.ValidateImage(model.Icon);
           
            if (!string.IsNullOrEmpty(errorMessage))
                return BadRequest(errorMessage);

            model.IconPath = await _uploadImageHelper.UploadImage(model.Icon);

            if(await _skillService.IsExistingSkill(model.Name, model.SkillGroupId))
                return BadRequest("Skill with the same name already exists");

            if (!await _skillGroupService.Exists(model.SkillGroupId))
                return BadRequest("Skill group not found");

            await _skillService.Insert(model);
            return Ok();
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(UpdateSkillDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _skillService.Exists(model.Id))
                return BadRequest("Skill not found");

            if (await _skillService.IsExistingSkill(model.Name, model.SkillGroupId))
                return BadRequest("Skill with the same name already exists");

            if (!await _skillGroupService.Exists(model.SkillGroupId))
                return BadRequest("Skill group not found");

            if (model.Icon == null && string.IsNullOrEmpty(model.IconPath))
                return BadRequest("Either an icon file or an existing icon path is required");

            if (model.Icon != null)
            {
                var errorMessage = _uploadImageHelper.ValidateImage(model.Icon);

                if (!string.IsNullOrEmpty(errorMessage))
                    return BadRequest(errorMessage);

                model.IconPath = await _uploadImageHelper.UploadImage(model.Icon);
            }

            await _skillService.Update(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _skillService.Exists(id))
                return BadRequest("Skill not found");

            await _skillService.Delete(id);

            return Ok();
        }

        #endregion

    }
}
