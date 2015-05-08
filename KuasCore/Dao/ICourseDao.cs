using KuasCore.Models;
using System;
using System.Collections.Generic;


namespace KuasCore.Dao
{
    public interface ICourseDao
    {

       void AddCourse(Course course);

       void UpdateCourse(Course course);

       void DeleteCourse(Course course);

       IList<Course> GetAllCourses();

       Course GetCourseById(string id);

    }
}
