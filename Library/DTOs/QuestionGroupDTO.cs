using Library.EntityFramework.DbEntities;
using System;
using System.Linq.Expressions;

namespace Library.DTOs
{
    public class QuestionGroupDTO
    {
        public int QuestionGroupID { get; set; }
        public string Text { get; set; }
        public static Expression<Func<QuestionGroup, QuestionGroupDTO>> MapEntityOverview = s => new QuestionGroupDTO
        {
            QuestionGroupID = s.QuestionGroupId,
            Text = s.Text
        };
    }
}
