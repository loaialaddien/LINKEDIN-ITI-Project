using ITI.Mvc.LinkedIn.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn
{
    public class PostViewModel
    {

        public Posts mypost { get; set; }
        public PostsPhotos myphotos { get; set; }
        public PostsText mytext { get; set; }
        public PostLikes like { get; set; }
        public Comments comment { get; set; }

    }
}