using Business.Models;
using Core.Business.Models.Results;
using Core.Business.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public interface IRoleService : IService<RoleModel>
    {

    }
    public class RoleService : IRoleService
    {
        public Result Add(RoleModel model)
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

        public IQueryable<RoleModel> Query()
        {
            throw new NotImplementedException();
        }

        public Result Update(RoleModel model)
        {
            throw new NotImplementedException();
        }
    }
}
