using System;
using System.Collections.Generic;

#nullable disable

namespace Library.EntityFramework.DbEntities
{
    public partial class Question
    {
        public Question()
        {
            QuestionAnswers = new HashSet<QuestionAnswer>();
        }

        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int? Order { get; set; }
        public int? GroupId { get; set; }

        public virtual QuestionGroup Group { get; set; }
        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
