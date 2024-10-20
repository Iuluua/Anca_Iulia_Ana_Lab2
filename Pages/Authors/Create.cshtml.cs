using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Anca_Iulia_Ana_Lab2.Data;
using Anca_Iulia_Ana_Lab2.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Anca_Iulia_Ana_Lab2.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly Anca_Iulia_Ana_Lab2.Data.Anca_Iulia_Ana_Lab2Context _context;

        public CreateModel(Anca_Iulia_Ana_Lab2.Data.Anca_Iulia_Ana_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!IsFormValid())
            {
                return Page();
            }
            this.Author.FullName = this.Author.FirstName + " " + this.Author.LastName;

            _context.Author.Add(Author);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool IsFormValid()
        {
            return ModelState["Author.LastName"].ValidationState == ModelValidationState.Valid &&
                ModelState["Author.FirstName"].ValidationState == ModelValidationState.Valid &&
                ModelState["Author.FullName"].ValidationState == ModelValidationState.Invalid;
        }
    }
}
