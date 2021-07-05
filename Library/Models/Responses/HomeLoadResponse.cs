using Library.DTOs;
using System.Collections.Generic;

namespace Library.Models.Responses
{
    public class HomeLoadResponse
    {
        public HomeLoadResponse(List<SessionAnswerDTO> sessionAnswers, List<GroupDTO> groups)
        {
            SessionAnswerSets = sessionAnswers;
            Groups = groups;
        }
        public List<SessionAnswerDTO> SessionAnswerSets { get; set; }
        public List<GroupDTO> Groups { get; set; }
    }
}
