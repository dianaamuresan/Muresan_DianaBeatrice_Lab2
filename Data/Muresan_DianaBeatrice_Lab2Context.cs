using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Muresan_DianaBeatrice_Lab2.Models;

namespace Muresan_DianaBeatrice_Lab2.Data
{
    public class Muresan_DianaBeatrice_Lab2Context : DbContext
    {
        public Muresan_DianaBeatrice_Lab2Context (DbContextOptions<Muresan_DianaBeatrice_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Muresan_DianaBeatrice_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Muresan_DianaBeatrice_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Muresan_DianaBeatrice_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
