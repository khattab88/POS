using AutoMapper;
using POS.Domain.Model.Models;
using POS.Web.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.UI.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Customer, CustomerViewModel>();
            Mapper.CreateMap<ApplicationUser, EmployeeViewModel>();
            Mapper.CreateMap<Order, OrderViewModel>();
            Mapper.CreateMap<OrderItem, OrderItemViewModel>();
        }
    }
}