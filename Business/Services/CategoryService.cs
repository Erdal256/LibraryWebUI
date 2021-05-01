using Business.Models;
using Business.Services.Bases;
using Core.Business.Models.Results;
using DataAccess.EntityFramework.Repositories.Bases;
using Entities.Entities;
using System;
using System.Linq;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepositoryBase _categoryRepository;
        private readonly BookRepositoryBase _bookRepository;

        public CategoryService(CategoryRepositoryBase categoryRepository, BookRepositoryBase bookRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
        }
        public Result Add(CategoryModel model)
        {
            try
            {
                if (_categoryRepository.GetEntityQuery().Any(c => c.Name.ToUpper() == model.Name.ToUpper().Trim()))
                    return new ErrorResult("Category with the same name exists!");
                var entity = new Category()
                {
                    Description = model.Description?.Trim(),
                    Name = model.Name.Trim()
                };
                _categoryRepository.Add(entity);
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
                var category = _categoryRepository.GetEntityQuery(c => c.Id == id, "Books").SingleOrDefault();

                if (category.Books != null && category.Books.Count > 0)
                {
                    return new ErrorResult("Category has books so it can't be deleted!");
                }

                _categoryRepository.Delete(category);
                return new SuccessResult();
            }
            catch (Exception exc)
            {

                return new ExceptionResult(exc);
            }
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }

        public IQueryable<CategoryModel> GetQuery()
        {
            
                var query = _categoryRepository.GetEntityQuery("Books").OrderBy(c => c.Name).Select(c => new CategoryModel()
                {
                    Id = c.Id,
                    Guid = c.Guid,
                    Name = c.Name,
                    Description = c.Description,
                });
                return query;
            
        }

        public Result Update(CategoryModel model)
        {

            try
            {
                if (_categoryRepository.GetEntityQuery().Any(c => c.Name.ToUpper() == model.Name.ToUpper().Trim() && c.Id != model.Id))
                    return new ErrorResult("Category with the same name exists!");
                var entity = _categoryRepository.GetEntityQuery(c => c.Id == model.Id).SingleOrDefault();
                entity.Description = model.Description?.Trim();
                entity.Name = model.Name.Trim();
                _categoryRepository.Update(entity);
                return new SuccessResult();
            }
            catch (Exception exc)
            {
                return new ExceptionResult(exc);
            }
        }
    }
}
