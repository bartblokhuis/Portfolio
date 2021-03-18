using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Core.Interfaces;
using Portfolio.Domain.Dtos;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AboutMeController : ControllerBase
    {
        #region Fields

        private readonly ILogger<AboutMeController> _logger;
        private readonly IAboutMeService _aboutMeService;

        #endregion

        #region Constructor

        public AboutMeController(ILogger<AboutMeController> logger, IAboutMeService aboutMeService)
        {
            _logger = logger;
            _aboutMeService = aboutMeService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public Task<AboutMeDto> Get()
        {
            return _aboutMeService.GetAboutMe();
        }

        [HttpPost]
        public Task Save(AboutMeDto model)
        {
            return _aboutMeService.SaveAboutMe(model);
        }

        #endregion
    }
}
