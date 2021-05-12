using Business.Models;
using Business.Models.Report;
using Core.Business.Models.Results;
using Core.Business.Services.Bases;
using System.Collections.Generic;

namespace Business.Services.Bases
{
    public interface IBookService : IService<BookModel>
    {
        //Result<List<BooksReportModel>> GetBooksReport(BooksReportFilterModel filter, PageModel page = null);
    }
}
