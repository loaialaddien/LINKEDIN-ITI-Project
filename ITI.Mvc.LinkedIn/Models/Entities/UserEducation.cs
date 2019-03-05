using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class UserEducation
    {
        [Key]
        public int Id { get; set; }


        public string LinkedInUserId { get; set; }

        //public int UniversityId { get; set; }
        //[ForeignKey("UniversityId")]
        //public University University { get; set; }

        //public int FacultyId { get; set; }
        //[ForeignKey("FacultyId")]
        //public Faculty Faculty { get; set; }
        public string University { get; set; }
        public string Fieldofstudy { get; set; }
        public string Degree { get; set; }
        public string Grade { get; set; }
        public string Activities { get; set; }
        public string Descriptions { get; set; }
        public int StartingDate { get; set; }
        public int EndDate { get; set; }
    }
}