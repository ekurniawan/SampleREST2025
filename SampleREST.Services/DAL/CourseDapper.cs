using Dapper;
using Microsoft.Data.SqlClient;
using SampleREST.Services.Models;

namespace SampleREST.Services.DAL
{
    public class CourseDapper : ICourse
    {
        private readonly IConfiguration _configuration;
        public CourseDapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("MyDbConnection");
        }

        public IEnumerable<ViewCourseWithCategory> GetAllCourse()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from ViewCourseWithCategory
                                  order by Name asc";
                var results = conn.Query<ViewCourseWithCategory>(strSql);
                return results;
            }
        }

        public IEnumerable<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"SELECT dbo.Courses.CourseId, dbo.Courses.Name, dbo.Courses.ImageName, dbo.Courses.Duration, dbo.Courses.Description,dbo.Categories.CategoryId, dbo.Categories.Name, dbo.Categories.Description
                                  FROM dbo.Categories INNER JOIN
                                  dbo.Courses ON dbo.Categories.CategoryId = dbo.Courses.CategoryId";
                //mapping join in dapper
                /*var results = conn.Query<Course, Category, Course>(strSql, (course, category) =>
                {
                    course.Category = category;
                    return course;
                }, splitOn: "CategoryId");

                return results;*/


                SqlCommand sqlCommand = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Course course = new Course();
                    course.CourseId = reader.GetInt32(0);
                    course.Name = reader.GetString(1);
                    //course.ImageName = reader.GetString(2);
                    //course.Duration = reader.GetDouble(3);
                    //course.Description = reader.GetString(4);
                    course.CategoryId = reader.GetInt32(5);
                    Category category = new Category();
                    category.CategoryId = reader.GetInt32(5);
                    category.Name = reader.GetString(6);
                    category.Description = reader.GetString(7);
                    course.Category = category;
                    courses.Add(course);
                }

                reader.Close();
                sqlCommand.Dispose();
                conn.Close();
            }
            return courses;
        }
    }
}
