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
    public interface IEmployeeService : IService<ApplicationUser,string>
    {
        ApplicationUser GetByUserName(string userName);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        #region IEmployeeService

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _repo.GetAll();
        }

        public ApplicationUser GetById(string id)
        {
            return _repo.GetById(id);
        }

        public void Create(ApplicationUser entity)
        {
            _repo.Add(entity);
            Save();
        }

        public void Update(ApplicationUser entity)
        {
            _repo.Update(entity);
            Save();
        }

        public void Delete(string id)
        {
            var entity = _repo.GetById(id);
            _repo.Delete(entity);
            Save();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<ApplicationUser> Where(System.Linq.Expressions.Expression<Func<ApplicationUser, bool>> where)
        {
            return _repo.GetMany(where);
        }

        public ApplicationUser Get(System.Linq.Expressions.Expression<Func<ApplicationUser, bool>> where)
        {
            return _repo.Get(where);
        }

        #endregion

        #region Custom Methos

        public ApplicationUser GetByUserName(string userName)
        {
            return _repo.Get(s => s.UserName == userName);
        }

        #endregion



        
    }
}
