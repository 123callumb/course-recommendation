using Library.DTOs;
using System.Collections.Generic;

namespace Library.Models.Session
{
    public class UserSession
    {
        public int SessionID { get; set; }
        public List<SessionAnswerDTO> AnswerSet { get; set; }
    }
}
