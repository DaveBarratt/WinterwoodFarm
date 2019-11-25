﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Winterwood_Farm.Data.ApplicationDbContext _context;

        public IndexModel(Winterwood_Farm.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<StockModel> StockModel { get;set; }

        public async Task OnGetAsync()
        {
            StockModel = await _context.StockModel.ToListAsync();
        }
    }
}
