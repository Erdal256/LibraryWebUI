using Business.Models;
using Core.Business.Models.Results;
using Core.Business.Services.Bases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Bases
{
    public interface ICategoryService : IService<CategoryModel>
    {
        Task<Result<List<CategoryModel>>> GetCategoriesAsync();
    }
}
