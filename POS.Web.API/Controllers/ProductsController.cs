using AutoMapper;
using Marvin.JsonPatch;
using POS.Domain.Model.Models;
using POS.Domain.Services;
using POS.Web.API.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace POS.Web.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _productSvc;
        private readonly ICategoryService _categorySvc;

        public ProductsController()
        {
        }

        public ProductsController(IProductService productSvc,
                                  ICategoryService categorySvc)
        {
            _productSvc = productSvc;
            _categorySvc = categorySvc;
        }

        // GET  /api/products
        [ResponseType(typeof(IEnumerable<ProductDto>))]
        public IHttpActionResult GetProducts() 
        {
            try
            {
                var products = _productSvc.GetAll();
                var dto = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
                return Ok(dto);
            }
            catch (Exception ex) 
            {
                return InternalServerError(ex);
            }
        }

        // GET  /api/products/1
        [ResponseType(typeof(ProductDto))]
        public IHttpActionResult GetProduct(int id) 
        {
            try
            {
                Product product = _productSvc.GetById(id);
                if (product == null)
                    return NotFound();

                var dto = Mapper.Map<Product, ProductDto>(product);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/categories/{categoryId}/products")]
        public IHttpActionResult GetCategoryProduct(int categoryId) 
        {
            try
            {
                var category = _categorySvc.GetById(categoryId);
                if (category == null)
                    return NotFound();

                var categoryProducts = _productSvc.Where(p => p.CategoryId == categoryId);
                var dto = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(categoryProducts);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //POST  /api/products
        [HttpPost]
        [ResponseType(typeof(ProductDto))]
        public IHttpActionResult CreateProduct(ProductDto dto)
        {
            try
            {
                if (dto == null || !ModelState.IsValid)
                    return BadRequest();

                Product product = Mapper.Map<ProductDto, Product>(dto);
                _productSvc.Create(product);

                return Created(string.Format("{0}/{1}", Request.RequestUri, product.Id), dto);
            }
            catch (DbEntityValidationException dbValEx)
            {
                return InternalServerError(dbValEx);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT  /api/products/1
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateProduct(int id, ProductDto dto) 
        {
            if (dto == null || !ModelState.IsValid || id != dto.ProductId)
                return BadRequest();

            if (_productSvc.GetById(id) == null)
                return NotFound();

            Product product = Mapper.Map<ProductDto, Product>(dto);
            _productSvc.Update(product);

            return Ok();
        }

        // PATCH /api/products/1
        [HttpPatch]
        [ResponseType(typeof(void))]
        public IHttpActionResult PartialUpdateProduct(int id, JsonPatchDocument<ProductDto> dtoPatchDocument) 
        {
            try
            {
                if (dtoPatchDocument == null)
                    return BadRequest();

                var product = _productSvc.GetById(id);
                if (product == null)
                    return NotFound();

                var dto = Mapper.Map<Product, ProductDto>(product);

                // apply changes to Dto
                dtoPatchDocument.ApplyTo(dto);

                var updatedProduct = Mapper.Map<ProductDto, Product>(dto);

                _productSvc.Update(product);
                return Ok();
            }
            catch (Exception ex) 
            {
                return InternalServerError(ex);
            }
        }

        //DELETE    /api/products/1
        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteProduct(int id) 
        {
            try
            {
                var product = _productSvc.GetById(id);
                if (product == null)
                    return NotFound();

                _productSvc.Delete(id);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex) 
            {
                return InternalServerError(ex);
            }
        }
    }
}
