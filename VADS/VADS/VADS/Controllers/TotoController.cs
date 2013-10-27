using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VADS.Models;

namespace VADS.Controllers
{
    public class TotoController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Toto/

        public ActionResult Index()
        {
            db.TotoModels.Select(model => new SelectListItem()
                                              {
                                                  Value = model.TotoId.ToString(), Text = model.TotoName
                                              });
            return View(db.TotoModels.ToList());
        }

        //
        // GET: /Toto/Details/5

        public ActionResult Details(int id = 0)
        {
            TotoModel totomodel = db.TotoModels.Find(id);
            if (totomodel == null)
            {
                return HttpNotFound();
            }
            return View(totomodel);
        }

        //
        // GET: /Toto/Create

        public ActionResult CreateToto(int totoId, string totoName)
        {
            var Totomodel = new TotoModel()
                                {
                                    TotoId = totoId,
                                    TotoName = totoName
                                };
            if (ModelState.IsValid)
            {
                db.TotoModels.Add(Totomodel);
                db.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Toto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TotoModel totomodel)
        {
            if (ModelState.IsValid)
            {
                db.TotoModels.Add(totomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(totomodel);
        }

        //
        // GET: /Toto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TotoModel totomodel = db.TotoModels.Find(id);
            if (totomodel == null)
            {
                return HttpNotFound();
            }
            return View(totomodel);
        }

        //
        // POST: /Toto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TotoModel totomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(totomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(totomodel);
        }

        //
        // GET: /Toto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TotoModel totomodel = db.TotoModels.Find(id);
            if (totomodel == null)
            {
                return HttpNotFound();
            }
            return View(totomodel);
        }

        //
        // POST: /Toto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TotoModel totomodel = db.TotoModels.Find(id);
            db.TotoModels.Remove(totomodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}