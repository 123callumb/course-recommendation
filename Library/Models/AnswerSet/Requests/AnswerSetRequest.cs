namespace Library.Models.AnswerSet.Requests
{
    public class AnswerSetRequest
    {
        public int SectionID { get; set; }
        public int AnswerID { get; set; }
        public int? QuestionID { get; set; }
    }
}
