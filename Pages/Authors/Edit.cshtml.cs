using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anca_Iulia_Ana_Lab2.Data;
using Anca_Iulia_Ana_Lab2.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Anca_Iulia_Ana_Lab2.Pages.Authors
{
    public class EditModel : PageModel
    {
        private readonly Anca_Iulia_Ana_Lab2.Data.Anca_Iulia_Ana_Lab2Context _context;

        public EditModel(Anca_Iulia_Ana_Lab2.Data.Anca_Iulia_Ana_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author =  await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }
            Author = author;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!IsFormValid())
            {
                return Page();
            }
            this.Author.FullName = this.Author.FirstName + " " + this.Author.LastName;

            _context.Attach(Author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(Author.ID))
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

        private bool AuthorExists(int id)
        {
            return _context.Author.Any(e => e.ID == id);
        }
        private bool IsFormValid()
        {
            return ModelState["Author.LastName"].ValidationState == ModelValidationState.Valid &&
                ModelState["Author.FirstName"].ValidationState == ModelValidationState.Valid &&
                ModelState["Author.FullName"].ValidationState == ModelValidationState.Invalid;
        }
    }
}
