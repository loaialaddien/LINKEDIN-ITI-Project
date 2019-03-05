using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.Models.Entities
{
    public class Posts
    {
        [Key]
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int NoOfLikes { get; set; }
        public List<PostLikes> postlikes { get; set; }
        public int NoOfComments { get; set; }
        public List<Comments> Comments { get; set; }
       


    }
}