using Business.Models;
using Core.Business.Models.Results;
using Core.Business.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public interface IUserService : IService<UserModel>
    {

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

        public Result Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}

