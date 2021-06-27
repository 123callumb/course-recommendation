using Library.EntityFramework.DbEntities;
using System;
using System.Linq.Expressions;

namespace Library.DTOs
{
    public class QuestionDTO
    {
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public int? Order { get; set; }
        public static Expression<Func<Question, QuestionDTO>> MapEntity = s => new QuestionDTO
        {
            QuestionID = s.QuestionId,
            Text = s.Text
        };
    }
}
