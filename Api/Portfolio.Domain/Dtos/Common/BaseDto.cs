namespace Portfolio.Domain.Dtos.Common
{
    public abstract class BaseDto<TKey> : IBaseDto<TKey>
    {
        public virtual TKey Id { get; set; }
    }

    public abstract class BaseDto: BaseDto<int>
    {

    }
}
