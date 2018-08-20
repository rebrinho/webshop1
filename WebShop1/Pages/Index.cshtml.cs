using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebShop1.Data;
using WebShop1.Models;

namespace WebShop1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }                //sortiranje.... naredi, da bo sortiralo po vrsti vozila...
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        
        public Product Product { get; set; }

        public async Task OnGetAsync(string sortiranje)
        {

            IQueryable<Product> sortiran = from s in _context.Product
                                           select s;
            

            
         
        }
        
    }
}
