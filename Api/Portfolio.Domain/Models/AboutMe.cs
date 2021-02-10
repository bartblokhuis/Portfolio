using Portfolio.Domain.Models.Common;

namespace Portfolio.Domain.Models
{
    public class AboutMe : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
