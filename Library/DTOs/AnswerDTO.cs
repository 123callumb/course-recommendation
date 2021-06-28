using Library.EntityFramework.DbEntities;
using System;
using System.Linq.Expressions;

namespace Library.DTOs
{
    public class AnswerDTO
    {
        public int AnswerID { get; set; }
        public string Text { get; set; }

        public static Expression<Func<Answer, AnswerDTO>> MapEntity = s => new AnswerDTO()
        {
            AnswerID = s.AnswerId,
            Text = s.Text
        };
    }
}
