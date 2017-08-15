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
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderSvc;
        private readonly IOrderItemService _orderItemSvc;
        private readonly ICustomerService _customerSvc;
        private readonly IEmployeeService _employeeSvc;
        private readonly IProductService _productSvc;

        public OrdersController()
        {
        }

        public OrdersController(IOrderService orderSvc,
                                IOrderItemService orderItemSvc,
                                ICustomerService customerSvc,
                                IEmployeeService employeeSvc,
                                IProductService productSvc)
        {
            _orderSvc = orderSvc;
            _orderItemSvc = orderItemSvc;
            _customerSvc = customerSvc;
            _employeeSvc = employeeSvc;
            _productSvc = productSvc;
        }

        public ActionResult Index()
        {
            var orders = _orderSvc.GetAll();                

            var vm = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);

            return View(vm);
        }

        [Authorize]
        public ActionResult Create()
        {
            var employeeId = _employeeSvc.GetByUserName(User.Identity.Name).Id;

            var customers = _customerSvc.GetAll();
            var customerList = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);

            var products = _productSvc.GetAll();
            var productList = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            var vm = new OrderFormViewModel() 
            {
                EmployeeId = employeeId,

                CustomerList = customerList,
                ProductList = productList
            };

            return View(vm);
        }

	}
}