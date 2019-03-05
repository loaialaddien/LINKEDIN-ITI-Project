using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class ProfilePictures
    {
        [Key]
        public int Id { get; set; }
        public string PathName { get; set; }
        public bool Iscurrent { get; set; }
        public string UserId { get; set; }
        
    }
}