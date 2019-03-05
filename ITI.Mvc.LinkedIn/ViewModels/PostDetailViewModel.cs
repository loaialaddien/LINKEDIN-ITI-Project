using ITI.Mvc.LinkedIn.Models;
using ITI.Mvc.LinkedIn.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn
{
    public class PostDetailViewModel
    {
        //public ApplicationUser User { get; set; }
        public string CurrentUserUsername { get; set; }

        public string username { get; set; }
        public string industry { get; set; }
        public Posts post { get; set; }
        public List<Comments> comments { get; set; }
        public Dictionary<int,string> Commentators { get; set; }
        public PostsText posttext { get; set; }
        //public PostsPhotos postphoto { get; set; }
        public string Timeofthepost { get; set; }
    }
}