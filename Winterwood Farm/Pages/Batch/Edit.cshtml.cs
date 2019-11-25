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

namespace Winterwood_Farm.Pages.Batch
{
    public class EditModel : PageModel
    {
        private readonly Winterwood_Farm.Data.ApplicationDbContext _context;

        public EditModel(Winterwood_Farm.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BatchModel BatchModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BatchModel = await _context.BatchModel.FirstOrDefaultAsync(m => m.Id == id);

            if (BatchModel == null)
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

            _context.Attach(BatchModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchModelExists(BatchModel.Id))
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

        private bool BatchModelExists(int id)
        {
            return _context.BatchModel.Any(e => e.Id == id);
        }
    }
}
