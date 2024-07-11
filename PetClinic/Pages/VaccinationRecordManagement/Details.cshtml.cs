﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.VaccinationRecordManagement
{
    public class DetailsModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public DetailsModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

      public VaccinationRecord VaccinationRecord { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.VaccinationRecords == null)
            {
                return NotFound();
            }

            var vaccinationrecord = await _context.VaccinationRecords.FirstOrDefaultAsync(m => m.VaccinationRecordsId == id);
            if (vaccinationrecord == null)
            {
                return NotFound();
            }
            else 
            {
                VaccinationRecord = vaccinationrecord;
            }
            return Page();
        }
    }
}
