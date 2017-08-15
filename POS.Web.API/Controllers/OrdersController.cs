using AutoMapper;
using POS.Application;
using POS.Domain.Model.Models;
using POS.Web.API.Dtos;
using System;
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
    public class OrdersController : ApiController
    {
        // App Controllers
        private readonly IOrderingAppController _orderingAppCtrl;

        public OrdersController()
        {
        }

        public OrdersController(IOrderingAppController orderingAppCtrl)
        {
            _orderingAppCtrl = orderingAppCtrl;
        }

        // GET /api/orders
        public IHttpActionResult GetOrders() 
        {
            try
            {
                var orders = _orderingAppCtrl.GetAllOrders();
                var dto = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET  /api/orders/1
        public IHttpActionResult GetOrder(int id) 
        {
            try
            {
                var order = _orderingAppCtrl.GetOrder(id);
                if (order == null)
                    return NotFound();

                var dto = Mapper.Map<Order, OrderDto>(order);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //POST  /api/products
        [HttpPost]
        [ResponseType(typeof(OrderDto))]
        public IHttpActionResult CreateOrder(OrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var items = Mapper.Map<List<OrderItemDto>, List<OrderItem>>(dto.Items);
                var order = _orderingAppCtrl.MakeOrder(dto.CustomerId, dto.EmployeeId, items);

                var orderDto = Mapper.Map<Order, OrderDto>(order);

                return Ok(orderDto);
            }
            catch (Exception ex) 
            {
                return InternalServerError(ex);
            }
        }

    }
}
