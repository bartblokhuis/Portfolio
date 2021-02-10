using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Models.Common
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        [Key]
        public virtual TKey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>, IBaseEntity
    {
    }
}
