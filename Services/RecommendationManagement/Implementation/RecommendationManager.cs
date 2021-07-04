using Library.DTOs;
using Microsoft.EntityFrameworkCore;
using Services.GenericRepository;
using System.Threading.Tasks;

namespace Services.RecommendationManagement.Implementation
{
    public class RecommendationManager : IRecommendationManager
    {
        private readonly IGenericQuerier _genericQuerier;
        public RecommendationManager(IGenericQuerier genericQuerier)
        {
            _genericQuerier = genericQuerier;
        }

        public async Task<CourseDTO> RecommendCourse(int sessionID)
        {
            // TODO: Need an algorthm that recommedns a course based on the answer scores and their respective categories
            return await _genericQuerier.Load(CourseDTO.MapEntity).FirstOrDefaultAsync();
        }
    }
}
