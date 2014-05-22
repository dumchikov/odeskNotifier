﻿using System;
using System.Web.Mvc;
using OdeskNotifier.Services;

namespace OdeskNotifier.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var scheduler = new Sheduler();
            var notificationService = new OdeskNotificationsService();
            scheduler.RunProcessByTime(DateTime.Now.AddMinutes(1), notificationService.Notify);
            return View();
        }
    }
}