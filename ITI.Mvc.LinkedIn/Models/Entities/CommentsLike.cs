using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class CommentsLike
    {
        [Key]
        public int Id { get; set; }
        public int CommentId { get; set; }
        [ForeignKey("CommentId")]
        public Comments Comments { get; set; }
        public string LinkedInUser { get; set; }

       
    }
}