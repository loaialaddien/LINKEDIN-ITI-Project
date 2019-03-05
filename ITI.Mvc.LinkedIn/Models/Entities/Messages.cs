using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class Messages
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        

        public string RecieverId { get; set; }
        
        public DateTime DateOfMessge { get; set; }
        public int State { get; set; }
        public string MessageBody { get; set; }

    }
}