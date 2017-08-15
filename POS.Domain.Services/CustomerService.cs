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
    public interface ICustomerService : IService<Customer, int> 
    {
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _repo.GetAll();
        }

        public Customer GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Create(Customer entity)
        {
            _repo.Add(entity);
            Save();
        }

        public void Update(Customer entity)
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


        public IEnumerable<Customer> Where(System.Linq.Expressions.Expression<Func<Customer, bool>> where)
        {
            return _repo.GetMany(where);
        }

        public Customer Get(System.Linq.Expressions.Expression<Func<Customer, bool>> where)
        {
            return _repo.Get(where);
        }
    }
}
