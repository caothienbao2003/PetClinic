using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PetClinic.Pages.Homepages
{
    public class PublicModel : PageModel
    {
        //private readonly IArticleService articleService;
        //private readonly IReviewService reviewService;

        //public PublicModel(IArticleService _articleService, IReviewService _reviewService)
        //{
        //    articleService = _articleService;
        //    reviewService = _reviewService;
        //}

        //public List<Article> articleList { get; set; } = default!;
        //public List<Review> reviewList { get; set; } = default!;
        public void OnGet()
        {
            //articleList = articleService.GetAll();
            //reviewList = reviewService.GetAll();
        }
    }
}
