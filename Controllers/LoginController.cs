using Alkemy_1.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Alkemy_1.Models;
using System.Web;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Alkemy_1.DTO;

namespace Alkemy_1.Controllers
{
    public class LoginController : Controller
    {
        private readonly dBaseContext _context; 
        public const string sessionkeyname = "mater_user";
        public const string sessionpass = "pas_";


        public LoginController(dBaseContext context)
        {
            _context = context;
        }
        public ActionResult Login()
        {
            return View();
        }


        public  ActionResult Logger (LogDTO Log_)
        {
            
            try
            {
                if (Log_.IsStudent is false)
                {

                    var obj = _context.Log.ToList().Where(a => a.master_user.Equals(Log_.username) && a.pass_.Equals(Log_.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        HttpContext.Session.SetString(sessionkeyname, (obj.master_user.ToString()));
                        HttpContext.Session.SetString(sessionpass, obj.pass_.ToString());
                        return Redirect("/Home/Index");
                    }
                }
                else
                {
                    var obj = _context.Students.ToList().Where(a => a.dni.Equals(Log_.username) && a.file.Equals(Log_.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        HttpContext.Session.SetString(sessionkeyname, (obj.dni.ToString()));
                        HttpContext.Session.SetString(sessionpass, obj.file.ToString());
                        return Redirect("/Home/Index");
                    }
                }
            }
            catch (Exception e)
            {

                throw e ;
            }

            return Redirect("/Login");
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
