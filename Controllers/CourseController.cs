using Alkemy_1.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Alkemy_1.Models;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Alkemy_1.DTO;

namespace Alkemy_1.Controllers
{
    public class CourseController : Controller
    {
        private readonly dBaseContext _context;

        public CourseController(dBaseContext context)
        {
            _context = context;
        }
        /*  */
        public async Task<IActionResult> Index()
        {
           // if (string.IsNullOrEmpty(HttpContext.Session.GetString("master_user")))
            //{
              //  return Redirect("/Login");
            //}
            return View(_context.Courses.ToList());
        }

        public async Task<IActionResult>  Details(int id)
        {
            var obj = _context.Courses.Include(c => c.Professor).Include(c => c.Inscriptions).ToList().Where(a => a.courseId.Equals(id)).FirstOrDefault();
            if (obj != null) return View(obj);
            else return Redirect("/Home/Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var professors = _context.Professors.ToList();
            var obj = _context.Courses.Include(c => c.Professor).Include(c => c.Inscriptions).ToList().Where(a => a.courseId.Equals(id)).FirstOrDefault();
            Professor_Course_DTO PF = new Professor_Course_DTO();
            PF.Course_Complete = obj;
            PF.Professors = professors;
            if (obj != null) return View(PF);
            else return Redirect("/Home/Index");
        }



        public async Task<IActionResult> Update(Professor_Course_DTO PF_)
        {
            if (PF_.Course_Complete.courseId == null)
            {
                return NotFound();
            }
            var CoursetoUpdate = await _context.Courses.FirstOrDefaultAsync(s => s.courseId == PF_.Course_Complete.courseId);

            CoursetoUpdate.maximum_quantity_students = PF_.Course_Complete.maximum_quantity_students;
            CoursetoUpdate.professorId = PF_.Course_Complete.professorId;
            CoursetoUpdate.Title = PF_.Course_Complete.Title;

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                 
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            
            return View(CoursetoUpdate);
        }
        public async Task<IActionResult> Delete (int id)
        {
            var course_to = await _context.Courses.FindAsync(id);
            if (course_to == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Courses.Remove(course_to);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }


        public async Task<IActionResult> Create ()
        {
            var professors = _context.Professors.ToList();
            Professor_Course_DTO PF = new Professor_Course_DTO();
            course cr = new course();
            PF.Course_Complete = cr;
            PF.Professors = professors;
             return View(PF);           
        }

        public async Task<IActionResult> JustCreate(Professor_Course_DTO NewCourse)
            {
            
            try
            {
                    if (ModelState.IsValid)
                    {
                        _context.Add(NewCourse.Course_Complete);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateException /* ex */)
                {
               
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists " +
                        "see your system administrator.");
                }
                return Redirect("/Home/Index");
            }

    }
}
