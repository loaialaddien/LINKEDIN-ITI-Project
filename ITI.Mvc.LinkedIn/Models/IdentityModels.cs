using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ITI.Mvc.LinkedIn.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.Mvc.LinkedIn.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string Fname { get; set; }
        

        public string Lname { get; set; }

        public string Headline { get; set; }


        public int Zipcode { get; set; }
        public string Industry { get; set; }



        [ForeignKey("LinkedInUserId")]
        public List<UserEducation> EducationList { get; set; }
        [ForeignKey("LinkedInUserId")]

        public List<Language> Languages { get; set; }

        [ForeignKey("UserId")]
        public List<ProfilePictures> Pictures { get; set; }
        [ForeignKey("LinkedInUserId")]

        public List<Skills> Skills { get; set; }
        [ForeignKey("LinkedInUserId")]

        public List<Courses> Courses { get; set; }

        [ForeignKey("RecieverId")]
        


        public List<Friends> Friends { get; set; }
        [ForeignKey("OwnerId")]

        public List<Posts> Posts { get; set; }
        [ForeignKey("UserId")]

        public List<Notification> Notifications { get; set; }
        [ForeignKey("OwnerId")]

        public List<Comments> Comments { get; set; }
       

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<UserEducation> UserEducation { get; set; }
        public virtual DbSet<University> University { get; set; }
        //public virtual DbSet<TelephoneNumber> TelephoneNumber { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<ProfilePictures> ProfilePictures { get; set; }
        public virtual DbSet<PostsText> PostsText { get; set; }
        public virtual DbSet<PostsPhotos> PostsPhotos { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<PostLikes> PostLikes { get; set; }
        public virtual DbSet<NotificationFromPostsLikes> NotificationFromPostsLikes { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<NotificationFromComments> NotificationFromComments { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        //public virtual DbSet<LinkedInUser> LinkedInUser { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<FriendRequest> FriendRequest { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CommentsLike> CommentsLike { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<CommentReplys> CommentReplys { get; set; }

        
    }
}