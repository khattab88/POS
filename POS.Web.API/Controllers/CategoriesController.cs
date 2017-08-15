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

namespace POS.Web.API.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categorySvc;

        public CategoriesController()
        {
        }

        public CategoriesController(ICategoryService categorySvc)
        {
            _categorySvc = categorySvc;
        }

        // GET  api/categories
        public IHttpActionResult Get() 
        {
            try
            {
                var categories = _categorySvc.GetAll();
                var dto = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET  api/categories/1
        public IHttpActionResult Get(int id)
        {
            try
            {
                var category = _categorySvc.GetById(id);

                if (category == null)
                    return NotFound();

                var dto = Mapper.Map<Category, CategoryDto>(category);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
