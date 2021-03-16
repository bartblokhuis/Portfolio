using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Dtos
{
    public class UpdateSkillDto : SkillDto
    {
        [Required]
        public override int Id { get => base.Id; set => base.Id = value; }
    }
}
