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
        public int GroupID { get; set; }

        public static Expression<Func<SessionAnswer, SessionAnswerDTO>> MapEntity = s => new SessionAnswerDTO()
        {
            SessionAnswerID = s.SessionAnswerId,
            SectionID = s.SectionId,
            AnswerID = s.AnswerId,
            QuestionID = s.QuestionId,
            GroupID = s.Section.GroupId
        };

        public static Expression<Func<SessionAnswerDTO, SessionAnswer>> ToEntity = s => new SessionAnswer()
        {
            SectionId = s.SectionID,
            AnswerId = s.AnswerID,
            QuestionId = s.QuestionID
        };
    }
}
