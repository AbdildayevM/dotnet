using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ENDASPNET_PROJECT.Controllers
{
    public class PostsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(
        [Bind("id,title,content,author,category")Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbcontext.Add(post);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(post);
        }
        public async Task<IActionResult> Search(string text)
        {
            text = text.ToLower();
            var searchedPosts = await _dbContext.Posts.Where(posts => posts.Name.ToLower().Contains(text)


                                             posts.id.ToLower().Contains(text)


                                             posts.Author.ToLower().Contains(text))
                                        .ToListAsync();
            return View("Index", searchedPosts);
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
            var postToUpdate = await _context.Post.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Post>(
                postToUpdate,
                "",
                s => s.id, s => s.Title, s => s.Content, s => s.Author, s => s.Category))
            {
                try
                {
                    await _dbcontext.SaveChangesAsync();
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
            return View(postToUpdate);
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

            var post = await _context.Post
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (post == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(post);
        }
    }
}