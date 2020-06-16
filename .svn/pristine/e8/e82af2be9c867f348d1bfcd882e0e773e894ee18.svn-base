using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Web.Controllers
{
    public class CommonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserGuide()
        {
            try
            {
                ViewData["Title"] = "User Guide";
                string PrintData = HttpContext.Session.GetString("PrintData");
                if (PrintData != null)
                    ViewBag.PrintData = PrintData;
            }
            catch (Exception)
            {
            }
            return View();
        }
    }
}