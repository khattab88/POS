using POS.Data.Infrastructure;
using POS.Data.Repositories;
using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Services
{
    public interface IProductService : IService<Product, int> 
    {
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetAll()
        {
            return _repo.GetAll();
        }

        public Product GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Create(Product entity)
        {
            _repo.Add(entity);
            Save();
        }

        public void Update(Product entity)
        {
            _repo.Update(entity);
            Save();
        }

        public void Delete(int id)
        {
            var entity = _repo.GetById(id);
            _repo.Delete(entity);
            Save();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }


        public IEnumerable<Product> Where(Expression<Func<Product, bool>> where)
        {
            return _repo.GetMany(where);
        }

        public Product Get(Expression<Func<Product, bool>> where)
        {
            return _repo.Get(where);
        }
    }
}
