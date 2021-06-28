using System;
using System.Collections.Generic;

#nullable disable

namespace Library.EntityFramework.DbEntities
{
    public partial class QuestionGroup
    {
        public QuestionGroup()
        {
            Questions = new HashSet<Question>();
        }

        public int QuestionGroupId { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
