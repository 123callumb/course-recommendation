namespace Library.Models.Requests
{
    public class AnswerSetRequest
    {
        public int SectionID { get; set; }
        public int AnswerID { get; set; }
        public int? QuestionID { get; set; }
        public int GroupID { get; set; }
    }
}
