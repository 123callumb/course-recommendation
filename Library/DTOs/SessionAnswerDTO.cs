using Library.EntityFramework.DbEntities;
using System;
using System.Linq.Expressions;

namespace Library.DTOs
{
    public class SessionAnswerDTO
    {
        public int SessionAnswerID { get; set; }
        public int SectionID { get; set; }
        public int AnswerID { get; set; }
        public int? QuestionID { get; set; }

        public static Expression<Func<SessionAnswer, SessionAnswerDTO>> MapEntity = s => new SessionAnswerDTO()
        {
            SessionAnswerID = s.SessionAnswerId,
            SectionID = s.SectionId,
            AnswerID = s.AnswerId,
            QuestionID = s.QuestionId
        };
    }
}
