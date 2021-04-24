using Business.Models;
using Business.Services.Bases;
using Core.Business.Models.Results;
using DataAccess.EntityFramework.Repositories.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Entities;
using System.Globalization;
using System.Text;

namespace Business.Services
{
    public class BookService : IBookService
    {
        private readonly BookRepositoryBase _bookRepository;
        public BookService(BookRepositoryBase bookRepository)
        {
            _bookRepository = bookRepository;
        }
           
        public Result Add(BookModel model)
        {
            try
            {
                if (_bookRepository.GetEntityQuery().Any(p => p.Name.ToUpper() == model.Name.ToUpper().Trim()))
                    return new ErrorResult("Product with the same name exists!");

                double unitPrice;
                if (!double.TryParse(model.UnitPriceText.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out unitPrice))
                    return new ErrorResult("Unit price must be a decimal number!");

                model.UnitPrice = unitPrice;
                var entity = new Book()
                {
                    CategoryId = model.CategoryId,
                    Description = model.Description?.Trim(),
                    Name = model.Name.Trim(),
                    StockAmount = model.StockAmount,
                    UnitPrice = model.UnitPrice
                };
                _bookRepository.Add(entity);
                return new SuccessResult();
            }
            catch (Exception exc)
            {
                return new ExceptionResult(exc);
            }
        }

        public Result Delete(int id)
        {
            try
            {
                _bookRepository.Delete(id);
                return new SuccessResult();
            }
            catch (Exception exc)
            {
                return new ExceptionResult(exc);
            }
        }

        public void Dispose()
        {
            _bookRepository.Dispose();
        }

        public IQueryable<BookModel> GetQuery()
        {
           
                var query = _bookRepository.GetEntityQuery("Category").OrderBy(p => p.Name).Select(p => new BookModel()
                {
                    Id = p.Id,
                    Guid = p.Guid,
                    Name =p.Name,
                    Description =p.Description,
                    UnitPrice = p.UnitPrice,
                    UnitPriceText = p.UnitPrice.ToString(new CultureInfo("en")),
                    StockAmount = p.StockAmount,
                    CategoryId =p.CategoryId,
                    Category = new CategoryModel()
                    {
                        Id = p.Id,
                        Guid =p.Guid,
                        Name = p.Name,
                        Description =p.Category.Description
                    }
                });
                return query;
           
        }

        public Result Update(BookModel model)
        {

            try
            {
                if (_bookRepository.GetEntityQuery().Any(p => p.Name.ToUpper() == model.Name.ToUpper().Trim() && p.Id != model.Id))
                    return new ErrorResult("Product with the same name exists!");

                double unitPrice;
                if (!double.TryParse(model.UnitPriceText.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out unitPrice))
                    return new ErrorResult("Unit price must be a decimal number!");

                model.UnitPrice = unitPrice;
                var entity = _bookRepository.GetEntityQuery(p => p.Id == model.Id).SingleOrDefault();
                entity.CategoryId = model.CategoryId;
                entity.Description = model.Description?.Trim();
                entity.Name = model.Name.Trim();
                entity.StockAmount = model.StockAmount;
                entity.UnitPrice = model.UnitPrice;
                _bookRepository.Update(entity);
                return new SuccessResult();
            }
            catch (Exception exc)
            {
                return new ExceptionResult(exc);
            }
        }
    }
}
