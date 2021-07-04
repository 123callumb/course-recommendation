using Library.DTOs;

namespace Library.Models.Responses
{
    public class CourseRecommendationResponse
    {
        public CourseRecommendationResponse(int sessionID, CourseDTO course)
        {
            SessionID = sessionID;
            RecommendedCourse = course;
        }
        public int SessionID { get; set; }
        public CourseDTO RecommendedCourse { get; set; }
    }
}
