using System;
using System.Collections.Generic;

#nullable disable

namespace Library.EntityFramework.DbEntities
{
    public partial class Session
    {
        public Session()
        {
            SessionAnswers = new HashSet<SessionAnswer>();
        }

        public int SessionId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<SessionAnswer> SessionAnswers { get; set; }
    }
}
