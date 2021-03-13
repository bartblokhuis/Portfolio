using System;
using Portfolio.Domain.Dtos.Common;
using Portfolio.Domain.Enums;

namespace Portfolio.Domain.Dtos
{
    public class MessageDto : BaseDto
    {
        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Content { get; set; }

        public MessageStatus MessageStatus { get; set; }

        public DateTime CreatedAtUTC { get; set; }
        public DateTime UpdatedAtUtc { get; set; }

        #endregion
    }
}
