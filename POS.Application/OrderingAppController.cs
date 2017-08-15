using POS.Domain.Model.Models;
using POS.Domain.Services;
using POS.Infrastructure.Timing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application
{
    public interface IOrderingAppController : IAppController
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int id);

        Order MakeOrder(int customerId, string employeeId, IEnumerable<OrderItem> items);
    }

    public class OrderingAppController : IOrderingAppController
    {
        // Domain
        private readonly IOrderService _orderSvc;
        private readonly IOrderItemService _orderItemSvc;
        private readonly ICustomerService _customerSvc;
        private readonly IEmployeeService _employeeSvc;
        private readonly IProductService _productSvc;

        // Infrastructure
        private readonly IDateTimeService _dateTimeSvc;

        public OrderingAppController(IOrderService orderSvc,
                                     IOrderItemService orderItemSvc,
                                     ICustomerService customerSvc,
                                     IEmployeeService employeeSvc,
                                     IProductService productSvc,

                                     IDateTimeService dateTimeSvc)
        {
            _orderSvc = orderSvc;
            _orderItemSvc = orderItemSvc;
            _customerSvc = customerSvc;
            _employeeSvc = employeeSvc;
            _productSvc = productSvc;

            _dateTimeSvc = dateTimeSvc;
        }

        public Order MakeOrder(int customerId, string employeeId, IEnumerable<OrderItem> items)
        {
            if (_customerSvc.GetById(customerId) == null)
                throw new Exception(string.Format("{0}{1}", Messages.ErrorMessage.InvalidCustomerId, customerId));

            if (_employeeSvc.GetById(employeeId) == null)
                throw new Exception(string.Format("{0}{1}", Messages.ErrorMessage.InvalidEmployeeId, employeeId));

            //if (orderDate.Date < _dateTimeSvc.Now.Date)
            //    throw new Exception(string.Format("{0}", Messages.ErrorMessage.EarlierThanToday));

            if (items == null)
                throw new Exception(Messages.ErrorMessage.NullOrderItems);
            if(items.Count() == 0)
                throw new Exception(Messages.ErrorMessage.EmptyOrderItems);

            foreach (var item in items) 
            {
                if (_productSvc.GetById(item.ProductId) == null)
                    throw new Exception(string.Format("{0}{1}", Messages.ErrorMessage.InvalidProductId, item.ProductId));
            }

            // create order and order items
            var order = new Order() 
            {
                OrderDate = _dateTimeSvc.Now,
                CustomerId = customerId,
                EmployeeId = employeeId,
                Items = items.ToList()
            };
            _orderSvc.Create(order);

            return order;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderSvc.GetAll();
        }

        public Order GetOrder(int id)
        {
            return _orderSvc.GetById(id);
        }
    }


}
