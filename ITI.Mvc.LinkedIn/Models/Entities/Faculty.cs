using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
        public int? UniversityId { get; set; }
        [ForeignKey("UniversityId")]
        public University University { get; set; }
        //university
    }
}