using Library.EntityFramework.DbEntities;
using System;
using System.Linq.Expressions;

namespace Library.DTOs
{
    public class CourseDTO
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static Expression<Func<Course, CourseDTO>> MapEntity = s => new CourseDTO()
        {
            CourseID = s.CourseId,
            Name = s.Name,
            Description = s.Description
        };
    }
}
