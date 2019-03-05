using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Faculty> Faculties { get; set; }


    }
}