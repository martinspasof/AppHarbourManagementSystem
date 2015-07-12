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
    public class CommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Comment/
        public ActionResult Index()
        {
           var comments = db.Comments.Include(c => c.Author).Include(c => c.CommentType).Include(c => c.Issue);
            
            return View(comments.ToList());
        }

        // GET: /Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: /Comment/Create
         [Authorize]
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.CommentTypeId = new SelectList(db.CommentTypes, "Id", "Name");
            ViewBag.IssueId = new SelectList(db.Issues, "Id", "Name");
            
                return View();       
          
        }

        // POST: /Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult Create([Bind(Include="Id,DateAdded,ReminderDate,AuthorId,IssueId,Content,CommentTypeId")] Comment comment)
        {
            var username = this.User.Identity.GetUserName();
            var userId = this.User.Identity.GetUserId();
            
            if (ModelState.IsValid)
            {
                comment.AuthorId = userId;
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Users, "Id", "UserName", comment.AuthorId);
            ViewBag.CommentTypeId = new SelectList(db.CommentTypes, "Id", "Name", comment.CommentTypeId);
            ViewBag.IssueId = new SelectList(db.Issues, "Id", "Name", comment.IssueId);
            return View(comment);
        }

        // GET: /Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "Name", comment.AuthorId);
            ViewBag.CommentTypeId = new SelectList(db.CommentTypes, "Id", "Name", comment.CommentTypeId);
            ViewBag.IssueId = new SelectList(db.Issues, "Id", "Name", comment.IssueId);
            return View(comment);
        }

        // POST: /Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DateAdded,ReminderDate,AuthorId,IssueId,Content,CommentTypeId")] Comment comment)
        {
            var username = this.User.Identity.GetUserName();
            var userId = this.User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                comment.AuthorId = userId;
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "UserName", comment.AuthorId);
            ViewBag.CommentTypeId = new SelectList(db.CommentTypes, "Id", "Name", comment.CommentTypeId);
            ViewBag.IssueId = new SelectList(db.Issues, "Id", "Name", comment.IssueId);
            return View(comment);
        }

        // GET: /Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
