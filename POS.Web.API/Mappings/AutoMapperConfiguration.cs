using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.API.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                // ViewModels
                x.AddProfile<DomainToDtoMappingProfile>();
                x.AddProfile<DtoToDomainMappingProfile>();

            });
        }
    }
}