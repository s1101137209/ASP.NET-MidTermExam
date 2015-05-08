using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class CourseController : ApiController
    {

        public ICourseService CourseService { get; set; }


        [HttpPost]
        public Course AddCourse(Course course)
        {
            CheckCourseIsNotNullThrowException(course);
            try
            {
                CourseService.AddCourse(course);
                return CourseService.GetCourseById(course.ID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Course> GetAllCourses()
        {
            return CourseService.GetAllCourses();
        }
        [HttpGet]
        [ActionName("ByName")]
        public Course GetCourseByName(string name)
        {
            return CourseService.GetCourseByName(name);
        }
        [HttpGet]
        [ActionName("ById")]
        public Course GetCourseById(string id)
        {
            return CourseService.GetCourseById(id);
        }
        //
        private void CheckCourseIsNotNullThrowException(Course course)
        {
            Course dbCourse = CourseService.GetCourseById(course.ID);

            if (dbCourse != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }
    }
}