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
    public class DetailsModel : PageModel
    {
        private readonly Winterwood_Farm.Data.ApplicationDbContext _context;

        public DetailsModel(Winterwood_Farm.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public BatchModel BatchModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BatchModel = await _context.BatchModel.FirstOrDefaultAsync(m => m.BatchModelId == id);

            if (BatchModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
