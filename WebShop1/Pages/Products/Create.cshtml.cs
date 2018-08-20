
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop1.Data;
using WebShop1.Models;

namespace WebShop1.Pages.Products
{
    public class CreateModel : PageModel
    {
        private IHostingEnvironment env;
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context, IHostingEnvironment e)
        {
            env = e;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

       // public IFormFile Upload { get; set; }

        [HttpPost]
        public async Task UploadPhoto()
        {
            var uploadFromDirectoryPath = Path.Combine(env.ContentRootPath, "images", Product.Slika.FileName);

            using (var fileStream = new FileStream(uploadFromDirectoryPath, FileMode.Create))
            {
                
                await Product.Slika.CopyToAsync(fileStream);
                Product.PotDoSlika = Product.Slika.FileName;

            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            

            return RedirectToPage("./Index");
        }
    }
}