﻿using ElectronicLogbookModel;
using ElectronicLogbookFunction;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Net;
using System.Data.Entity;

namespace ElectronicLogbookWeb.Controllers
{
    [RoutePrefix("Intern")]
    public class InternController : Controller
    {
        private IFIntern _iFIntern;

        public InternController()
        {
            _iFIntern = new FIntern();

        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var intern = _iFIntern.Read(id);
            return View(intern);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View(new Intern());
        }

        [HttpPost]
        public JsonResult Create(Intern intern)
        {

            try
            {
                intern = _iFIntern.Create(intern);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var intern = _iFIntern.Read(id);
            return View(intern);
        }

        [HttpPost]
        public ActionResult Details(Intern intern)
        {
            try
            {
                _iFIntern.Update(intern);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Intern",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }

        [HttpPost]
        public ActionResult Edit(Intern intern)
        {
            try
            {
                _iFIntern.Update(intern);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [Route("List")]
        [HttpPost]
        public ActionResult List()
        {
            try
            {
                Intern intern = new Intern();
                return Json(_iFIntern.List());
            }
            catch (Exception exception)
            {
                return Json(exception);
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                Intern intern = _iFIntern.Read(id);
                return View(intern);
            }
            catch (Exception ex)
            {
                return View(new Intern());
            }
        }

        [HttpPost]
        public ActionResult Update(Intern intern)
        {
            try
            {
                intern = _iFIntern.Update(intern);
                return Json("");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public ActionResult Delete(Intern intern)
        {
            try
            {
                _iFIntern.Delete(intern);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}