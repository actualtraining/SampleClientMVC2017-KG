using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleCilentMVC.Controllers
{
    public class BarangController : Controller
    {
        // GET: Barang
        public ActionResult Index()
        {
            return View();
        }

        // GET: Barang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Barang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Barang/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Barang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Barang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Barang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Barang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
