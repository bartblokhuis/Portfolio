using System;

namespace Portfolio.Domain.Models.Common
{
    public interface IHasUpdatedDate
    {
        public DateTime UpdatedAtUtc { get; set; }
    }
}
