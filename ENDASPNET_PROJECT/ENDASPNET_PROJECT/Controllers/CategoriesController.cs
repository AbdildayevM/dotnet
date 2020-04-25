using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ENDASPNET_PROJECT.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoriesContext _dbContext;

        public CategoriesContext(CategoriesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Categories categories)
        {


            _dbContext.Categories.Add(categories);
            await _dbContext.SaveChangesAsync();

            var categories = await _dbContext.Categories.ToListAsync();

            return View("Index", categories);
        }

        public async Task<IActionResult> Search(string text)
        {
            text = text.ToLower();
            var searchedCategories = await _dbContext.Categories.Where(categories => categories.Name.ToLower().Contains(text)


                                             categories.Genre.ToLower().Contains(text)


                                             categories.Author.ToLower().Contains(text))
                                        .ToListAsync();
            return View("Index", searchedCategories);
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoriesToUpdate = await _context.Category.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Post>(
                categoriesToUpdate,
                "",
                s => s.id, s => s.name))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(categoriesToUpdate);
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(category);
        }

    }
}