using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        public int? PostId { get; set; }
        public string OwnerId { get; set; }
        public DateTime Time { get; set; }
        public String CommentText { get; set; }
       
        [ForeignKey("PostId")]
        public Posts Posts { get; set; }
    }
}