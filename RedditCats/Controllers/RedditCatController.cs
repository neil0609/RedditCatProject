using RedditCats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedditCats.Controllers
{
    public class RedditCatController : Controller
    {
        // GET: RedditCat
        public ActionResult Index()
        {
            IEnumerable<RedditPost> model = RedditCatPost.GetAll();
            return View(model);
        }
    }
}