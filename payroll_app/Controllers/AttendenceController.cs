using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using payroll_app.Data;

namespace payroll_app.Controllers
{
    public class AttendenceController : Controller
    {
        private readonly payroll_app_context _context;
        private readonly IHostingEnvironment _hosting_environment;

        public AttendenceController(payroll_app_context context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hosting_environment = hostingEnvironment;
        }

        // GET: Attendence
       /* public ActionResult Index()
        {
            return View();
        }

        // GET: Attendence/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Attendence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendence/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Attendence/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Attendence/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Attendence/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Attendence/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}