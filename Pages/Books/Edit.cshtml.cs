﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Muresan_DianaBeatrice_Lab2.Data;
using Muresan_DianaBeatrice_Lab2.Models;

namespace Muresan_DianaBeatrice_Lab2.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly Muresan_DianaBeatrice_Lab2.Data.Muresan_DianaBeatrice_Lab2Context _context;

        public EditModel(Muresan_DianaBeatrice_Lab2.Data.Muresan_DianaBeatrice_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
           "PublisherName");
     
            return Page();
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FindAsync(id);

            if (Book == null)
            {
                return NotFound();
            }

            // Populate the dropdown list with authors for editing
            ViewData["AuthorID"] = new SelectList(_context.Set<Authors>(), "ID", "LastName");
            return Page();
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.ID == id);
        }
    }
}
