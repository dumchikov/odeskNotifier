using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ConsoleApplication3.Entities;
using OdeskNotifier.Services;

namespace OdeskNotifier.Controllers
{
    public class HomeController : Controller
    {
        private readonly OdeskRssReader _odeskRssReader = new OdeskRssReader();

        public ActionResult Index(string query)
        {
            var queries = new[]
                {
                    ".net-framework",
                    "asp.net",
                    "javascript",
                    "html",
                    "angularjs"
                }.OrderBy(x => x);


            List<Tuple<string, IList<OdeskJobItem>>> model = queries
                .Select(x => Tuple.Create(x, _odeskRssReader.GetData(x)))
                .ToList();

            return View(model);
        }
    }
}
