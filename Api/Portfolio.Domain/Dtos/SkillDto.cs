using Microsoft.AspNetCore.Http;
using Portfolio.Domain.Dtos.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Dtos
{
    public class SkillDto : BaseDto
    {
        #region Properties

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string IconPath { get; set; }

        [Required]
        public int DisplayNumber { get; set; }

        [Required]
        public int SkillGroupId { get; set; }

        public IFormFile Icon { get; set; }

        public ICollection<ProjectDto> Skills { get; set; }

        #endregion
    }
}
