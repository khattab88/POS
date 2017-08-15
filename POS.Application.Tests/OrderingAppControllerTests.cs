using Moq;
using NUnit.Framework;
using POS.Domain.Model.Models;
using POS.Domain.Services;
using POS.Infrastructure.Timing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Tests
{
    [TestFixture]
    public class OrderingAppControllerTests
    {
        // SUT
        private IOrderingAppController _orderingAppCtrl;

        // Dependencies
        private IOrderService _mockOrderSvc;
        private IOrderItemService _mockOrderItemSvc;
        private ICustomerService _mockCustomerSvc;
        private IEmployeeService _mockEmployeeSvc;
        private IProductService _mockProductSvc;

        private IDateTimeService _mockDateTimeSvc;

        private static List<Product> _products = new List<Product>() 
        {
            new Product()
            {
                Id = 1,
                Name = "product 1",
                Price = 1000
            },
            new Product()
            {
                Id = 2,
                Name = "product 2",
                Price = 2000
            },
        };

        private static List<OrderItem> _items = new List<OrderItem>()
            {
                new OrderItem()
                    {
                        Id = 1,
                        OrderId = 1,
                        ProductId = 1,
                        Quantity = 3
                    },
                    new OrderItem()
                    {
                        Id = 2,
                        OrderId = 1,
                        ProductId = 2,
                        Quantity = 5
                    }
            };

        private static Order _newOrder = new Order()
        {
            Id = 1,
            OrderDate = new DateTime(2017, 8, 8),
            EmployeeId = "1",
            CustomerId = 1,
            Items = _items
        };

        [TestFixtureSetUp]
        public void TestClassSetup()
        {
            // Dependencies
            var mockOrderSvc = new Mock<IOrderService>();
            //mockOrderSvc.Setup(n => n.GetAll())
            //    .Returns(_orders);
            //mockOrderSvc.Setup(n => n.Create(newOrder));
                //.Callback(() => _orders.Add(newOrder));
            _mockOrderSvc = mockOrderSvc.Object;

            var mockOrderItemSvc = new Mock<IOrderItemService>();
            _mockOrderItemSvc = mockOrderItemSvc.Object;

            var mockCustomerSvc = new Mock<ICustomerService>();
            mockCustomerSvc.Setup(n => n.GetById(1))
                .Returns(new Customer() 
                {
                    Id = 1,
                    FirstName = "Martin",
                    LastName = "Fowler"
                });
            _mockCustomerSvc = mockCustomerSvc.Object;

            var mockEmployeeSvc = new Mock<IEmployeeService>();
            mockEmployeeSvc.Setup(n => n.GetById("1"))
                .Returns(new ApplicationUser() 
                {
                    FirstName = "Uncle",
                    LastName = "Bob"
                });
            _mockEmployeeSvc = mockEmployeeSvc.Object;

            var mockProductSvc = new Mock<IProductService>();
            mockProductSvc.Setup(n => n.GetById(1))
                .Returns(_products.Find(p => p.Id == 1));
            mockProductSvc.Setup(n => n.GetById(2))
                .Returns(_products.Find(p => p.Id == 2));
            _mockProductSvc = mockProductSvc.Object;

            var mockDateTimeSvc = new Mock<IDateTimeService>();
            mockDateTimeSvc.Setup(n => n.Now)
                .Returns(new DateTime(2017, 8, 8));
            _mockDateTimeSvc = mockDateTimeSvc.Object;

            // SUT
            _orderingAppCtrl = new OrderingAppController(_mockOrderSvc,
                                                         _mockOrderItemSvc,
                                                         _mockCustomerSvc,
                                                         _mockEmployeeSvc,
                                                         _mockProductSvc,
                                                         _mockDateTimeSvc);
        }

        [Test]
        public void MakeOrder_SuccessScenario_ReturnsValidOrder() 
        {
            // Arrange
            int orderId = 1;
            DateTime orderDate = _mockDateTimeSvc.Now;
            int customerId = 1;
            string employeeId = "1";
            var items = _items;

            var expected = _newOrder;

            // Act
            var actual = _orderingAppCtrl.MakeOrder(customerId, employeeId, items);

            // Assert
            //Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.OrderDate, actual.OrderDate);
            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.EmployeeId, actual.EmployeeId);

            Assert.NotNull(actual.Items);
            Assert.AreEqual(expected.Items.Count, actual.Items.Count);

            // Assert order items
            for (int i = 0; i < expected.Items.Count; i++)
            {
                Assert.AreEqual(expected.Items.ToList()[i].Id, actual.Items.ToList()[i].Id);
            } 
        }

        [Test]
        public void MakeOrder_InvalidCustomerId_ThrowsCustomerNotFoundException() 
        {
            var invalidCustomerId = 10;

            var expectedException = new Exception(string.Format("{0}{1}" ,Messages.ErrorMessage.InvalidCustomerId, invalidCustomerId));

            var actualException = Assert.Throws(typeof(Exception),
                                                delegate
                                                {
                                                    _orderingAppCtrl.MakeOrder(invalidCustomerId, "1", null);
                                                });

            Assert.AreEqual(expectedException.Message, actualException.Message);
        }

        [Test]
        public void MakeOrder_InvalidEmployeeId_ThrowsEmployeeNotFoundException()
        {
            var invalidEmployeeId = "10";

            var expectedException = new Exception(string.Format("{0}{1}", Messages.ErrorMessage.InvalidEmployeeId, invalidEmployeeId));

            var actualException = Assert.Throws(typeof(Exception),
                                                delegate
                                                {
                                                    _orderingAppCtrl.MakeOrder(1, invalidEmployeeId, null);
                                                });

            Assert.AreEqual(expectedException.Message, actualException.Message);
        }

        [Test]
        public void MakeOrder_NullOrderItemsParameter_ThrowsOrderItemsCanNotBeNullException() 
        {
            var expectedException = new Exception(string.Format("{0}", Messages.ErrorMessage.NullOrderItems));

            var actualException = Assert.Throws(typeof(Exception),
                                                delegate
                                                {
                                                    _orderingAppCtrl.MakeOrder(1, "1", null);
                                                });

            Assert.AreEqual(expectedException.Message, actualException.Message);
        }

        [Test]
        public void MakeOrder_EmptyOrderItemsParameter_ThrowsOrderItemsCanNotBeEmptyException()
        {
            var expectedException = new Exception(string.Format("{0}", Messages.ErrorMessage.EmptyOrderItems));

            var actualException = Assert.Throws(typeof(Exception),
                                                delegate
                                                {
                                                    _orderingAppCtrl.MakeOrder(1, "1", new List<OrderItem>());
                                                });

            Assert.AreEqual(expectedException.Message, actualException.Message);
        }

        [Test]
        public void MakeOrder_InvalidProductId_ThrowsProductNotFoundException()
        {
            var invalidProductId = 10;
            var item = new OrderItem()
            {
                ProductId = invalidProductId,
                OrderId = 1,
                Quantity = 3
            };

            var expectedException = new Exception(string.Format("{0}{1}", Messages.ErrorMessage.InvalidProductId, invalidProductId));

            var actualException = Assert.Throws(typeof(Exception),
                                                delegate
                                                {
                                                    _orderingAppCtrl.MakeOrder(1, "1", new List<OrderItem>() { item });
                                                });

            Assert.AreEqual(expectedException.Message, actualException.Message);
        }

        [Ignore("obsolete inteface")]
        [Test]
        public void MakeOrder_OrderDateEarlierThanToday_ThrowsOrderDateCanNotBeEarlierThanTodayException()
        {
            var invalidDate = _mockDateTimeSvc.Now.AddDays(-1);

            var expectedException = new Exception(string.Format("{0}", Messages.ErrorMessage.EarlierThanToday));

            var actualException = Assert.Throws(typeof(Exception),
                                                delegate
                                                {
                                                    _orderingAppCtrl.MakeOrder(1, "1", new List<OrderItem>() { _items.First() });
                                                });

            Assert.AreEqual(expectedException.Message, actualException.Message);
        }

    }
}
