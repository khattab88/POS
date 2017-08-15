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
    public interface IOrderService : IService<Order, int> 
    {
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Order> GetAll()
        {
            return _repo.GetAll();
        }

        public Order GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Create(Order entity)
        {
            _repo.Add(entity);
            Save();
        }

        public void Update(Order entity)
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


        public IEnumerable<Order> Where(Expression<Func<Order, bool>> where)
        {
            return _repo.GetMany(where);
        }

        public Order Get(Expression<Func<Order, bool>> where)
        {
            return _repo.Get(where);
        }
    }
}
