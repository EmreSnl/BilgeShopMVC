using Microsoft.AspNetCore.Mvc;

namespace BilgeShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("urunler/{categoryName}/{categoryId}")]
        public IActionResult Index(int? categoryId)
        {
            ViewBag.CategoryId = categoryId;
            // Buradan ViewBag ile categoryId bivlgisini ilgili view'e taşıyorum. View'de istediğim componente göndereceğim.

            return View();
        }
    }
}
