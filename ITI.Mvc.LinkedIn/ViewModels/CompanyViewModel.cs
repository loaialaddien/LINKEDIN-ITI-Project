using ITI.Mvc.LinkedIn.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.ViewModels
{
    public class CompanyViewModel
    {
        List<Company> Mycompanies { get; set; }
        public string UserId { get; set; }
        public Company company { get; set; }

    }
}