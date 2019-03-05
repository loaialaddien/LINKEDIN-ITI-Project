using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class NotificationFromPostsLikes
    {
        [Key]
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int PostLikeId { get; set; }
        [ForeignKey("PostLikeId")]
        public Posts Posts { get; set; }
        [ForeignKey("NotificationId")]
        public Notification Notification { get; set; }
    }
}