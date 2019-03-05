
using ITI.Mvc.LinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.Mvc.LinkedIn.BusinessLogicLayer
{
    public class UnitOfWork
    {
        static UnitOfWork unit;
        ApplicationDbContext context;
        public CommentsLikeUserManager CommentsLikeUserManager { get
            {
                return new CommentsLikeUserManager(context);
            }
        }
        public CommentsUserManager CommentsUserManager
        {
            get
            {
                return new CommentsUserManager(context);
            }
        }
        public CompanyUserManager CompanyUserManager
        {
            get
            {
                return new CompanyUserManager(context);
            }
        }
        public CountryUserManager CountryUserManager
        {
            get
            {
                return new CountryUserManager(context);
            }
        }
        public CoursesUserManager CoursesUserManager
        {
            get
            {
                return new CoursesUserManager(context);
            }
        }

        public FacultyUserManager FacultyUserManager
        {
            get
            {
                return new FacultyUserManager(context);
            }
        }
        public FriendRequestUserManager FriendRequestUserManager
        {
            get
            {
                return new FriendRequestUserManager(context);
            }
        }
        public FriendUserManager FriendUserManager
        {
            get
            {
                return new FriendUserManager(context);
            }
        }
        public LanguageUserManager LanguageUserManager
        {
            get
            {
                return new LanguageUserManager(context);
            }
        }
        public UserEducationManager UserEducationManager
        {
            get
            {
                return new UserEducationManager(context);
            }
        }
        public UniversityUserManager UniversityUserManager
        {
            get
            {
                return new UniversityUserManager(context);
            }
        }
      

        public SkillsUserManager SkillsUserManager
        {
            get
            {
                return new SkillsUserManager(context);
            }
        }
        public ProfilePictureUserManager ProfilePictureUserManager
        {
            get
            {
                return new ProfilePictureUserManager(context);
            }
        }
        public PostsUserManager PostsUserManager
        {
            get
            {
                return new PostsUserManager(context);
            }
        }
        public PostsTextsUserManager PostsTextsUserManager
        {
            get
            {
                return new PostsTextsUserManager(context);
            }
        }

        public PostsPhotosUserManager PostsPhotosUserManager
        {
            get
            {
                return new PostsPhotosUserManager(context);
            }
        }

        public PostLikesUserManager PostLikesUserManager
        {
            get
            {
                return new PostLikesUserManager(context);
            }
        }

        public NotificationUserManager NotificationUserManager
        {
            get
            {
                return new NotificationUserManager(context);
            }
        }

        public NotificationFromPostsLikesUserManager NotificationFromPostsLikesUserManager
        {
            get
            {
                return new NotificationFromPostsLikesUserManager(context);
            }
        }

        public NotificationFromCommentsUserManager NotificationFromCommentsUserManager
        {
            get
            {
                return new NotificationFromCommentsUserManager(context);
            }
        }
        public MessagesUserManager MessagesUserManager
        {
            get
            {
                return new MessagesUserManager(context);
            }
        }
        


        private UnitOfWork()
        {
            context = new ApplicationDbContext();
        }
        public static UnitOfWork CreateInstance()
        {
            if (unit == null)
            {
                unit = new UnitOfWork();
                return unit;

            }
            else return unit;

        }
    }
}