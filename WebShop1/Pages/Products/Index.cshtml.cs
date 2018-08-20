using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebShop1.Data;
using WebShop1.Models;

namespace WebShop1.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly WebShop1.Data.ApplicationDbContext _context;

        public IndexModel(WebShop1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
