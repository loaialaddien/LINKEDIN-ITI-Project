using ITI.Mvc.LinkedIn.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.ViewModels
{
    public class CourseViewModel
    {
       public List<Courses> Mycourses { get; set; }
        public string UserId { get; set; }
        public Courses course { get; set; }
    }
}