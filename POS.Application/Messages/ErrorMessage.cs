using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Messages
{
    public class ErrorMessage
    {
        public const string InvalidCustomerId = "Invalid Customer, Id = ";
        public const string InvalidEmployeeId = "Invalid Empoloyee, Id = ";
        public const string InvalidProductId = "Invalid Product, Id = ";
        public const string InvalidOrderId = "Invalid Order, Id = ";

        public const string NullOrderItems = "Order items can not be null !";
        public const string EmptyOrderItems = "Order items can not be empty !";

        public const string EarlierThanToday = "Date can not be earlier than today !"; 
    }
}
