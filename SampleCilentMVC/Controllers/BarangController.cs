using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BO;
using ServicesBackend;
using System.Threading.Tasks;

namespace SampleCilentMVC.Controllers
{
    public class BarangController : Controller
    {
        // GET: Barang
        public async Task<ActionResult> Index()
        {
            BarangServices barangServices = new BarangServices();
            var models = await barangServices.GetAllBarangKategoriMap();

            if (TempData["SuccessMessage"] != null)
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            return View(models);
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
        public async Task<ActionResult> Create(Barang obj)
        {
            BarangServices barangServices = new BarangServices();
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await barangServices.Insert(obj);

                    TempData["SuccessMessage"] = "<span class='alert alert-success'>" + result + "</span>";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "<span class='alert alert-danger'>" + ex.Message + "</span>";

                }
            }
            return View();
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
