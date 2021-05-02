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

namespace Alkemy_1.Controllers
{
    public class InscriptionController : Controller
    {
        private readonly dBaseContext _context;

        public InscriptionController(dBaseContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
         //   if (string.IsNullOrEmpty(HttpContext.Session.GetString("master_user")))
          //  {
              //  return Redirect("/Login");

          //  }
            return View(_context.Inscriptions.ToList());
        }
    }
}
