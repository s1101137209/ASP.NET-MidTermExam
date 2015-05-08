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
        public Course GetCourseById(string id)
        {
            return CourseService.GetCourseById(id);
        }
        

    }
}