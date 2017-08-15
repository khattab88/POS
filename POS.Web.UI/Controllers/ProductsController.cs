    using AutoMapper;
using POS.Domain.Model.Models;
using POS.Domain.Services;
using POS.Web.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Web.UI.Controllers
{
    public class ProductsController : Controller
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

        public ActionResult Index()
        {
            var products = _productSvc.GetAll();
            var vm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
            return View(vm);
        }

        [Authorize]
        public ActionResult Create()
        {
            var categories = _categorySvc.GetAll();
            var vm = new ProductFormViewModel() 
            {
                Categories = categories
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ProductFormViewModel viewModel)
        {
            try
            {
                var newProduct = new Product()
                {
                    Name = viewModel.Product.Name,
                    Price = viewModel.Product.Price,
                    ReleaseDate = viewModel.Product.ReleaseDate,
                    Code = viewModel.Product.Code,
                    Description = viewModel.Product.Description,
                    ImageUrl = viewModel.Product.ImageUrl,
                    CategoryId = viewModel.Product.CategoryId
                };

                _productSvc.Create(newProduct);

                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                ViewBag.ErrorMsg = "Can't add new product !";
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var product = _productSvc.GetById(id);

            if (product == null)
                return HttpNotFound();

            var vm = Mapper.Map<Product, ProductViewModel>(product);

            return View(vm);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var product = _productSvc.GetById(id);
            if (product == null)
                return HttpNotFound();

            var categories = _categorySvc.GetAll();

            var vm = new ProductFormViewModel() 
            {
                Product = Mapper.Map<Product,ProductViewModel>(product),
                Categories = categories
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(ProductViewModel product)
        {
            var vm = new ProductFormViewModel() 
            {
                Product = product,
                Categories = _categorySvc.GetAll().ToList()
            };

            if (!ModelState.IsValid) 
            {
                return View(vm);
            }

            try 
            {
                var exsistingProduct = _productSvc.GetById(product.Id);

                exsistingProduct.Name = product.Name;
                exsistingProduct.Code = product.Code;
                exsistingProduct.Price = product.Price;
                DateTime dummyDate = new DateTime();
                exsistingProduct.ReleaseDate = DateTime.TryParse(product.ReleaseDate.ToString(), out dummyDate) ? product.ReleaseDate : exsistingProduct.ReleaseDate;
                exsistingProduct.ImageUrl = product.ImageUrl;
                exsistingProduct.Description = product.Description;
                exsistingProduct.CategoryId = product.CategoryId;

                _productSvc.Update(exsistingProduct);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(vm);
            }
        }

        [Route("Products/Released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult GetByReleaseDate(int year, int month) 
        {
            return Content(year + "/" + month);
        }

	}
}