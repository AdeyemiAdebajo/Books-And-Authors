using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBooks.Data;
using MyBooks.Models;

namespace MyBooks.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly MyBooksDbContext _context;

        public CreateModel(MyBooksDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Build the server side code required to create a HTML <select> tag for the dropdown for courses.
            /*
            <select name="Courses" id="Courses">
                <option value="cis325">Programming in C#</option>
                <option value="cst230">Tech Support</option>
            </select>
            */
            // A SelectListItem represents an <option> element in html. It has Text and Value properties.
            // Therefore, a List<SelectListItem> will hold the entire set of <option> elements for the <select> element.
            List<SelectListItem> AuthorSelectOptions = new List<SelectListItem>();
            // For each course in the database, create a SelectListItem with values from the course and add it to our list.
            foreach (Author author in _context.Authors)
            {
                string optionText = $"{author.FirstName} ({author.LastName})";
                string optionValueAttribute = author.AuthorId.ToString();

                // note the order in which the constructor takes the text/value data since it's flipped for the SelectList
                //                1⬇️ Value   >2⬇️ element text </
                // <option value="CourseCode">Course Description</option>
                //                                            2⬇️               1⬇️
                SelectListItem option = new SelectListItem(optionText, optionValueAttribute);

                // add the option element to our SelectListItem List
                AuthorSelectOptions.Add(option);
            }

            // Construct a new SelectList using our List<SelectListItem> from above
            // as noted, we present the Value property of the SelectListItem first here, and Text Property second (in relation to each other)
            CoursesSelect = new SelectList(AuthorSelectOptions, "Value", "Text");

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Book is not null)
            {
                _context.Books.Add(Book);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        [BindProperty]
        public Book Book { get; set; }

        // I renamed the property, you'll have to update it in the view unless you copy my view for Create.
        public SelectList CoursesSelect { get; set; }
    }
}
