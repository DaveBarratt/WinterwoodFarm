using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Winterwood_Farm.Data;
using Winterwood_Farm.Models;

namespace Winterwood_Farm.Pages.Batch
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
            int i = 0;
            return Page();
        }

        [BindProperty]
        public BatchModel BatchModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BatchModel.Add(BatchModel);

            StockModel stock = _context.StockModel.FirstOrDefault(s =>
                                s.Fruit == BatchModel.Fruit && s.Variety == BatchModel.Variety);
            if (stock != null)
            {
                stock.Quantity += BatchModel.Quantity;
            }
            else
            {
                StockModel newStock = new StockModel
                {
                    Fruit = BatchModel.Fruit,
                    Variety = BatchModel.Variety,
                    Quantity = BatchModel.Quantity
                };
                _context.StockModel.Add(newStock);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}