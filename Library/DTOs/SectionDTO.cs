using Library.EntityFramework.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Library.DTOs
{
    public class SectionDTO
    {
        public int SectionID { get; set; }
        public string Text { get; set; }
        public List<QuestionDTO> Questions { get; set; }
        public List<AnswerDTO> Answers { get; set; }

        public static Expression<Func<Section, SectionDTO>> MapEntity = s => new SectionDTO
        {
            SectionID = s.SectionId,
            Text = s.Text,
            Questions = s.Questions.AsQueryable().Select(QuestionDTO.MapEntity).ToList(),
            Answers = s.Answers.AsQueryable().Select(AnswerDTO.MapEntity).ToList()
        };
    }
}
