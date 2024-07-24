using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManageStaff
{
	// AdminViewStaffList.cshtml.cs

	public class AdminViewStaffListModel : PageModel
	{
		private readonly IUserService userService;

		[BindProperty]
		public decimal revenue { get; set; }
		[BindProperty]
		public int totalCustomers { get; set; }
		[BindProperty]
		public int totalBookings { get; set; }
		[BindProperty]
		public string newFirstName { get; set; } = null!;
		[BindProperty]
		public string newLastName { get; set; } = null!;
		[BindProperty]
		public string? newPhoneNumber { get; set; } = null!;
		[BindProperty]
		public string? newAddress { get; set; } = null!;
		[BindProperty]
		public string? newEmail { get; set; } = null!;
		[BindProperty]
		public string newPassword { get; set; } = null!;
		[BindProperty]
		public string? newGender { get; set; } = null!;
		[BindProperty]
		public string newSocialNumber { get; set; } = null!;
		[BindProperty]
		public decimal newEmployeeSalary { get; set; }

		[BindProperty]
		public int? Role { get; set; }
		[BindProperty]
		public int? ActiveStatus { get; set; }

		public AdminViewStaffListModel(IUserService _userService)
		{
			userService = _userService;
		}

		public List<User> StaffList { get; set; }

		public void OnGet()
		{
			ModelState.Clear();
			InitializePage();
		}

		public void OnPostCreateUser()
		{
            ModelState.Clear();
            if (!ModelState.IsValid)
			{
				InitializePage();
				ModelState.Clear();
				ModelState.AddModelError(string.Empty, "ModelState is NOT valid.");
				return; 
			}

			User existingUser = userService.GetUserByEmail(newEmail);
			if (existingUser != null)
			{
				ModelState.AddModelError(string.Empty, "Email already exists.");
				return; 
			}

			try
			{
				// Proceed with registration
				var newUser = new User
				{
					FirstName = newFirstName,
					LastName = newLastName,
					PhoneNumber = newPhoneNumber,
					Address = newAddress,
					Email = newEmail,
					Password = DAOUtilities.Instance.HashPassword(newPassword),
					Gender = newGender,
					SocialNumber = newSocialNumber,
					EmployeeSalary = newEmployeeSalary,
					Role = 1, // 1 is the role for a staff
					ActiveStatus = 1
				};

				userService.AddUser(newUser);
				InitializePage();
				return;
			}
			catch (Exception ex)
			{
				InitializePage();
				ModelState.AddModelError(string.Empty, "Error occurred while creating staff.");
				return;
			}
		}

		private void InitializePage()
		{
			StaffList = userService.GetUserListWithRole(UserRole.Staff);
		}
	}

}
