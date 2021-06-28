using Library.EntityFramework.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Library.DTOs
{
    public class QuestionDTO
    {
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public int? Order { get; set; }
        public QuestionGroupDTO QuestionGroup { get; set; }
        public List<AnswerDTO> Answers { get; set; }

        public static Expression<Func<Question, QuestionDTO>> MapEntity = s => new QuestionDTO
        {
            QuestionID = s.QuestionId,
            Text = s.Text,
            Order = s.Order,
            //QuestionGroup = QuestionGroupDTO.MapEntityOverview.Compile().Invoke(s.Group)//,
            Answers = s.QuestionAnswers.Select(s => s.Answer).AsQueryable().Select(AnswerDTO.MapEntity).ToList()
        };
    }
}
