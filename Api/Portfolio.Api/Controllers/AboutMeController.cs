using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Domain.Dtos;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AboutMeController : ControllerBase
    {
        #region Fields

        private readonly ILogger<AboutMeController> _logger;

        #endregion

        #region Constructor

        public AboutMeController(ILogger<AboutMeController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IEnumerable<AboutMeDto> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new AboutMeDto())
                .ToArray();
        }

        #endregion
    }
}
