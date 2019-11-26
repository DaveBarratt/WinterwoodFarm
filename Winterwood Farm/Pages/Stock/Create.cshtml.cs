using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Winterwood_Farm.Data;
using Winterwood_Farm.Models;

namespace Winterwood_Farm.Pages.Stock
{
    public class CreateModel : PageModel
    {
        private readonly Winterwood_Farm.Data.ApplicationDbContext _context;

        public CreateModel(Winterwood_Farm.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StockModel StockModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StockModel.Add(StockModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}