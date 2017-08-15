using AutoMapper;
using POS.Domain.Model.Models;
using POS.Domain.Services;
using POS.Web.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace POS.Web.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderItemsController : ApiController
    {
        private readonly IOrderItemService _orderItemSvc;
        private readonly IOrderService _orderSvc;

        public OrderItemsController()
        {
        }

        public OrderItemsController(IOrderItemService orderItemSvc,
                                    IOrderService orderSvc)
        {
            _orderItemSvc = orderItemSvc;
            _orderSvc = orderSvc;
        }

        // GET  /api/orderitems
        public IHttpActionResult GetOrderItems() 
        {
            try
            {
                var orderItems = _orderItemSvc.GetAll();
                var dto = Mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemDto>>(orderItems);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET /api/orderitems/1
        [Route("api/orders/{orderId}/orderitems/{id}")]
        //[Route("api/orderitems/id")]
        public IHttpActionResult GetOrderItem(int id, int? orderId = null) 
        {
            try
            {
                OrderItem orderItem = null;

                if (orderId == null)
                {
                    orderItem = _orderItemSvc.GetById(id);
                }
                else 
                {
                    var order = _orderSvc.GetById(orderId.Value);
                    if (order == null)
                        return BadRequest("Invalid Order Id !");

                    orderItem = order.Items.SingleOrDefault(oi => oi.OrderId == orderId.Value && oi.Id == id);
                }

                if (orderItem == null)
                    return NotFound();

                var dto = Mapper.Map<OrderItem, OrderItemDto>(orderItem);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        
        [Route("api/orders/{orderid}/orderitems")]
        public IHttpActionResult GetOrderOrderItems(int orderId) 
        {
            try
            {
                var order = _orderSvc.GetById(orderId);
                if (order == null)
                    return NotFound();

                var orderOrderItems = _orderItemSvc.Where(oi => oi.OrderId == orderId);
                var dto = Mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemDto>>(orderOrderItems);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
