using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class NotificationFromComments
    {
        [Key]
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int NotificationId { get; set; }
        [ForeignKey("CommentId")]
        public Comments Comments { get; set; }
        [ForeignKey("NotificationId")]
        public Notification Notification { get; set; }
    }
}