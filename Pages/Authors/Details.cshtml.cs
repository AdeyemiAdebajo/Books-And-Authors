using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBooks.Data;
using MyBooks.Models;

namespace MyBooks.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly MyBooks.Data.MyBooksDbContext _context;

        public DetailsModel(MyBooks.Data.MyBooksDbContext context)
        {
            _context = context;
        }

        public Author? Author{ get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if(_context.Authors is not null)

                // There isn't much different here than what you have in your Details ViewModel
                // By default your course won't load any assignments. By adding the Include() we can specify we want
                //  the course assignments.
                Author = await _context.Authors.Include(c => c.Books).FirstOrDefaultAsync(m => m.AuthorId == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
