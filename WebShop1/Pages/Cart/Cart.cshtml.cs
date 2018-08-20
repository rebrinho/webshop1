
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebShop1.Data;
using WebShop1.Models;


namespace WebShop1.Pages.Cart
{
    public class CartModel : PageModel
    {
        
        private readonly WebShop1.Data.ApplicationDbContext _context;

        public CartModel(WebShop1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

          //  foreach( var item in IndexModel.id) // iščem vse, ki so bili dodani v košarico 
          //  {
                Product = await _context.Product.SingleOrDefaultAsync(m => m.Id == id);
          //  }


            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
