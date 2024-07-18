using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PetClinic.Pages.Customer.BookingManagement
{
    public class PaymentInfoModel : PageModel
    {
        [BindProperty]
        public string BankAccountNumber { get; set; }
        [BindProperty]
        public string BankAccountOwnerName { get; set; }
        [BindProperty]
        public string BankName { get; set; }
        [BindProperty]
        public string BankImage { get; set; }
        [BindProperty]
        public string QrCodeImage { get; set; }

        public void OnGet()
        {
            BankAccountNumber = "123456789";
            BankAccountOwnerName = "John Doe";
            BankName = "Example Bank";
            BankImage = "/images/bank-logo.png";
            QrCodeImage = "/images/qr-code.png";
        }
    }
}
