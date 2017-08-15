using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Web.UI.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                // ViewModels
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();

            });
        }
    }
}