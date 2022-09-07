using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebSingleScopeTransient.Interfaces;
using WebSingleScopeTransient.Models;

namespace WebSingleScopeTransient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransientServices _transientService1;
        private readonly ITransientServices _transientService2;
        private readonly IScopeServices _scopedService1;
        private readonly IScopeServices _scopedService2;
        private readonly ISingletonServices _singletonService1;
        private readonly ISingletonServices _singletonService2;

        public HomeController(ILogger<HomeController> logger,
            ITransientServices transientService1,
            ITransientServices transientService2,
            IScopeServices scopedService1,
            IScopeServices scopedService2,
            ISingletonServices singletonService1,
            ISingletonServices singletonService2)
        {
            _logger = logger;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

        public IActionResult Index()
        {
            ViewBag.transient1 = _transientService1.GetTaskID().ToString();
            ViewBag.transient2 = _transientService2.GetTaskID().ToString();
            ViewBag.scoped1 = _scopedService1.GetTaskID().ToString();
            ViewBag.scoped2 = _scopedService2.GetTaskID().ToString();
            ViewBag.singleton1 = _singletonService1.GetTaskID().ToString();
            ViewBag.singleton2 = _singletonService2.GetTaskID().ToString();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
