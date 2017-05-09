using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JudoTournamentBase.Models;
using System.Globalization;
using JudoTournamentBase.Enums;
using JudoTournamentBase.Utils;

namespace JudoTournamentBase.Controllers
{
    public class CompetitorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [RequireHttps]
        [Authorize]
        // GET: Competitors
        public ActionResult Index(string sortOrder, string categoryId, string clubId)
        {
            var competitors = db.Competitors.Include(c => c.Category).Include(c => c.Club);
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight), "Id", "Name");
            ViewBag.ClubId = new SelectList(db.Clubs, "Id", "Name");

            // Filtering
            if (!String.IsNullOrEmpty(categoryId))
            {
                ViewBag.Category = categoryId;
                competitors = competitors.Where(c => categoryId.Equals(c.CategoryId.ToString()));
            }
            if (!String.IsNullOrEmpty(clubId))
            {
                ViewBag.Club = clubId;
                competitors = competitors.Where(c => clubId.Equals(c.ClubId.ToString()));
            }

            //Sorting
            ViewBag.CategorySort = sortOrder == "category" ? "category_desc" : "category";
            ViewBag.ClubSort = sortOrder == "club" ? "club_desc" : "club";

            switch (sortOrder)
            {
                case "category":
                    competitors = competitors.OrderBy(c => c.Category.Gender).ThenBy(c => c.Category.Age).ThenBy(c => c.Category.Weight);
                    break;
                case "category_desc":
                    competitors = competitors.OrderByDescending(c => c.Category.Gender).ThenBy(c => c.Category.Age).ThenBy(c => c.Category.Weight);
                    break;
                case "club":
                    competitors = competitors.OrderBy(c => c.Club.Name);
                    break;
                case "club_desc":
                    competitors = competitors.OrderByDescending(c => c.Club.Name);
                    break;              
                default:
                    competitors = competitors.OrderBy(c => c.DateCreated);
                    break;
            }

            return View(competitors.ToList());
        }
        [RequireHttps]
        [Authorize]
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
        [RequireHttps]
        [Authorize]
        // GET: Competitors/Create
        public ActionResult Create()
        {
            Session["Gender"] = (int)GenderEnum.FEMALE;
            Session["Age"] = 999;
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.Gender == (int)GenderEnum.FEMALE).OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight), "Id", "Name");
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
        [RequireHttps]
        [Authorize]
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
            Session["Gender"] = (int)competitor.Gender;
            Session["Age"] = competitor.Category.Age;

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c=> c.Gender == competitor.Gender && c.Age == competitor.Category.Age).OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight), "Id", "Name", competitor.CategoryId);
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
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.Gender == competitor.Gender && c.Age == competitor.Category.Age).OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight), "Id", "Name", competitor.CategoryId);
            ViewBag.ClubId = new SelectList(db.Clubs, "Id", "Name", competitor.ClubId);
            return View(competitor);
        }
        [RequireHttps]
        [Authorize]
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
        [HttpPost]
        public ActionResult GetCategoriesByGender(int gender)
        {
            Session["Gender"] = gender;
            var categoryAge = Convert.ToInt32(Session["Age"]);
            var categories = db.Categories.Where(c => (int)c.Gender == gender && (int)c.Age == categoryAge).OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight).ToList();

            if (categoryAge == 999)
            {
                categories = db.Categories.Where(c => (int)c.Gender == gender).OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight).ToList();
            }

            SelectList categoriesList = new SelectList(categories, "Id", "Name");
            return Json(categoriesList);
        }
        [HttpPost]
        public ActionResult GetCategoriesByDate(string date)
        {       
            var categoryAge = 0;
            var gender = Convert.ToInt32(Session["Gender"]);

            try
            {

                var birthDate = DateTime.ParseExact(date, "d.M.yyyy", CultureInfo.InvariantCulture);
                var years = DateTime.Now.Year - birthDate.Year;
                
                if (years < 8)
                    categoryAge = 8;
                else if (years < 10)
                    categoryAge = 10;
                else if (years < 12)
                    categoryAge = 12;
                else if (years < 14)
                    categoryAge = 14;
                else if (years < 16)
                    categoryAge = 16;
                else if (years < 18)
                    categoryAge = 18;

                Session["Age"] = categoryAge;
            }
            catch (Exception)
            {
                return Json(new SelectList(db.Categories.Where(c => (int)c.Gender == 0).OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight).ToList(), "Id", "Name"));
            }

            var categories = db.Categories.Where(c => (int)c.Gender == gender && (int)c.Age == categoryAge).OrderBy(c => c.Gender).ThenBy(c => c.Age).ThenBy(c => c.Weight).ToList();
            SelectList categoriesList = new SelectList(categories, "Id", "Name");
            return Json(categoriesList);
        }
        public ActionResult Export(string categoryId, string clubId)
        {
            var fileDownloadName = Resources.Localization.Competitors + "-" + DateTime.Now.ToShortDateString() + ".xlsx";
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var reportUtils = new ReportUtils();

            var fileStream = reportUtils.GenerateReport(categoryId, clubId);
            if (fileStream != null)
            {
                var fsr = new FileStreamResult(fileStream, contentType) { FileDownloadName = fileDownloadName };
                return fsr;
            }
            else
            {
                return RedirectToAction("Index", "Competitors", new { errors = true });
            }
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
