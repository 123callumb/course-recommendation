using Library.DTOs;
using System.Collections.Generic;

namespace Library.Models.Home.Responses
{
    public class HomeLoadResponse
    {
        public HomeLoadResponse(List<SessionAnswerDTO> sessionAnswers, List<SectionDTO> sections)
        {
            SessionAnswerSets = sessionAnswers;
            Sections = sections;
        }
        public List<SessionAnswerDTO> SessionAnswerSets { get; set; }
        public List<SectionDTO> Sections { get; set; }
    }
}
