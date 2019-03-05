using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ITI.Mvc.LinkedIn.Repository;
using ITI.Mvc.LinkedIn.Models.Entities;
using ITI.Mvc.LinkedIn.Models;

namespace ITI.Mvc.LinkedIn.BusinessLogicLayer
{
    public class CommentsUserManager : Repository<Comments, ApplicationDbContext>
    {
        public CommentsUserManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}