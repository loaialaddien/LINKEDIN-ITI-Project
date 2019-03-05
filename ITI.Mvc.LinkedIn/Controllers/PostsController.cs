using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITI.Mvc.LinkedIn.Models;
using ITI.Mvc.LinkedIn.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using ITI.Mvc.LinkedIn.BusinessLogicLayer;

namespace ITI.Mvc.LinkedIn.Controllers
{
    [Authorize]
    public class PostsController : Controller

    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        UnitOfWork mydatabase = UnitOfWork.CreateInstance();

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {

            return View(mydatabase.PostsUserManager.GetAllBind().Where(e => e.OwnerId == User.Identity.GetUserId()));
        }
        public ActionResult Wall()
        {
            List<PostDetailViewModel> mypostsmodels = new List<PostDetailViewModel>();
            List<Posts> myposts = mydatabase.PostsUserManager.GetAllBind().OrderByDescending(i => i.DateOfCreation).ToList();
            string curuserid = User.Identity.GetUserId();
            string curfname = UserManager.Users.Where(i => i.Id == curuserid).FirstOrDefault().Fname;
            string curlname = UserManager.Users.Where(i => i.Id == curuserid).FirstOrDefault().Lname;
            string userfullname = string.Format("{0} {1}", curfname, curlname);
            
            foreach (Posts post in myposts)
            {
                int id = post.Id;
                string userid = post.OwnerId;
                string fname = UserManager.Users.Where(i => i.Id == userid).FirstOrDefault().Fname;
                string lname = UserManager.Users.Where(i => i.Id == userid).FirstOrDefault().Lname;
                string username = string.Format("{0} {1}", fname, lname);
                string indus = UserManager.Users.Where(i => i.Id == userid).FirstOrDefault().Industry;
                TimeSpan date = DateTime.Now - post.DateOfCreation;
                string datetobeshown = date.ToString();
                if (date.TotalHours > 23)
                {
                    datetobeshown = string.Format("{0} Days ago", date.Days);
                }
                else if (date.TotalHours < 23 && date.TotalMinutes > 59)
                {
                    datetobeshown =string.Format("{0} Hours ago", date.Hours);
                }
                else if (date.TotalMinutes < 59)
                {
                    datetobeshown = string.Format("{0} Minutes ago", date.Minutes);
                }
                else if (date.TotalMinutes == 0)
                {
                    datetobeshown = string.Format("{0} Seconds ago", date.Seconds);
                }

                PostDetailViewModel myviewmodel = new PostDetailViewModel
                {
                     industry = indus,
                    CurrentUserUsername = userfullname,
                    username = username,
                    post = mydatabase.PostsUserManager.GetById(id),
                    
                    comments = mydatabase.CommentsUserManager.GetAll().Where(i => i.PostId == id).ToList(),

                    posttext = mydatabase.PostsTextsUserManager.GetAll().Where(i => i.PostId == id).FirstOrDefault()
                    , /*postphoto = mydatabase.PostsPhotosUserManager.GetAll().Where(i => i.PostId == id).FirstOrDefault(),*/
                    Commentators = new Dictionary<int, string>()
                    ,Timeofthepost = datetobeshown
                };
                foreach (Comments comment in myviewmodel.comments)
                {
                    string commentuserid = comment.OwnerId;
                    string commentatorfname = UserManager.Users.Where(i => i.Id == commentuserid).FirstOrDefault().Fname;
                    string commentatorlname = UserManager.Users.Where(i => i.Id == commentuserid).FirstOrDefault().Lname;
                    string commentatorusername = string.Format("{0} {1}", commentatorfname, commentatorlname);
                    myviewmodel.Commentators.Add(comment.Id, commentatorusername);
                }
                
                mypostsmodels.Add(myviewmodel);
            }

           

            return PartialView("_PartialPostView", mypostsmodels);

            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("_PartialWallPosts", mydatabase.PostsUserManager.GetAllBind());
            //}
            //else
            //{
            //    return View(mydatabase.PostsUserManager.GetAllBind());
            //}

        }
        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Posts post = mydatabase.PostsUserManager.GetById(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {

            PostViewModel myview = new PostViewModel();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PartialCreatePost", myview);
            }
            else
            {

                return View(myview);
            }
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel viewmodel)
        {
            viewmodel.mypost = new Posts
            {
                postlikes = new List<PostLikes>(),
                Comments = new List<Comments>(),

                OwnerId = User.Identity.GetUserId(),


                DateOfCreation = DateTime.Now
            };

            viewmodel.mytext.Posts = viewmodel.mypost;
            viewmodel.mytext.PostId = viewmodel.mypost.Id;


            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    mydatabase.PostsUserManager.Add(viewmodel.mypost);
                    mydatabase.PostsTextsUserManager.Add(viewmodel.mytext);


                    Posts post = mydatabase.PostsUserManager.GetById(viewmodel.mypost.Id);
                    int id = viewmodel.mypost.Id;
                    string userid = post.OwnerId;
                    string fname = UserManager.Users.Where(i => i.Id == userid).FirstOrDefault().Fname;
                    string lname = UserManager.Users.Where(i => i.Id == userid).FirstOrDefault().Lname;
                    string username = string.Format("{0} {1}", fname, lname);
                    string indus = UserManager.Users.Where(i => i.Id == userid).FirstOrDefault().Industry;
                    TimeSpan date = DateTime.Now - post.DateOfCreation;
                    string datetobeshown = date.ToString();
                    if (date.TotalHours > 23)
                    {
                        datetobeshown = string.Format("{0} Days ago", date.Days);
                    }
                    else if (date.TotalHours < 23 && date.TotalHours > 0)
                    {
                        datetobeshown = string.Format("{0} Hours ago", date.Hours);
                    }
                    else if (date.TotalMinutes < 59)
                    {
                        datetobeshown = string.Format("{0} Minutes ago", date.Minutes);
                    }
                    else if(date.TotalMinutes == 0)
                    {
                        datetobeshown = string.Format("{0} Minutes ago", date.Seconds);
                    }
                    PostDetailViewModel myviewmodel = new PostDetailViewModel
                    {
                        username = username,
                        post = mydatabase.PostsUserManager.GetById(id),

                        comments = mydatabase.CommentsUserManager.GetAll().Where(i => i.PostId == id).ToList(),

                        posttext = mydatabase.PostsTextsUserManager.GetAll().Where(i => i.PostId == id).FirstOrDefault()
                        ,
                        Commentators = new Dictionary<int, string>(), industry = indus, Timeofthepost = datetobeshown

                    };
                    foreach (Comments comment in myviewmodel.comments)
                    {
                        string commentuserid = comment.OwnerId;
                        string commentatorfname = UserManager.Users.Where(i => i.Id == commentuserid).FirstOrDefault().Fname;
                        string commentatorlname = UserManager.Users.Where(i => i.Id == commentuserid).FirstOrDefault().Lname;
                        string commentatorusername = string.Format("{0} {1}", commentatorfname, commentatorlname);
                        myviewmodel.Commentators.Add(comment.Id, commentatorusername);
                    }

                    return PartialView("_PartialShowonepost", myviewmodel);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    mydatabase.PostsUserManager.Add(viewmodel.mypost);
                    mydatabase.PostsTextsUserManager.Add(viewmodel.mytext);




                    return RedirectToAction("Index");
                }
                //    if (ModelState.IsValid)
                //{
                //    mydatabase.PostsUserManager.Add(viewmodel.mypost);
                //    mydatabase.PostsTextsUserManager.Add(viewmodel.mytext);



                //    return RedirectToAction("Index");
                //}

            }
                return View(viewmodel);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Posts posts = mydatabase.PostsUserManager.GetById(id);

            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }
        public ActionResult PostDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts post = mydatabase.PostsUserManager.GetById(id);
            if (post == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            string userid = post.OwnerId;
            string fname = UserManager.Users.Where(i => i.Id == userid).FirstOrDefault().Fname;
            string lname = UserManager.Users.Where(i => i.Id == userid).FirstOrDefault().Lname;
            string username = string.Format("{0} {1}", fname, lname);
            PostDetailViewModel myviewmodel = new PostDetailViewModel
            {
                username = username,
                post = mydatabase.PostsUserManager.GetById(id),

                comments = mydatabase.CommentsUserManager.GetAll().Where(i => i.PostId == id).ToList(),
              
                posttext = mydatabase.PostsTextsUserManager.GetAll().Where(i => i.PostId == id).FirstOrDefault()
                ,Commentators = new Dictionary<int, string>()
                
            };
           foreach (Comments comment in myviewmodel.comments)
            {
                string commentuserid = comment.OwnerId;
                string commentatorfname = UserManager.Users.Where(i => i.Id == commentuserid).FirstOrDefault().Fname;
                string commentatorlname = UserManager.Users.Where(i => i.Id == commentuserid).FirstOrDefault().Lname;
                string commentatorusername = string.Format("{0} {1}", commentatorfname, commentatorlname);
                myviewmodel.Commentators.Add(comment.Id, commentatorusername);
            }

            return View("PostDetails", myviewmodel);
        }
        public ActionResult Like(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var userid = User.Identity.GetUserId();
                var post = mydatabase.PostsUserManager.GetById(id);

                if (post.NoOfLikes == 0)
                {

                    PostLikes like = new PostLikes
                    {
                        LikeOwnerId = userid,
                        PostId = (int)id,
                        Posts = post
                    };

                    mydatabase.PostsUserManager.GetById(id).NoOfLikes++;
                    mydatabase.PostLikesUserManager.Add(like);


                    //db.SaveChanges();

                }
                else
                {
                    //


                    if ((mydatabase.PostLikesUserManager.GetAll().Where(i => i.PostId == id && i.LikeOwnerId == userid).ToList()).Count == 0)
                    {
                        PostLikes like = new PostLikes
                        {
                            LikeOwnerId = userid,
                            PostId = (int)id,
                            Posts = post
                        };
                        mydatabase.PostsUserManager.GetById(id).NoOfLikes++;
                        mydatabase.PostLikesUserManager.Add(like);


                        //db.SaveChanges();
                    }


                }



            }


            Posts posttoget = mydatabase.PostsUserManager.GetById(id);
          
            string postuserid = posttoget.OwnerId;
            string fname = UserManager.Users.Where(i => i.Id == postuserid).FirstOrDefault().Fname;
            string lname = UserManager.Users.Where(i => i.Id == postuserid).FirstOrDefault().Lname;
            string username = string.Format("{0} {1}", fname, lname);
            PostDetailViewModel myviewmodel = new PostDetailViewModel
            {
                username = username,
                post = mydatabase.PostsUserManager.GetById(id),

                comments = mydatabase.CommentsUserManager.GetAll().Where(i => i.PostId == id).ToList(),

                posttext = mydatabase.PostsTextsUserManager.GetAll().Where(i => i.PostId == id).FirstOrDefault()
                ,
                Commentators = new Dictionary<int, string>()

            };
            foreach (Comments comment in myviewmodel.comments)
            {
                string commentuserid = comment.OwnerId;
                string commentatorfname = UserManager.Users.Where(i => i.Id == commentuserid).FirstOrDefault().Fname;
                string commentatorlname = UserManager.Users.Where(i => i.Id == commentuserid).FirstOrDefault().Lname;
                string commentatorusername = string.Format("{0} {1}", commentatorfname, commentatorlname);
                myviewmodel.Commentators.Add(comment.Id, commentatorusername);
            }

            return PartialView("_PartialShowonepost", myviewmodel);

            
        }
        //[HttpGet]
        //public ActionResult AddComment(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PostViewModel myview = new PostViewModel
        //    {
        //        comment = new Comments()
        //    };
        //    myview.comment.PostId = id;

        //    return View("CreateComment", myview);
        //}

        [HttpPost]
        public ActionResult AddComment(PostViewModel viewmodel)
        {
            var postid = viewmodel.mypost.Id;

            var post = mydatabase.PostsUserManager.GetById(postid);
            viewmodel.comment.OwnerId = User.Identity.GetUserId();
            viewmodel.comment.Time = DateTime.Now;
            viewmodel.comment.PostId = postid;
            if (ModelState.IsValid)
            {
                post.NoOfComments++;
                mydatabase.CommentsUserManager.Add(viewmodel.comment);

            }
            Posts posttoget = mydatabase.PostsUserManager.GetById(postid);

            string postuserid = posttoget.OwnerId;
            string fname = UserManager.Users.Where(i => i.Id == postuserid).FirstOrDefault().Fname;
            string lname = UserManager.Users.Where(i => i.Id == postuserid).FirstOrDefault().Lname;
            string username = string.Format("{0} {1}", fname, lname);
            PostDetailViewModel myviewmodel = new PostDetailViewModel
            {
                username = username,
                post = mydatabase.PostsUserManager.GetById(postid),

                comments = mydatabase.CommentsUserManager.GetAll().Where(i => i.PostId == postid).ToList(),

                posttext = mydatabase.PostsTextsUserManager.GetAll().Where(i => i.PostId == postid).FirstOrDefault()
                ,
                Commentators = new Dictionary<int, string>()

            };
            foreach (Comments comment in myviewmodel.comments)
            {
                string commentuserid = comment.OwnerId;
                string commentatorfname = UserManager.Users.Where(i => i.Id == commentuserid).FirstOrDefault().Fname;
                string commentatorlname = UserManager.Users.Where(i => i.Id == commentuserid).FirstOrDefault().Lname;
                string commentatorusername = string.Format("{0} {1}", commentatorfname, commentatorlname);
                myviewmodel.Commentators.Add(comment.Id, commentatorusername);
            }

            return PartialView("_PartialShowonepost", myviewmodel);
        }
        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OwnerId,DateOfCreation,NoOfLikes,NoOfComments")] Posts posts)
        {
            if (ModelState.IsValid)
            {
                mydatabase.PostsUserManager.Update(posts);
                
                return RedirectToAction("Index");
            }
            return View(posts);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts posts = mydatabase.PostsUserManager.GetById(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posts posts = mydatabase.PostsUserManager.GetById(id);
            mydatabase.PostsUserManager.Remove(posts);
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
