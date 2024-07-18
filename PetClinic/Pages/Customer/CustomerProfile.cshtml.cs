using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer
{
    public class CustomerProfileModel : PageModel
    {
        private readonly IUserService userService;

        public CustomerProfileModel(IUserService _userService)
        {
            userService = _userService;
        }

        [BindProperty]
        public User user { get; set; } = default!;

        [BindProperty]
        public IFormFile? updateImage { get; set; }
        //[BindProperty]
        //public string updateFirstName { get; set; } = null!;
        //[BindProperty]
        //public string updateLastName { get; set; } = null!;
        //[BindProperty]
        //public string updateSocialNumber { get; set; } = null!;
        //[BindProperty]
        //public string updatePassword { get; set; } = null!;
        //[BindProperty]
        //public string? updatePhoneNumber { get; set; }
        //[BindProperty]
        //public string? updateAddress { get; set; }
        //[BindProperty]
        //public string? updateEmail { get; set; }
        //[BindProperty]
        //public string? updateGender { get; set; }

        public void OnGet()
        {
            string userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                user = new User();
            }
            else
            {
                user = userService.GetUserById(int.Parse(userId));
            }
        }

        public async Task OnPostAsync()
        {
            ModelState.Clear();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "ModelState is NOT valid");
                return;
            }

            User existingUser = userService.GetUserById(user.UserId);
            if(existingUser == null)
            {
                ModelState.AddModelError(string.Empty, "Non-existing user");
                return;
            }

            try
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.SocialNumber = user.SocialNumber;
                existingUser.Email = user.Email;
                existingUser.Password = DAOUtilities.Instance.HashPassword(user.Password);
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.Address = user.Address;
                existingUser.Gender = user.Gender;

                if (updateImage != null)
                {
                    var imagePath = Path.Combine("wwwroot", "img", updateImage.FileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await updateImage.CopyToAsync(stream);
                    }

                    existingUser.Image = "/img/" + updateImage.FileName;
                }

                userService.UpdateUser(existingUser);
                Response.Redirect("./CustomerProfile");
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(string.Empty, "Error occurred while updating user.");
                return;
            }
        }
    }
}
