using AutoMapper;
using POS.Domain.Model.Models;
using POS.Domain.Services;
using POS.Web.API.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace POS.Web.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService _customerSvc;

        public CustomersController()
        {
        }

        public CustomersController(ICustomerService customerSvc)
        {
            _customerSvc = customerSvc;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<CustomerDto>))]
        public IHttpActionResult GetCustomers() 
        {
            var customers = _customerSvc.GetAll();
            var dto = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);
            return Ok(dto);
        }
    }
}
