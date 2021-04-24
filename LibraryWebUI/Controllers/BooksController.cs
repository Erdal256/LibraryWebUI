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

        //public BooksController(LibraryContext context)
        //{
        //    _context = context;
        //}
        public BooksController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }


        // GET: Books
        //public async Task<IActionResult> Index()
        //{
        //    var libraryContext = _context.Books.Include(b => b.Category);
        //    return View(await libraryContext.ToListAsync());
        //}
        public IActionResult Index()
        {
            //var result = _bookService.GetQuery();
            //if (result.Status == ResultStatus.Exception)
            //{
            //    //return RedirectToAction("Error", "Home");
            //    //return View("Error");
            //    throw new Exception(result.Message);
            //}
            //var model = result.Data.ToList();
            //return View(model);
            var query = _bookService.GetQuery();
            var model = query.ToList();
            return View(model);

        }

        // GET: Books/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = await _context.Books
        //        .Include(b => b.Category)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(book);
        //}
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return View("NotFound");
            }

            var query = _bookService.GetQuery();

            var model = query.SingleOrDefault(p => p.Id == id.Value);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        // GET: Books/Create
        //public IActionResult Create()
        //{
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        //    return View();
        //}
        public IActionResult Create()
        {
            var query = _categoryService.GetQuery();
            ViewBag.Categories = new SelectList(query.ToList(), "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,Description,UnitPrice,StockAmount,CategoryId,Id,Guid")] Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(book);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", book.CategoryId);
        //    return View(book);
        //}
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

                categoryQuery = _categoryService.GetQuery();
                ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", book.CategoryId);
                return View(book);
            }

            // validation error
            categoryQuery = _categoryService.GetQuery();
            ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var bookQuery = _bookService.GetQuery();
            var book = bookQuery.SingleOrDefault(p => p.Id == id.Value);
            if (book == null)
                return View("NotFound");

            var categoryQuery = _categoryService.GetQuery();
            ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", book.CategoryId);

            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Name,Description,UnitPrice,StockAmount,CategoryId,Id,Guid")] Book book)
        //{
        //    if (id != book.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(book);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BookExists(book.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", book.CategoryId);
        //    return View(book);
        //}
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

                categoryQuery = _categoryService.GetQuery();
                ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", book.CategoryId);
                return View(book);
            }
            categoryQuery = _categoryService.GetQuery();
            ViewBag.Categories = new SelectList(categoryQuery.ToList(), "Id", "Name", book.CategoryId);
            return View(book);

        }

        // GET: Books/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = await _context.Books
        //        .Include(b => b.Category)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(book);
        //}

        //// POST: Books/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var book = await _context.Books.FindAsync(id);
        //    _context.Books.Remove(book);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
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

        //private bool BookExists(int id)
        //{
        //    return _context.Books.Any(e => e.Id == id);
        //}
    }
}
