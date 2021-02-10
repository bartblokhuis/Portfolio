using Portfolio.Domain.Models.Common;

namespace Portfolio.Domain.Models
{
    public class Skill : BaseEntity, IHasDisplayNumber
    {
        #region Properties

        public string Name { get; set; }

        public string IconPath { get; set; }

        public int DisplayNumber { get; set; }

        public int SkillGroupId { get; set; }

        #endregion
    }
}
