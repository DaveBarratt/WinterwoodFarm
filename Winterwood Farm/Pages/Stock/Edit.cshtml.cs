using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Winterwood_Farm.Data;
using Winterwood_Farm.Models;

namespace Winterwood_Farm.Pages.Stock
{
    public class EditModel : PageModel
    {
        private readonly Winterwood_Farm.Data.ApplicationDbContext _context;

        public EditModel(Winterwood_Farm.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StockModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockModelExists(StockModel.StockModelId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StockModelExists(int id)
        {
            return _context.StockModel.Any(e => e.StockModelId == id);
        }
    }
}
