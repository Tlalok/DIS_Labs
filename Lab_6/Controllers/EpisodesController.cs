using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab_6.Models;

namespace Lab_6.Controllers
{
    public class EpisodesController : Controller
    {
        private SeriesContext db = new SeriesContext();

        // GET: Episodes
        public ActionResult Index()
        {
            var episodes = db.Episodes.Include(e => e.Series);
            return View(episodes.ToList());
        }

        // GET: Episodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Episode episode = db.Episodes.Find(id);
            if (episode == null)
            {
                return HttpNotFound();
            }
            return View(episode);
        }

        // GET: Episodes/Create
        public ActionResult Create()
        {
            ViewBag.SeriesId = new SelectList(db.Series, "Id", "Name");
            return View();
        }

        // POST: Episodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SeriesId,Name,Duration,ReleaseDate")] Episode episode)
        {
            if (ModelState.IsValid)
            {
                db.Episodes.Add(episode);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Index", "Home");
            }

            ViewBag.SeriesId = new SelectList(db.Series, "Id", "Name", episode.SeriesId);
            return View(episode);
        }

        // GET: Episodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Episode episode = db.Episodes.Find(id);
            if (episode == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeriesId = new SelectList(db.Series, "Id", "Name", episode.SeriesId);
            return View(episode);
        }

        // POST: Episodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SeriesId,Name,Duration,ReleaseDate")] Episode episode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(episode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeriesId = new SelectList(db.Series, "Id", "Name", episode.SeriesId);
            return View(episode);
        }

        // GET: Episodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Episode episode = db.Episodes.Find(id);
            if (episode == null)
            {
                return HttpNotFound();
            }
            return View(episode);
        }

        // POST: Episodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Episode episode = db.Episodes.Find(id);
            db.Episodes.Remove(episode);
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
