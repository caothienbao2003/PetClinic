using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;

namespace PetClinic.Pages.StaffPages.HospitializeManagement
{
    public class CreateModel : PageModel
    {
        private readonly PetClinicContext context;

        public CreateModel()
        {
            context = new PetClinicContext();
        }

        public IActionResult OnGet(int? CageId)
        {
            ViewData["CageId"] = new SelectList(context.Cages, "CageId", "CageId");
            ViewData["DoctorId"] = new SelectList(context.Users, "UserId", "UserId");
            ViewData["PetId"] = new SelectList(context.Pets, "PetId", "PetId");

            if (CageId.HasValue)
            {
                Hospitalize = new Hospitalize { CageId = CageId.Value };
            }

            return Page();
        }

        [BindProperty]
        public Hospitalize Hospitalize { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || context.Hospitalizes == null || Hospitalize == null)
            {
                return Page();
            }

            context.Hospitalizes.Add(Hospitalize);

            var cage = await context.Cages.FindAsync(Hospitalize.CageId);
            if(cage != null)
            {
                cage.Status = "Occupied";
                context.Cages.Update(cage);
            }

            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
