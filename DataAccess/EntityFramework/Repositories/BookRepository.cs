using DataAccess.EntityFramework.Repositories.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Repositories
{
    public class BookRepository : BookRepositoryBase
    {
        public  BookRepository(DbContext db) : base(db)
        {

        }
    }
}
