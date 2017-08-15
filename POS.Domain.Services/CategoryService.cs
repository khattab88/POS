using POS.Data.Infrastructure;
using POS.Data.Repositories;
using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Services
{
    public interface ICategoryService : IService<Category, int> 
    {
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<Category> GetAll()
        {
            return _repo.GetAll();
        }

        public Category GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Category> Where(System.Linq.Expressions.Expression<Func<Category, bool>> where)
        {
            return _repo.GetMany(where);
        }

        public Category Get(System.Linq.Expressions.Expression<Func<Category, bool>> where)
        {
            return _repo.Get(where);
        }
    }
}
