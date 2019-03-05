using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LinkedInUserId { get; set; }
       
    }
}