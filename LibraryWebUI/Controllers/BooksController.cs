using Business.Models;
using Business.Services.Bases;
using Core.Business.Models.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace LibraryWebUI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        public BooksController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var query = _bookService.Query();
            var model = query.ToList();
            return View(model);

        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return View("NotFound");
            }

            var query = _bookService.Query();

            var model = query.SingleOrDefault(p => p.Id == id.Value);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        public IActionResult Create()
        {
            var query = _categoryService.Query();
            ViewBag.Categories = new SelectList(query.ToList(), "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookModel book)
        {
            Result bookResult;
            IQueryable<CategoryModel> categoryQuery;
            if (ModelState.IsValid)
            {
                bookResult = _bookService.Add(book);
                if (bookResult.Status == ResultStatus.Exception) // exception
                {
                    throw new Exception(bookResult.Message);
                }
                if (bookResult.Status == ResultStatus.Success) // success
                {
                    //return RedirectToAction("Index");
                    return RedirectToAction(nameof(Index)); // nameof(Index) = "Index"
                }

                // error
                //ViewBag.Message = productResult.Message;
                ModelState.AddModelError("", bookResult.Message);

                categoryQuery = _categoryService.Query();
                ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", book.CategoryId);
                return View(book);
            }

            // validation error
            categoryQuery = _categoryService.Query();
            ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", book.CategoryId);
            return View(book);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var bookQuery = _bookService.Query();
            var book = bookQuery.SingleOrDefault(p => p.Id == id.Value);
            if (book == null)
                return View("NotFound");

            var categoryQuery = _categoryService.Query();
            ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", book.CategoryId);

            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (BookModel book)
        {
            Result bookResult;
            IQueryable<CategoryModel> categoryQuery;
            if (ModelState.IsValid)
            {
                bookResult = _bookService.Update(book);
                if (bookResult.Status == ResultStatus.Exception)
                {
                    throw new Exception(bookResult.Message);
                }
                if (bookResult.Status == ResultStatus.Success)
                {
                    return RedirectToAction(nameof(Index)); 
                }
                ModelState.AddModelError("", bookResult.Message);

                categoryQuery = _categoryService.Query();
                ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", book.CategoryId);
                return View(book);
            }
            categoryQuery = _categoryService.Query();
            ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", book.CategoryId);
            return View(book);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return View("NotFound");
            var result = _bookService.Delete(id.Value);
            if (result.Status == ResultStatus.Success)
                return RedirectToAction(nameof(Index));
            throw new Exception(result.Message);
        }
    }
}
