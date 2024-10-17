using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anca_Iulia_Ana_Lab2.Models;

namespace Anca_Iulia_Ana_Lab2.Data
{
    public class Anca_Iulia_Ana_Lab2Context : DbContext
    {
        public Anca_Iulia_Ana_Lab2Context (DbContextOptions<Anca_Iulia_Ana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Anca_Iulia_Ana_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Anca_Iulia_Ana_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
