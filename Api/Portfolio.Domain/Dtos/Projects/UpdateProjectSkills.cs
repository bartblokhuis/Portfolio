namespace Portfolio.Domain.Dtos.Projects
{
    public class UpdateProjectSkills
    {
        public int ProjectId { get; set; }

        public int[] SkillIds { get; set; }
    }
}
