using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoGreenV3.Models;
using GoGreenV3.Attributes;

namespace GoGreenV3.Controllers
{
    [AccessDeniedAuthorize(Roles = "Developer, Superuser, Admin, Moderator, Operator")]
    public class MarkerController : Controller
    {
        private MarkerDbContext db = new MarkerDbContext();

        // GET: Marker
        public ActionResult Index(string query, string filter, string sortBy, string sortOrder)
        {
            var list = from m in db.Markers select m;

            if (!String.IsNullOrEmpty(query))
            {
                switch (filter.ToLower())
                {
                    case "type":
                        list = list.Where(m => m.Type.Contains(query));
                        break;
                    case "location":
                        list = list.Where(m => m.Location.Contains(query));
                        break;
                    default:
                        list = list.Where(m => m.Location.Contains(query) || m.Type.Contains(query));
                        break;
                }
            }

            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(sortOrder))
            {
                if (sortOrder.ToLower().Equals("ascending"))
                {
                    list = list.OrderBy(m => (sortBy.Contains("type") ? m.Type : m.Location));
                }
                else
                {
                    list = list.OrderByDescending(m => (sortBy.Contains("type") ? m.Type : m.Location));
                }
            }

            ViewBag.Query = query;
            ViewBag.Filter = filter;
            ViewBag.SortBy = sortBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.NoResult = (list == null ? true : false);

            return View(list.ToList());
        }

        // GET: Marker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkerModel markerModel = db.Markers.Find(id);
            if (markerModel == null)
            {
                return HttpNotFound();
            }
            return View(markerModel);
        }

        // GET: Marker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Latitude,Longitude,Status,Location,Description,IsControllable,IsWorking")] MarkerModel markerModel)
        {
            if (ModelState.IsValid)
            {
                db.Markers.Add(markerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(markerModel);
        }

        // GET: Marker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkerModel markerModel = db.Markers.Find(id);
            if (markerModel == null)
            {
                return HttpNotFound();
            }
            return View(markerModel);
        }

        // POST: Marker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Latitude,Longitude,Status,Location,Description,IsControllable,IsWorking")] MarkerModel markerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(markerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(markerModel);
        }

        // GET: Marker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkerModel markerModel = db.Markers.Find(id);
            if (markerModel == null)
            {
                return HttpNotFound();
            }
            return View(markerModel);
        }

        // POST: Marker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarkerModel markerModel = db.Markers.Find(id);
            db.Markers.Remove(markerModel);
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
