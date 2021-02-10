using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Domain.Dtos;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillGroupController : ControllerBase
    {
        #region Fields

        private readonly ILogger<SkillGroupController> _logger;

        #endregion

        #region Constructor

        public SkillGroupController(ILogger<SkillGroupController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IEnumerable<SkillGroupDto> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new SkillGroupDto())
                .ToArray();
        }

        #endregion

    }
}
