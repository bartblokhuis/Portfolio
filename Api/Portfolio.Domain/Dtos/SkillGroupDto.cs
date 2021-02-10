using Portfolio.Domain.Dtos.Common;

namespace Portfolio.Domain.Dtos
{
    public class SkillGroupDto : IBaseDto
    {
        #region Properties

        public string Title { get; set; }

        public int DisplayNumber { get; set; }

        #endregion
    }
}
