using System.Threading.Tasks;

namespace Services.AnswerSetManagement
{
    public interface IAnswerSetManager
    {
        void SetAnswerSet(int sectionID, int answerID, int? questionID);
        Task<int> SaveSessionAnswers();
    }
}
