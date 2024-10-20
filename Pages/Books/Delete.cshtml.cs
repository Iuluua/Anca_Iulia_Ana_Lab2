﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anca_Iulia_Ana_Lab2.Data;
using Anca_Iulia_Ana_Lab2.Models;

namespace Anca_Iulia_Ana_Lab2.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly Anca_Iulia_Ana_Lab2.Data.Anca_Iulia_Ana_Lab2Context _context;

        public DeleteModel(Anca_Iulia_Ana_Lab2.Data.Anca_Iulia_Ana_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            var author = await _context.Author.FirstOrDefaultAsync(a => a.ID == book.AuthorID);
            var publisher = await _context.Publisher.FirstOrDefaultAsync(a => a.ID == book.PublisherID);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
                Book.Author = author;
                Book.Publisher = publisher;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                Book = book;
                _context.Book.Remove(Book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
