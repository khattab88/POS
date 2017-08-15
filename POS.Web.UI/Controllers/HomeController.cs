using AutoMapper;
using POS.Domain.Model.Models;
using POS.Domain.Services;
using POS.Web.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productSvc;

        public HomeController()
        {
        }

        public HomeController(IProductService productSvc)
        {
            _productSvc = productSvc;
        }

        public ActionResult Index()
        {
            return View();
        }
	}
}