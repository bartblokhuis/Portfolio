using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Domain.Dtos;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        #region Fields

        private readonly ILogger<MessagesController> _logger;

        #endregion

        #region Constructor

        public MessagesController(ILogger<MessagesController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IEnumerable<MessageDto> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new MessageDto())
                .ToArray();
        }

        #endregion
    }
}
