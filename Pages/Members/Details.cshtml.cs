using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anca_Iulia_Ana_Lab2.Data;
using Anca_Iulia_Ana_Lab2.Models;

namespace Anca_Iulia_Ana_Lab2.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly Anca_Iulia_Ana_Lab2.Data.Anca_Iulia_Ana_Lab2Context _context;

        public DetailsModel(Anca_Iulia_Ana_Lab2.Data.Anca_Iulia_Ana_Lab2Context context)
        {
            _context = context;
        }

        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }
            else
            {
                Member = member;
            }
            return Page();
        }
    }
}
