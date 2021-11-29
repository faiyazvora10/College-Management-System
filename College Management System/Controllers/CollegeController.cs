using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using College_Management_System.Models;

namespace College_Management_System.Controllers
{
    public class CollegeController : Controller
    {
        faiyazEntities obj = new faiyazEntities();
        // GET: College
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(AdminLogin a)
        {
            var q = (from m in obj.AdminLogins where m.username.Equals(a.username) && m.password.Equals(a.password) select m).SingleOrDefault();
            if (q != null)
            {
                //ViewBag.msg = "Login Successfully";
                return Redirect("Inner");
            }
            else
            {
                ViewBag.msg = "Invalid Username or Password";
            }
            return View(q);
        }
        public ActionResult AddTeach()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AddTeach(Teacher t)
        {
            obj.Teachers.Add(t);
            obj.SaveChanges();
            ViewBag.msg = "Data Inserted";
            return View();
        }

        public ActionResult ShowTeach()
        {
            var q = (from m in obj.Teachers select m).ToList();
            return View(q);
        }

        public ActionResult DeleteTeach(int id)
        {
            var q = (from m in obj.Teachers where m.Id == id select m).Single();
            
                obj.Teachers.Remove(q);
                obj.SaveChanges();
                return RedirectToAction("ShowTeach");
            
        }

        public ActionResult EditTeach(int id)
        {
            var q = (from m in obj.Teachers where m.Id == id select m).Single();
            
              obj.SaveChanges();
              return View(q);
            
        }

        [HttpPost]

        public ActionResult EditTeach(Teacher t)
        {
            var q = (from m in obj.Teachers where m.Id == t.Id select m).Single();
            
                q.name = t.name;
                q.birthday = t.birthday;
                q.salary = t.salary;
                obj.SaveChanges();

                return RedirectToAction("ShowTeach");
            
        }
        #region
        public ActionResult AddStud()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddStud(Student s)
        {
            obj.Students.Add(s);
            obj.SaveChanges();
            ViewBag.msg = "Data Inserted";
            return View();
        }

        public ActionResult ShowStud()
        {
            var q = (from m in obj.Students select m).ToList();
            return View(q);
        }

        public ActionResult DeleteStud(int id)
        {
            var q = (from m in obj.Students where m.Id == id select m).Single();
            obj.Students.Remove(q);
            obj.SaveChanges();

            return RedirectToAction("ShowStud");

        }

        public ActionResult EditStud(int id)
        {
            var q = (from m in obj.Students where m.Id == id select m).Single();
            return View(q);
        }
        [HttpPost]

        public ActionResult EditStud(Student s)
        {
            var q = (from m in obj.Students where m.Id == s.Id select m).Single();

            
            q.name = s.name;
            q.birthday = s.birthday;
            q.regist_no_ = s.regist_no_;
            q.subject = s.subject;
            q.grade = s.grade;
            obj.SaveChanges();

            return RedirectToAction("ShowStud");
        }


        #endregion

        #region
        public ActionResult AddCourse()
        {
            return View();

        }
        [HttpPost]

        public ActionResult AddCourse(Cours c)
        {
            obj.Courses.Add(c);
            obj.SaveChanges();
            ViewBag.msg = "Data Inserted";
            return View();
        }

        public ActionResult ShowCourse()
        {
            var q = (from m in obj.Courses select m).ToList();
            return View(q);
        }

        public ActionResult DeleteCourse(int id)
        {
            var q = (from m in obj.Courses where m.Id==id select m).Single();
            obj.Courses.Remove(q);
            obj.SaveChanges();

            return RedirectToAction("ShowCourse");

        }

        public ActionResult EditCourse(int id)
        {
            var q = (from m in obj.Courses where m.Id==id select m).Single();
            
            
            return View(q);

            

        }
        [HttpPost]

        public ActionResult EditCourse(Cours c)
        {
            var q = (from m in obj.Courses where m.Id==c.Id select m).Single();

            
            
            q.students = c.students;
            q.C_teacher = c.C_teacher;
            q.course_grade = c.course_grade;
            
          
            q.course_grade = c.course_grade;
            
            obj.SaveChanges();

            return RedirectToAction("ShowCourse");
        }
        #endregion
        #region
        public ActionResult AddSubject()
        {
            return View();

        }
        [HttpPost]

        public ActionResult AddSubject(Subject s)
        {
            obj.Subjects.Add(s);
            obj.SaveChanges();
            ViewBag.msg = "Data Inserted";

            return View();

        }

        public ActionResult ShowSubject()
        {
            var q = (from m in obj.Subjects select m).ToList();
            return View(q);
        }

        public ActionResult DeleteSubject(int id)
        {
            var q = (from m in obj.Subjects where m.Id==id select m).Single();
            obj.Subjects.Remove(q);
            obj.SaveChanges();

            return RedirectToAction("ShowSubject");

        }

        public ActionResult EditSubject(int id)
        {
            var q = (from m in obj.Subjects where m.Id==id select m).Single();
            
            
            return View(q);

        }
        [HttpPost]
        public ActionResult EditSubject(Subject s)
        {
            var q = (from m in obj.Subjects where m.Id==s.Id select m).Single();


            q.coursename = s.coursename;
            q.teacher_name = s.teacher_name;
            q.subject_grade = s.subject_grade;
            

            obj.SaveChanges();

            return RedirectToAction("ShowSubject");
        }
        #endregion


    }








}