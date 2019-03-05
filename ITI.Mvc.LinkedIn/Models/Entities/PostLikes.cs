using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class PostLikes
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public string LikeOwnerId { get; set; }
        [ForeignKey("PostId")]
        public Posts Posts { get; set; }
       
    }
}