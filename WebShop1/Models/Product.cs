using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Vrsta { get; set; }
        public string Znamka { get; set; }
        public string Model { get; set; }
        [Range(1900, 2018, ErrorMessage ="Preverite letnico izdelave vozila")]
        public short Leto { get; set; }
        [Range(900, 10000, ErrorMessage = "Preverite prostornino motorja vozila")]
        public short Motor { get; set; }
        public string Barva { get; set; }
        [Range(0, 10000000, ErrorMessage = "Negativna cena ni dovoljena, največja dovoljena pa je 10 milijonov evrov")]
        public decimal Cena { get; set; }
        public string PotDoSlika { get; set; }

        [Required]
        [NotMapped]
        public IFormFile Slika { get; set; }

    }
}
