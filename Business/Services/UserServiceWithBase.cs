using Business.Models;
using Core.Business.Models.Results;
using Core.Business.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Services
{
    public interface IUserService : IService<UserModel>
    {
        Result<List<UserModel>> GetUsers();
        Result<UserModel> GetUser(int id);
        Result<UserModel> GetUser(Expression<Func<UserModel, bool>> predicate);
    }
    public class UserService : IUserService
    {
        public Result Add(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserModel> GetQuery()
        {
            throw new NotImplementedException();
        }

        public Result<UserModel> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Result<UserModel> GetUser(Expression<Func<UserModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Result<List<UserModel>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserModel> Query()
        {
            throw new NotImplementedException();
        }

        public Result Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}

