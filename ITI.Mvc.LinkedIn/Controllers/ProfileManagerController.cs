using ITI.Mvc.LinkedIn.BusinessLogicLayer;
using ITI.Mvc.LinkedIn.Models.Entities;
using ITI.Mvc.LinkedIn.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ITI.Mvc.LinkedIn.Controllers
{

    [Authorize]
    public class ProfileManagerController : Controller
    {
        // GET: ProfileManager
        UnitOfWork mydatabase = UnitOfWork.CreateInstance();

        //add,edit,delete for langauage, usereducation,courses,skills,
        // GET: languages
        public ActionResult Index()
        {
            return Redirect("Account/userprofile");
        }



        // GET: languages/Create
        public ActionResult AddLanguage()
        {
            LanguageViewModel myview = new LanguageViewModel();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PartialAddLanguage",myview);
            }
            else
            {


                return View(myview);
            }
        }

        //  languages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLanguage(LanguageViewModel viewmodel)
        {
            Language mylang = new Language
            {


                LinkedInUserId = User.Identity.GetUserId(),
                Name = viewmodel.language.Name

            };
            string UserId = User.Identity.GetUserId();
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                   
                    mydatabase.LanguageUserManager.Add(mylang);


                    LanguageViewModel myview = new LanguageViewModel()
                    {
                        Mylanguages = mydatabase.LanguageUserManager.GetAllBind().Where(i => i.LinkedInUserId == UserId).ToList()
                    };




                    return PartialView("_PartialLanguageList", myview);
                }
            }
            else

            {
                if (ModelState.IsValid)
                {
                    
                    mydatabase.LanguageUserManager.Add(mylang);
                }



                return RedirectToAction("UserProfile", "Account");
            }
           

            return View(viewmodel);
        }


        // GET: userEducation/Create
        public ActionResult AddUserEducation()
        {
            UserEducationViewModel myview = new UserEducationViewModel();
            myview.Faculties = mydatabase.FacultyUserManager.GetAllBind();
            myview.Universities = mydatabase.UniversityUserManager.GetAllBind();

            return View(myview);
        }

        //  languages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUserEducation(UserEducationViewModel viewmodel)
        {

            UserEducation usereducation = new UserEducation()
            {
                LinkedInUserId = User.Identity.GetUserId(),
                Degree = viewmodel.Myeducation.Degree,
                 Activities = viewmodel.Myeducation.Activities,
                  Descriptions = viewmodel.Myeducation.Descriptions,
                   EndDate = viewmodel.Myeducation.EndDate,
                    Fieldofstudy = viewmodel.Myeducation.Fieldofstudy,
                     Grade = viewmodel.Myeducation.Grade,
                      StartingDate = viewmodel.Myeducation.StartingDate,
                       University = viewmodel.Myeducation.University
                    };





            if (ModelState.IsValid)
            {
                mydatabase.UserEducationManager.Add(usereducation);


            }
            string userid = User.Identity.GetUserId();

            AppUserViewModel myviewmodel = new AppUserViewModel()
            {
                EducationList = mydatabase.UserEducationManager.GetAllBind().Where(i => i.LinkedInUserId == userid).ToList()
            };
            if (Request.IsAjaxRequest())
            {

                return PartialView("_PartialProfileEducationwithedit", myviewmodel);
            }
            return PartialView("_PartialProfileEducationwithedit", myviewmodel);

            

        }

        // GET: languages/Edit/5
        public ActionResult EditLanguage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageViewModel myview = new LanguageViewModel();
            myview.language = mydatabase.LanguageUserManager.GetById(id);


            if (myview.language == null)
            {
                return HttpNotFound();
            }
            return View(myview);
        }

        //  languages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLanguage(LanguageViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Language language = new Language()
                {
                    Id = viewmodel.language.Id,
                    LinkedInUserId = viewmodel.language.LinkedInUserId,
                    Name = viewmodel.language.Name
                };
                mydatabase.LanguageUserManager.Update(language);

                return RedirectToAction("UserProfile", "Account");
            }
            return View(viewmodel);
        }


        // GET: languages/Delete/5
        public ActionResult DeleteLanguage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageViewModel myview = new LanguageViewModel();
            myview.language = mydatabase.LanguageUserManager.GetById(id);
            if (myview.language == null)
            {
                return HttpNotFound();
            }


            mydatabase.LanguageUserManager.Remove(myview.language);

            return RedirectToAction("UserProfile", "Account");

        }

        //skills

        // GET: skills/Create
        public ActionResult AddSkills()
        {
            SkillViewModel myview = new SkillViewModel();
            if (Request.IsAjaxRequest() )
            {
                return PartialView("_PartialAddSkill",myview);
            }
            else
            {

            return View(myview);

            }

        }

        //  skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSkills(SkillViewModel viewmodel)
        {
            Skills mySkill = new Skills
            {


                LinkedInUserId = User.Identity.GetUserId(),
                Name = viewmodel.skill.Name,
                Description = viewmodel.skill.Description

            };

            if (Request.IsAjaxRequest())
            {

                if (ModelState.IsValid)
                {
                    mydatabase.SkillsUserManager.Add(mySkill);


                    string id = User.Identity.GetUserId();

                    AppUserViewModel myview = new AppUserViewModel()
                    {
                        Skills = mydatabase.SkillsUserManager.GetAllBind().Where(i => i.LinkedInUserId == id).ToList()

                    };
                    return PartialView("_PartialProfileSkillswithedit", myview);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    mydatabase.SkillsUserManager.Add(mySkill);


                }


                return RedirectToAction("UserProfile", "Account");
            }

            return View(viewmodel);
        }


        // GET: skills/Edit/5
        public ActionResult EditSkills(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SkillViewModel myview = new SkillViewModel();
            myview.skill = mydatabase.SkillsUserManager.GetById(id);

            if (myview.skill == null)
            {
                return HttpNotFound();
            }
            return View(myview);
        }

        //  skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSkills(Skills skills)
        {
            if (ModelState.IsValid)
            {
                mydatabase.SkillsUserManager.Update(skills);

                return RedirectToAction("Index");
            }
            return View(skills);
        }

        // GET: skills/Delete/5
        public ActionResult DeleteSkills(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillViewModel myview = new SkillViewModel();
            myview.skill = mydatabase.SkillsUserManager.GetById(id);
            if (myview.skill == null)
            {
                return HttpNotFound();
            }
            mydatabase.SkillsUserManager.Remove(myview.skill);
            return RedirectToAction("UserProfile", "Account");
        }

        ///courses
        // GET: courses/Create
        public ActionResult AddCourses()
        {
            CourseViewModel myview = new CourseViewModel();


            return View(myview);
        }

        //  courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourses(CourseViewModel viewmodel)
        {
            Courses mycourse = new Courses
            {

                 
                LinkedInUserId = User.Identity.GetUserId(),
                CourseName = viewmodel.course.CourseName

            };





            if (ModelState.IsValid)
            {
                mydatabase.CoursesUserManager.Add(mycourse);




            }
            string userid = User.Identity.GetUserId();

            AppUserViewModel myviewmodel = new AppUserViewModel()
            {
                Courses = mydatabase.CoursesUserManager.GetAllBind().Where(i => i.LinkedInUserId == userid).ToList()
            };
            if (Request.IsAjaxRequest())

            {

             return PartialView("_PartialProfilecourseswithedit", myviewmodel);
            }
            return PartialView("_PartialProfilecourseswithedit", myviewmodel);

        }


        // GET:courses/Edit/5
        public ActionResult EditCourses(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CourseViewModel myview = new CourseViewModel();
            myview.course = mydatabase.CoursesUserManager.GetById(id);

            if (myview.course == null)
            {
                return HttpNotFound();
            }
            return View(myview);
        }

        // POST: courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCourses(Courses courses)
        {
            if (ModelState.IsValid)
            {
                mydatabase.CoursesUserManager.Update(courses);

                return RedirectToAction("Index");
            }
            return View(courses);
        }

        // GET: courses/Delete/5
        public ActionResult DeleteCourses(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseViewModel myview = new CourseViewModel();
            myview.course = mydatabase.CoursesUserManager.GetById(id);
            if (myview.course == null)
            {
                return HttpNotFound();
            }

            mydatabase.CoursesUserManager.Remove(myview.course);

            return RedirectToAction("UserProfile", "Account");

        }


        ///companies
        // GET: companies/Create
        public ActionResult AddCompanies()
        {
            CompanyViewModel myview = new CompanyViewModel();


            return View(myview);
        }

        //  companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCompanies(CompanyViewModel viewmodel)
        {
            Company mycompany = new Company
            {


                LinkedInUserId = User.Identity.GetUserId(),
                Name = viewmodel.company.Name,
                StartDate = viewmodel.company.StartDate,
                EndDate = viewmodel.company.EndDate,
                Title = viewmodel.company.Title



            };





            if (ModelState.IsValid)
            {
                mydatabase.CompanyUserManager.Add(mycompany);




            }
            string userid = User.Identity.GetUserId();

            AppUserViewModel myviewmodel = new AppUserViewModel()
            {
                Companies = mydatabase.CompanyUserManager.GetAllBind().Where(i => i.LinkedInUserId == userid).ToList()
            };
            if (Request.IsAjaxRequest())
            {

                return PartialView("_PartialProfileExperiencewithedit", myviewmodel);
            }
            return RedirectToAction("UserProfile", "Account");

            
        }


        // GET:companies/Edit/5
        public ActionResult EditCompanies(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompanyViewModel myview = new CompanyViewModel();
            myview.company = mydatabase.CompanyUserManager.GetById(id);

            if (myview.company == null)
            {
                return HttpNotFound();
            }
            return View(myview);
        }

        // POST: companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCompanies(Company companies)
        {
            if (ModelState.IsValid)
            {
                mydatabase.CompanyUserManager.Update(companies);

                return RedirectToAction("Index");
            }
            return View(companies);
        }

        // GET: companies/Delete/5
        public ActionResult DeleteCompanies(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyViewModel myview = new CompanyViewModel();
            myview.company = mydatabase.CompanyUserManager.GetById(id);
            if (myview.company == null)
            {
                return HttpNotFound();
            }

            mydatabase.CompanyUserManager.Remove(myview.company);

            return RedirectToAction("UserProfile", "Account");

        }
    }
}