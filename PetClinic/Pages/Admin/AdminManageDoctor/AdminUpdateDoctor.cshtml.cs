using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManageDoctor
{
    public class AdminUpdateDoctorModel : PageModel
    {
		[BindProperty]
		public decimal revenue { get; set; }
		[BindProperty]
		public int totalCustomers { get; set; }
		[BindProperty]
		public int totalBookings { get; set; }
		[BindProperty]
		public int updateUserId { get; set; }
		[BindProperty]
		public string updateFirstName { get; set; } = null!;
		[BindProperty]
		public string updateLastName { get; set; } = null!;
		[BindProperty]
		public string updateSocialNumber { get; set; } = null!;
		[BindProperty]
		public string updatePassword { get; set; } = null!;
		[BindProperty]
		public string? updatePhoneNumber { get; set; }
		[BindProperty]
		public string? updateAddress { get; set; }
		[BindProperty]
		public string? updateEmail { get; set; }
		[BindProperty]
		public IFormFile? updateImage { get; set; }
		[BindProperty]
		public string? updateGender { get; set; }
		[BindProperty]
		public decimal? updateEmployeeSalary { get; set; }
		[BindProperty]
		public string? updateDoctorRank { get; set; }
		[BindProperty]
		public int? updateDoctorCapacity { get; set; }
		[BindProperty]
		public int? updateActiveStatus { get; set; }
		[BindProperty]
		public int? updateRole { get; set; }
		public User user { get; set; } = new User();

		private readonly IUserService userService;

		public AdminUpdateDoctorModel(IUserService _userService)
		{
			userService = _userService;
		}

		public void OnGet(int doctorid)
		{
			try
			{
				user = userService.GetUserById(doctorid);
				if (user != null)
				{
					updateUserId = user.UserId;
				}
				else
				{
					ModelState.AddModelError(string.Empty, "User not found.");
					return;
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, "Error occurred while getting doctor details.");
				Response.Redirect("AdminViewStaffList");
			}
		}

		public async Task OnPostUpdateUserAsync()
		{
			ModelState.Clear();
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError(string.Empty, "ModelState is NOT valid");
				return;
			}

			User existingUser = userService.GetUserById(updateUserId);
			if (existingUser == null)
			{
				ModelState.AddModelError(string.Empty, "Non-existing user");
				return;
			}

			try
			{
				existingUser.FirstName = updateFirstName;
				existingUser.LastName = updateLastName;
				existingUser.SocialNumber = updateSocialNumber;
				existingUser.Email = updateEmail;
				existingUser.Password = DAOUtilities.Instance.HashPassword(updatePassword);
				existingUser.PhoneNumber = updatePhoneNumber;
				existingUser.Address = updateAddress;
				existingUser.Gender = updateGender;
				existingUser.EmployeeSalary = updateEmployeeSalary;
				existingUser.DoctorRank = updateDoctorRank;
				existingUser.DoctorCapacity = updateDoctorCapacity;

				existingUser.ActiveStatus = updateActiveStatus;

				if (updateImage != null)
				{
					// Process the uploaded image file
					var imagePath = Path.Combine("wwwroot/img", updateImage.FileName);
					using (var stream = new FileStream(imagePath, FileMode.Create))
					{
						await updateImage.CopyToAsync(stream);
					}
					existingUser.Image = "/img/" + updateImage.FileName;
				}

				userService.UpdateUser(existingUser);

				Response.Redirect("AdminViewDoctorList");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, "Error occurred while updating user.");
				return;
			}
		}
	}
}
