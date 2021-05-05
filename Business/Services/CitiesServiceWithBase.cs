using Business.Models;
using Core.Business.Models.Results;
using Core.Business.Services.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public interface ICityService : IService<CityModel>
    {
        Result<List<CityModel>> GetCities(int? countryId = null);
        Result<CityModel> GetCity(int id);
    }
    public class CitiesService : ICityService
    {
        public Result Add(CityModel model)
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

        public Result<List<CityModel>> GetCities(int? countryId = null)
        {
            throw new NotImplementedException();
        }

        public Result<CityModel> GetCity(int id)
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<CityModel> GetQuery()
        {
            throw new NotImplementedException();
        }

        public Result Update(CityModel model)
        {
            throw new NotImplementedException();
        }
    }
}
