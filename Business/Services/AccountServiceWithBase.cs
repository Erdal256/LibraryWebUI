using Business.Models;
using Core.Business.Models.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public interface IAccountService
    {
        Result Register(UserRegisterModel model);
        Result<UserModel> Login(UserLoginModel model);
    }
    public class AccountService : IAccountService
    {
        public Result<UserModel> Login(UserLoginModel model)
        {
            throw new NotImplementedException();
        }

        public Result Register(UserRegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
