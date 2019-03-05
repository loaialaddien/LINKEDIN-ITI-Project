using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }
        public string SenderID { get; set; }
        public string RecieverId { get; set; }
        public DateTime DateOfRequest { get; set; }
        public int State { get; set; }
    
    }
}