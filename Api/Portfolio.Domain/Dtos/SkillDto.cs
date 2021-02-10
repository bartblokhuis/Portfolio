using Portfolio.Domain.Dtos.Common;

namespace Portfolio.Domain.Dtos
{
    public class SkillDto : IBaseDto
    {
        #region Properties

        public string Name { get; set; }

        public string IconPath { get; set; }

        public int DisplayNumber { get; set; }

        public int SkillGroupId { get; set; }

        #endregion
    }
}
