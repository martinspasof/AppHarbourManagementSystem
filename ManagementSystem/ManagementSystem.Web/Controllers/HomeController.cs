using ManagementSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementSystem.Web.Controllers
{
    public class HomeController : BaseController
    {           
        public ActionResult Index()
        {
            
            var listsOfIssues = this.Data.Issues.All()
                .OrderByDescending(x => x.Comments.Count())
                .Select(x => new IssueViewModel {
                     Id = x.Id,
                     CreatedDate = x.CreatedDate,
                     RequiredByDate = x.RequiredByDate,
                     Description = x.Description,
                     Status = x.Status.Name,
                     Type = x.Status.Name,
                     Name = x.Name
                });



            return View(listsOfIssues.ToList());
        }

       
    }
}