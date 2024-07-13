using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetClinic.Pages.Admin
{
    public class AdminHomePageModel : PageModel
    {
        public decimal Revenue { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalBookings { get; set; }
        public double AverageRating { get; set; }

        public List<decimal> RevenueData { get; set; }
        public List<int> BookingData { get; set; }
        public List<int> CustomerData { get; set; }

        public async Task OnGet()
        {
            // Placeholder data, replace with actual data retrieval logic
            Revenue = 10000m;
            TotalCustomers = 500;
            TotalBookings = 200;
            AverageRating = 4.5;

            RevenueData = new List<decimal> { 1000, 2000, 3000, 4000, 5000 };
            BookingData = new List<int> { 10, 20, 30, 40, 50 };
            CustomerData = new List<int> { 5, 10, 15, 20, 25 };
        }
    }
}
