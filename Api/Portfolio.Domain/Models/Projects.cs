using System;
using Portfolio.Domain.Models.Common;

namespace Portfolio.Domain.Models
{
    public class Projects : BaseEntity, IHasDisplayNumber
    {
        #region Properties

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public bool IsPublished { get; set; }

        public string DemoUrl { get; set; }

        public string GithubUrl { get; set; }

        public int DisplayNumber { get; set; }

        #endregion
    }
}
