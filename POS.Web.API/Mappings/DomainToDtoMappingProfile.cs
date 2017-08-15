using AutoMapper;
using POS.Domain.Model.Models;
using POS.Web.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.API.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToDtoMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.ProductId, map => map.MapFrom(product => product.Id))
                .ForMember(dto => dto.ProductName, map => map.MapFrom(product => product.Name))
                .ForMember(dto => dto.ProductCode, map => map.MapFrom(product => product.Code))
                .ForMember(dto => dto.StarRating, map => map.MapFrom(product => product.Rating));
                //.ForMember(dto => dto.ReleaseDate, map => map.MapFrom(product => product.ReleaseDate.ToString("MMM yyy")));
                //.ForMember(dto => dto.ReleaseDate, map => map.MapFrom(product => product.ReleaseDate));

            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Order, OrderDto>();
            Mapper.CreateMap<OrderItem, OrderItemDto>();
            Mapper.CreateMap<Customer, CustomerDto>();
        }
    }
}