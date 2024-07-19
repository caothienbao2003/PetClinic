﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Staff.CageManagement
{
    //[Authorize(Roles = "Staff")]
    public class IndexModel : PageModel
    {
        private readonly ICageService cageService;

        public IndexModel(ICageService _cageService)
        {
            cageService = _cageService;
        }

        public List<Cage> Cage { get;set; } = default!;

        public void OnGet()
        {
            Cage = cageService.GetAllCage();
            string role = HttpContext.Session.GetString("Role");
            if (role == null)
            {
                Response.Redirect("/Authentication/Login");
            }
            else if(role != "1")
            {
                if (role == "0")
                {
                    Response.Redirect("/Customer/CustomerHomePage");
                }
                else if (role == "2")
                {
                    Response.Redirect("/Doctor/DoctorHomePage");
                }
                else
                {
                    Response.Redirect("/Admin/AdminHomePage");
                }
            }
        }
    }
}
