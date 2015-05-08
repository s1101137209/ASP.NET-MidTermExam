
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{
    public class CourseDao : GenericDao<Course>, ICourseDao
    {

        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course course)
        {
            string command = @"INSERT INTO Course (ID, NAME, Description) VALUES (@Id, @Name, @Description);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = course.ID;
            parameters.Add("Name", DbType.String).Value = course.NAME;
            parameters.Add("Description", DbType.String).Value = course.Description;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateCourse(Course course)
        {
            string command = @"UPDATE Course SET NAME = @Name, Description = @Description WHERE ID = @Id;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = course.ID;
            parameters.Add("Name", DbType.String).Value = course.NAME;
            parameters.Add("Description", DbType.String).Value = course.Description;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteCourse(Course course)
        {
            string command = @"DELETE FROM Course WHERE ID = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = course.ID;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Course> GetAllCourses()
        {
            string command = @"SELECT * FROM Course ORDER BY Id ASC";
            IList<Course> courses = ExecuteQueryWithRowMapper(command);
            return courses;
        }

        public Course GetCourseById(string id)
        {
            string command = @"SELECT * FROM Course WHERE ID = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = id;

            IList<Course> courses = ExecuteQueryWithRowMapper(command, parameters);
            if (courses.Count > 0)
            {
                return courses[0];
            }

            return null;
        }

    }
}
