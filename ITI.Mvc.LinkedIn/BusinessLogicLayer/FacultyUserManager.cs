﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITI.Mvc.LinkedIn.Repository;
using ITI.Mvc.LinkedIn.Models.Entities;
using ITI.Mvc.LinkedIn.Models;

namespace ITI.Mvc.LinkedIn.BusinessLogicLayer
{
    public class FacultyUserManager : Repository<Faculty, ApplicationDbContext>
    {
        public FacultyUserManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}