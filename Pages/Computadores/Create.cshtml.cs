using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestaoDeLaboratorios.Data;
using GestaoDeLaboratorios.Models;

namespace GestaoDeLaboratorios.Pages.Computadores
{
    public class CreateModel : PageModel
    {
        private readonly GestaoDeLaboratorios.Data.ApplicationDbContext _context;

        public CreateModel(GestaoDeLaboratorios.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Computador Computador { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Computadores.Add(Computador);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
