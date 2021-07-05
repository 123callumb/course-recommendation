using Library.EntityFramework.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Library.DTOs
{
    public class GroupDTO
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SectionDTO> Sections { get; set; }

        public static Expression<Func<Group, GroupDTO>> MapEntity = s => new GroupDTO()
        {
            GroupID = s.GroupId,
            Description = s.Description,
            Name = s.Name,
            Sections = s.Sections.AsQueryable().Select(SectionDTO.MapEntity).ToList()
        };
    }
}
