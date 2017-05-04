using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleCilentMVC.Services;
using System.Threading.Tasks;
using BO;

namespace SampleCilentMVC.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public async Task<ActionResult> Index()
        {
            KategoriServices kategoriService = new KategoriServices();
            var model = await kategoriService.GetAll();

            return View(model);
        }

        // GET: Kategori/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategori/Create
        [HttpPost]
        public async Task<ActionResult> Create(Kategori obj)
        {
            KategoriServices kategoriService = new KategoriServices();
            if (ModelState.IsValid)
            {
                try
                {
                    await kategoriService.Insert(obj);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "<span class='alert alert-danger'>" + ex.Message + "</span>";
                }
            }
            return View();
        }

        // GET: Kategori/Edit/5
        public ActionResult Edit(string id)
        {


            return View();
        }

        // POST: Kategori/Edit/5
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

        // GET: Kategori/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kategori/Delete/5
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
