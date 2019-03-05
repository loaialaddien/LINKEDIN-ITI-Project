using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class Friends
    {
        [Key]
        public int Id { get; set; }
       
        public string SenderID { get; set; }
        public string RecieverId { get; set; }
        public DateTime StartOfFriendShip { get; set; }
        public int StateOfFriendShip { get; set; }
        
     

    }
}