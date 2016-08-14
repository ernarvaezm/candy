using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Postal;
using ApiCandyCrush.Models;

namespace ApiCandyCrush.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Contact()
        {
            return View();

        }

        public ActionResult sendMail(string name, string correo, string message)
        {
            NewEmail email = new NewEmail
            {
                To = "j_pablo_s_s@hotmail.com",
                Subject = "Se solicita Informsacion",
                name = name,
                correo = correo,
                message = message
            };
            TempData["Correo"] = email;
            return RedirectToAction("Send");
        }

        public ActionResult Send()
        {
            if (TempData["Correo"] != null)
            {
                NewEmail correo = (NewEmail)TempData["Correo"];
                correo.Send();
            }
            return RedirectToAction("Index");
        }
    }
}
