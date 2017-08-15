using AutoMapper;
using POS.Domain.Model.Models;
using POS.Web.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.UI.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ProductViewModel, Product>();
            Mapper.CreateMap<CustomerViewModel, Customer>();
            Mapper.CreateMap<EmployeeViewModel, ApplicationUser>();
            Mapper.CreateMap<OrderViewModel, Order>();
            Mapper.CreateMap<OrderItemViewModel, OrderItem>();
        }
    }
}