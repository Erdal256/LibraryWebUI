﻿//using Business.Models;
//using Business.Services.Bases;
//using Core.Business.Models.Results;
//using Microsoft.AspNetCore.Mvc.ViewComponents;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace LibraryWebUI.ViewComponent
//{
//    public class CategoriesViewComponent : ViewComponent
//    {
//        private readonly ICategoryService _categoryService;

//        public CategoriesViewComponent(ICategoryService categoryService)
//        {
//            _categoryService = categoryService;
//        }

//        //public ViewViewComponentResult Invoke()
//        public ViewViewComponentResult Invoke(int? categoryId)
//        {
//            List<CategoryModel> categories;

//            // Async Methodlar
//            //categories = _categoryService.Query().ToList(); // *1

//            //Task<List<CategoryModel>> task = _categoryService.Query().ToListAsync(); // *2
//            //categories = task.Result; //

//            Task<Result<List<CategoryModel>>> task = _categoryService.GetCategoriesAsync(); // *3
//            Result<List<CategoryModel>> result = task.Result;
//            if (result.Status == ResultStatus.Exception)
//                throw new Exception(result.Message);
//            categories = result.Data;

//            ViewBag.CategoryId = categoryId;
//            return View(categories);
//        }
//    }
//}
