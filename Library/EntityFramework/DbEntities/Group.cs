using System;
using System.Collections.Generic;

#nullable disable

namespace Library.EntityFramework.DbEntities
{
    public partial class Group
    {
        public Group()
        {
            Sections = new HashSet<Section>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}
