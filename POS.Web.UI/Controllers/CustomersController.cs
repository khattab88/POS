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
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerSvc;

        public CustomersController()
        {
        }

        public CustomersController(ICustomerService customerSvc)
        {
            _customerSvc = customerSvc;
        }

        public ActionResult Index()
        {
            var customers = _customerSvc.GetAll();
            var vm = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
            return View(vm);
        }
	}
}