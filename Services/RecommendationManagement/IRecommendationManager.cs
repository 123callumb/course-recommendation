using Library.DTOs;
using System.Threading.Tasks;

namespace Services.RecommendationManagement
{
    public interface IRecommendationManager
    {
        Task<CourseDTO> RecommendCourse(int sessionID);
    }
}
