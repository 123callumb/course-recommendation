using System;
using System.Collections.Generic;

#nullable disable

namespace Library.EntityFramework.DbEntities
{
    public partial class SessionAnswer
    {
        public int SessionAnswerId { get; set; }
        public int SessionId { get; set; }
        public int SectionId { get; set; }
        public int AnswerId { get; set; }
        public int? QuestionId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Question Question { get; set; }
        public virtual Section Section { get; set; }
        public virtual Session Session { get; set; }
    }
}
