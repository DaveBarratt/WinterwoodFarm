using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Winterwood_Farm.Data;
using Winterwood_Farm.Models;

namespace Winterwood_Farm.Pages.Batch
{
    public class DeleteModel : PageModel
    {
        private readonly Winterwood_Farm.Data.ApplicationDbContext _context;

        public DeleteModel(Winterwood_Farm.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BatchModel = await _context.BatchModel.FindAsync(id);

            if (BatchModel != null)
            {
                _context.BatchModel.Remove(BatchModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
