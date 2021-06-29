using System;
using System.Collections.Generic;

#nullable disable

namespace Library.EntityFramework.DbEntities
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public int SectionId { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }

        public virtual Section Section { get; set; }
    }
}
