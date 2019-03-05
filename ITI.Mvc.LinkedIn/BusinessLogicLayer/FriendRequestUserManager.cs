﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITI.Mvc.LinkedIn.Repository;
using ITI.Mvc.LinkedIn.Models.Entities;
using ITI.Mvc.LinkedIn.Models;

namespace ITI.Mvc.LinkedIn.BusinessLogicLayer
{
    public class FriendRequestUserManager : Repository<FriendRequest, ApplicationDbContext>
    {
        public FriendRequestUserManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}