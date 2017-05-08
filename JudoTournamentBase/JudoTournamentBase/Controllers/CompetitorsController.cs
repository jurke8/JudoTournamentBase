using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JudoTournamentBase.Models;

namespace JudoTournamentBase.Controllers
{
    public class CompetitorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Competitors
        public ActionResult Index()
        {
            var competitors = db.Competitors.Include(c => c.Category).Include(c => c.Club);
            return View(competitors.ToList());
        }

        // GET: Competitors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competitor competitor = db.Competitors.Find(id);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            return View(competitor);
        }

        // GET: Competitors/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight), "Id", "Name");
            ViewBag.ClubId = new SelectList(db.Clubs, "Id", "Name");
            return View();
        }

        // POST: Competitors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Gender,DateOfBirth,CategoryId,ClubId,DateCreated")] Competitor competitor)
        {
            if (ModelState.IsValid)
            {
                competitor.Id = Guid.NewGuid();
                db.Competitors.Add(competitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight), "Id", "Name", competitor.CategoryId);
            ViewBag.ClubId = new SelectList(db.Clubs, "Id", "Name", competitor.ClubId);
            return View(competitor);
        }

        // GET: Competitors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competitor competitor = db.Competitors.Find(id);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight), "Id", "Name", competitor.CategoryId);
            ViewBag.ClubId = new SelectList(db.Clubs, "Id", "Name", competitor.ClubId);
            return View(competitor);
        }

        // POST: Competitors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Gender,DateOfBirth,CategoryId,ClubId,DateCreated")] Competitor competitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight), "Id", "Name", competitor.CategoryId);
            ViewBag.ClubId = new SelectList(db.Clubs, "Id", "Name", competitor.ClubId);
            return View(competitor);
        }

        // GET: Competitors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competitor competitor = db.Competitors.Find(id);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            return View(competitor);
        }

        // POST: Competitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Competitor competitor = db.Competitors.Find(id);
            db.Competitors.Remove(competitor);
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
