using Core.DataAccess.EntityFramework.Bases;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Repositories
{
    public abstract class CityRepositoryBase : RepositoryBase<City>
    {
        protected CityRepositoryBase(DbContext db) : base(db)
        {

        }
    }

    public class CityRepository : CityRepositoryBase
    {
        public CityRepository(DbContext db) : base(db)
        {

        }
    }
}
