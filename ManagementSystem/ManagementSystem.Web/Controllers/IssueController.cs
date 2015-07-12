using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Models;
using ManagementSystem.Data;
using Microsoft.AspNet.Identity;

namespace ManagementSystem.Web.Controllers
{
    public class IssueController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Issue/
        public ActionResult Index()
        {
            var issues = db.Issues.Include(i => i.IssueType).Include(i => i.Status);
            return View(issues.ToList());
        }

        // GET: /Issue/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        // GET: /Issue/Create
         [Authorize]
        public ActionResult Create()
        {
            ViewBag.IssueTypeId = new SelectList(db.IssueTypes, "Id", "Name");
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Name");
            return View();
        }

        // POST: /Issue/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,CreatedDate,RequiredByDate,Description,NextActionDate,StatusId,IssueTypeId")] Issue issue)
        {
            var username = this.User.Identity.GetUserName();
            var userId = this.User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                issue.UserId = userId;
                db.Issues.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IssueTypeId = new SelectList(db.IssueTypes, "Id", "Name", issue.IssueTypeId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Name", issue.StatusId);
            return View(issue);
        }

        // GET: /Issue/Edit/5
         [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            ViewBag.IssueTypeId = new SelectList(db.IssueTypes, "Id", "Name", issue.IssueTypeId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Name", issue.StatusId);
            return View(issue);
        }

        // POST: /Issue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,CreatedDate,RequiredByDate,Description,NextActionDate,StatusId,IssueTypeId")] Issue issue)
        {
            var username = this.User.Identity.GetUserName();
            var userId = this.User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                issue.UserId = userId;
                db.Entry(issue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IssueTypeId = new SelectList(db.IssueTypes, "Id", "Name", issue.IssueTypeId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Name", issue.StatusId);
            return View(issue);
        }

        // GET: /Issue/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        // POST: /Issue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Issue issue = db.Issues.Find(id);
            db.Issues.Remove(issue);
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
