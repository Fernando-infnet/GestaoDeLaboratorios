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
    public class DeleteModel : PageModel
    {
        private readonly GestaoDeLaboratorios.Data.ApplicationDbContext _context;

        public DeleteModel(GestaoDeLaboratorios.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Computador Computador { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = await _context.Computadores.FirstOrDefaultAsync(m => m.Id == id);

            if (computador == null)
            {
                return NotFound();
            }
            else
            {
                Computador = computador;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = await _context.Computadores.FindAsync(id);
            if (computador != null)
            {
                Computador = computador;
                _context.Computadores.Remove(Computador);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
