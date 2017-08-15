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
    public interface IOrderItemService : IService<OrderItem, int> 
    {
    }

    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemService(IOrderItemRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _repo.GetAll();
        }

        public OrderItem GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Create(OrderItem entity)
        {
            _repo.Add(entity);
            Save();
        }

        public void Update(OrderItem entity)
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


        public IEnumerable<OrderItem> Where(System.Linq.Expressions.Expression<Func<OrderItem, bool>> where)
        {
            return _repo.GetMany(where);
        }

        public OrderItem Get(System.Linq.Expressions.Expression<Func<OrderItem, bool>> where)
        {
            return _repo.Get(where);
        }
    }
}
