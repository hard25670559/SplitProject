using Core.Models;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Core.Setting;

namespace SplitProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Model> list = RepositoryFactory.Repository(Alias.Employee).Read();
            //this.TryUpdateModel<Employee>(new Employee
            //{
            //
            //});
            //return View(list.Cast<Employee>());
            return HttpNotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            dynamic DB = null;

            DB.Employee.Add(model);

            return RedirectToAction("Index");
        }

        public ActionResult Empolyee()
        {
            List<Model> list = RepositoryFactory.Repository(Alias.Employee).Read();
            return View(list.Cast<Employee>());
        }
    }
}