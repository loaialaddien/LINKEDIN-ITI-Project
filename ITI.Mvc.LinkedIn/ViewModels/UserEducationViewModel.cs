using ITI.Mvc.LinkedIn.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.ViewModels
{
    public class UserEducationViewModel
    {
        
        public List<Faculty> Faculties { get; set; }
        public List<University> Universities { get; set; }
        public UserEducation Myeducation { get; set; }



    }
}