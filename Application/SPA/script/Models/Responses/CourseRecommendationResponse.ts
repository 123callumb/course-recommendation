import Course from "../Course";

export default interface CourseRecommendationResponse {
    SessionID: number;
    RecommendedCourse: Course;
}