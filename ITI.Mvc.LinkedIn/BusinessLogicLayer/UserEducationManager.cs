
using ITI.Mvc.LinkedIn.Models;
using ITI.Mvc.LinkedIn.Models.Entities;
using ITI.Mvc.LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.BusinessLogicLayer
{
    public class UserEducationManager : Repository<UserEducation, ApplicationDbContext>
    {
        public UserEducationManager(ApplicationDbContext context) : base(context)
        {
        }
    }
    
}