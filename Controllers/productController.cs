using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppEntityFramework;

namespace WebAppEntityFramework.Controllers
{
    public class productController : Controller
    {
        private NEWDBEntities db = new NEWDBEntities();

        // GET: product
        public ActionResult Index()
        {
            return View(db.producttables.ToList());
        }

        // GET: product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producttable producttable = db.producttables.Find(id);
            if (producttable == null)
            {
                return HttpNotFound();
            }
            return View(producttable);
        }

        // GET: product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,productname,price,description,type,datepurchased")] producttable producttable)
        {
            if (ModelState.IsValid)
            {
                db.producttables.Add(producttable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producttable);
        }

        // GET: product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producttable producttable = db.producttables.Find(id);
            if (producttable == null)
            {
                return HttpNotFound();
            }
            return View(producttable);
        }

        // POST: product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,productname,price,description,type,datepurchased")] producttable producttable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producttable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producttable);
        }

        // GET: product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producttable producttable = db.producttables.Find(id);
            if (producttable == null)
            {
                return HttpNotFound();
            }
            return View(producttable);
        }

        // POST: product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producttable producttable = db.producttables.Find(id);
            db.producttables.Remove(producttable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
