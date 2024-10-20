using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Muresan_DianaBeatrice_Lab2.Data;
using Muresan_DianaBeatrice_Lab2.Models;

namespace Muresan_DianaBeatrice_Lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Muresan_DianaBeatrice_Lab2.Data.Muresan_DianaBeatrice_Lab2Context _context;

        public IndexModel(Muresan_DianaBeatrice_Lab2.Data.Muresan_DianaBeatrice_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}
