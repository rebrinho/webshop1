using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop1.Data;
using WebShop1.Models;

namespace WebShop1.Pages.Products
{
    public class UploadFileModel : PageModel
    {
        private IHostingEnvironment _environment;
        public UploadFileModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task OnPostAsync()
        {

            var file = Path.Combine(_environment.WebRootPath, "images", Product.Slika.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Product.Slika.CopyToAsync(fileStream);
            }

        }
    }
}