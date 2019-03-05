using ITI.Mvc.LinkedIn.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.ViewModels
{
    public class SkillViewModel
    {
      public  List<Skills> Myskills { get; set; }
        public string UserId { get; set; }
        public Skills skill { get; set; }
    }

}