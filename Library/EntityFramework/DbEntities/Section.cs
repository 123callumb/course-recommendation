using System;
using System.Collections.Generic;

#nullable disable

namespace Library.EntityFramework.DbEntities
{
    public partial class Section
    {
        public Section()
        {
            Answers = new HashSet<Answer>();
            Questions = new HashSet<Question>();
        }

        public int SectionId { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
