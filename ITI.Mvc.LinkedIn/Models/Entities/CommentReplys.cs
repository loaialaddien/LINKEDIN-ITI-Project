using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class CommentReplys
    {
        [Key]
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int ChildId { get; set; }
        [ForeignKey("CommentId")]
        public Comments Parent { get; set; }
        [ForeignKey("ChildId")]
        public Comments Child { get; set; }

    }
}