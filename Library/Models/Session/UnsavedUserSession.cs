using Library.DTOs;
using System.Collections.Generic;

namespace Library.Models.Session
{
    public class UnsavedUserSession
    {
        public string SessionCode { get; set; }
        public List<SessionAnswerDTO> AnswerSet { get; set; }
    }
}
