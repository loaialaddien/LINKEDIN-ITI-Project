using ITI.Mvc.LinkedIn.Models;
using ITI.Mvc.LinkedIn.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITI.Mvc.LinkedIn.Models.Entities
namespace ITI.Mvc.LinkedIn.ViewModels
{
    public class AppUserViewModel
    {

        public ApplicationUser User { get; set; }


       
        public List<UserEducation> EducationList { get; set; }


        public List<Language> Languages { get; set; }

     
        public List<ProfilePictures> Pictures { get; set; }
       

        public List<Skills> Skills { get; set; }
 

        public List<Courses> Courses { get; set; }





        public List<Friends> Friends { get; set; }
  

        public List<Posts> Posts { get; set; }


        public List<Notification> Notifications { get; set; }
        

        public List<Comments> Comments { get; set; }
        public List<Company> Companies { get; set; }



    }
}