using BilgeShop.Business.Services;
using BilgeShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilgeShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Detail(int id)
        {
            var productDetailDto = _productService.GetProductDetailById(id);

            var viewModel = new ProductDetailViewModel()
            {
                ProductId = productDetailDto.ProductId,
                ProductName = productDetailDto.ProductName,
                UnitPrice = productDetailDto.UnitPrice,
                UnitInStock = productDetailDto.UnitInStock,
                ImagePath = productDetailDto.ImagePath,
                Description = productDetailDto.Description,
                CategoryId = productDetailDto.CategoryId,
                CategoryName = productDetailDto.CategoryName
            };

            return View(viewModel);
        }
    }
}
