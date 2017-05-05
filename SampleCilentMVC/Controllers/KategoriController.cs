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
        public async Task<ActionResult> Edit(string id)
        {
            KategoriServices kategoriService = new KategoriServices();
            var model = await kategoriService.GetById(id);

            return View(model);
        }

        // POST: Kategori/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Kategori obj)
        {
            KategoriServices kategoriService = new KategoriServices();
            if (ModelState.IsValid)
            {
                try
                {
                    await kategoriService.Update(obj);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ViewBag.Error = "<span class='alert alert-danger'>" + ex.Message + "</span>";
                }
            }
            return View();
        }

        // GET: Kategori/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            KategoriServices kategoriService = new KategoriServices();
            var model = await kategoriService.GetById(id);

            return View(model);
        }

        // POST: Kategori/Delete/5
        [HttpPost,ActionName("Delete")]
        public async Task<ActionResult> DeletePost(string id)
        {
            KategoriServices kategoriService = new KategoriServices();
            try
            {
                await kategoriService.Delete(id);               
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "<span class='alert alert-danger'>" + ex.Message + "</span>";
                return View();
            }
        }
    }
}
