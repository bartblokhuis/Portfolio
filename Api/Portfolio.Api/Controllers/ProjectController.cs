using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Domain.Dtos;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        #region Fields

        private readonly ILogger<ProjectController> _logger;

        #endregion

        #region Constructor

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IEnumerable<ProjectDto> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new ProjectDto())
                .ToArray();
        }

        #endregion
    }
}
