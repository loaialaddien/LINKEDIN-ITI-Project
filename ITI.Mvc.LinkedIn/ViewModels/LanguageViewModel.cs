using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITI.Mvc.LinkedIn.Models.Entities;


namespace ITI.Mvc.LinkedIn.ViewModels
{
    public class LanguageViewModel
    {
        public string UserId { get; set; }
        public Language language { get; set; }
        public List<Language> Mylanguages { get; set; }
    }
}