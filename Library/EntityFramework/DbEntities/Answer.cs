using System;
using System.Collections.Generic;

#nullable disable

namespace Library.EntityFramework.DbEntities
{
    public partial class Answer
    {
        public Answer()
        {
            QuestionAnswers = new HashSet<QuestionAnswer>();
        }

        public int AnswerId { get; set; }
        public string Text { get; set; }

        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
