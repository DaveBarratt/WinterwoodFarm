using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Winterwood_Farm.Data;
using Winterwood_Farm.Models;

namespace Winterwood_Farm.Pages.Stock
{
    public class DetailsModel : PageModel
    {
        private readonly Winterwood_Farm.Data.ApplicationDbContext _context;

        public DetailsModel(Winterwood_Farm.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public StockModel StockModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StockModel = await _context.StockModel.FirstOrDefaultAsync(m => m.StockModelId == id);

            if (StockModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
