using Business.Models;
using Core.Business.Models.Results;
using Core.Business.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public interface ICountryService : IService<CountryModel>
    {
        Result<List<CountryModel>> GetCountries();
        Result<CountryModel> GetCountry(int id);
    }
    public class CountryService : ICountryService
    {
        public Result Add(CountryModel model)
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

        public Result<List<CountryModel>> GetCountries()
        {
            throw new NotImplementedException();
        }

        public Result<CountryModel> GetCountry(int id)
        {
            throw new NotImplementedException();
        }
        public IQueryable<CountryModel> Query()
        {
            throw new NotImplementedException();
        }

        public Result Update(CountryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
