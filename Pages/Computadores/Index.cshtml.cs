using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestaoDeLaboratorios.Data;
using GestaoDeLaboratorios.Models;

namespace GestaoDeLaboratorios.Pages.Computadores
{
    public class IndexModel : PageModel
    {
        private readonly GestaoDeLaboratorios.Data.ApplicationDbContext _context;

        public IndexModel(GestaoDeLaboratorios.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Computador> Computador { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Computador = await _context.Computadores.ToListAsync();
        }
    }
}
