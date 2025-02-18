using SampleREST.Services.Models;

namespace SampleREST.Services.DAL
{
    public interface ICourse
    {
        IEnumerable<ViewCourseWithCategory> GetAllCourse();
        IEnumerable<Course> GetAllCourses();
    }
}
