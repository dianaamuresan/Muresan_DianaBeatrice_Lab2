using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Muresan_DianaBeatrice_Lab2.Data;
using Muresan_DianaBeatrice_Lab2.Models;

namespace Muresan_DianaBeatrice_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Muresan_DianaBeatrice_Lab2.Data.Muresan_DianaBeatrice_Lab2Context _context;

        public CreateModel(Muresan_DianaBeatrice_Lab2.Data.Muresan_DianaBeatrice_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
 "PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "FullName");
            return Page();

        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
