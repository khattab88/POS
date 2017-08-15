using AutoMapper;
using POS.Domain.Model.Models;
using POS.Web.API.Dtos;
using POS.Web.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.API.Mappings
{
    public class DtoToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DtoToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ProductDto, Product>()
                .ForMember(model => model.Id, map => map.MapFrom(dto => dto.ProductId))
                .ForMember(model => model.Name, map => map.MapFrom(dto => dto.ProductName))
                .ForMember(model => model.Code, map => map.MapFrom(dto => dto.ProductCode))
                .ForMember(model => model.Rating, map => map.MapFrom(dto => dto.StarRating));

            Mapper.CreateMap<CategoryDto, Category>();
            Mapper.CreateMap<OrderDto, Order>();
            Mapper.CreateMap<OrderItemDto, OrderItem>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}