using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public int SeenByUser { get; set; }
        public string UserId { get; set; }
     

    }
}