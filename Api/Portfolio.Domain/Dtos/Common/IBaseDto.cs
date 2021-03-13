namespace Portfolio.Domain.Dtos.Common
{
    public interface IBaseDto<TKEy>
    {
        public TKEy Id { get; set; }
    }

    public interface IBaseDto : IBaseDto<int>
    {
    }
}
