#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Context;
using DataLayer.Models;

namespace noelwiz.gay.Pages
{
    public class ViewPostModel : PageModel
    {
        private readonly DataLayer.Context.postgresContext _context;

        public ViewPostModel(postgresContext context)
        {
            _context = context;
        }

        public Blogpost Blogpost { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blogpost = await _context.Blogposts.FirstOrDefaultAsync(m => m.Id == id);

            if (Blogpost == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
