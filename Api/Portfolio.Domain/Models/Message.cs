using System;
using Portfolio.Domain.Enums;
using Portfolio.Domain.Models.Common;

namespace Portfolio.Domain.Models
{
    public class Message : BaseEntity, IFullyAudited
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
