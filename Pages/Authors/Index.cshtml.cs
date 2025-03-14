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
    public class IndexModel : PageModel
    {
        private readonly MyBooks.Data.MyBooksDbContext _context;

        public IndexModel(MyBooks.Data.MyBooksDbContext context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Authors.ToListAsync();
        }
    }
}
