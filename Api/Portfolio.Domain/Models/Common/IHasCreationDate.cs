using System;

namespace Portfolio.Domain.Models.Common
{
    public interface IHasCreationDate
    {
        public DateTime CreatedAtUTC { get; set; }
    }
}
