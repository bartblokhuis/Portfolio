using Portfolio.Domain.Dtos.Common;

namespace Portfolio.Domain.Dtos
{
    public class AboutMeDto : IBaseDto
    {
        #region Properties

        public string Title { get; set; }

        public string Content { get; set; }

        #endregion
    }
}
