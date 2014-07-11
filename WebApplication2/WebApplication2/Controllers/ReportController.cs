using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ReportController : Controller
    {
        報表Repository clientRepo = RepositoryHelper.Get報表Repository();
        // GET: Report
        public ActionResult Index()
        {
            var data = clientRepo.All();
            return View(data);
        }

        // GET: Report/Details/5
        
    }
}
