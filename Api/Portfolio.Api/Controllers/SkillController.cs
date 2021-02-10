using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Domain.Dtos;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {
        #region Fields

        private readonly ILogger<SkillController> _logger;

        #endregion

        #region Constructor

        public SkillController(ILogger<SkillController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IEnumerable<SkillDto> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new SkillDto())
                .ToArray();
        }

        #endregion

    }
}
