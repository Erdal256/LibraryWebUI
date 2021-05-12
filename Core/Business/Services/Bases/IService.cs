using Core.Business.Models.Results;
using Core.Records.Bases;
using System;
using System.Linq;

namespace Core.Business.Services.Bases
{
    public interface IService<TModel> : IDisposable where TModel : RecordBase, new()
    {
        IQueryable<TModel> Query();
        Result Add(TModel model);
        Result Update(TModel model);
        Result Delete(int id);
    }
}
