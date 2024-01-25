using BilgeShop.Business.Dtos;
using BilgeShop.Business.Services;
using BilgeShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BilgeShop.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public IActionResult List()
        {
            var listCategoryDtos = _categoryService.GetCategories();

            var viewModel = listCategoryDtos.Select(x => new CategoryListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Summary = x.Description is not null && x.Description.Length > 20 ? x.Description.Substring(0, 20) + "..." : x.Description
            }).ToList();

            return View(viewModel);
        }

        public IActionResult New()
        {
     

            return View("Form", new CategoryFormViewModel ());
        }

        public IActionResult Edit(int id)
        {
            var editCategoryDto = _categoryService.GetCategoryById(id);

            var viewModel = new CategoryFormViewModel()
            {
                Id = editCategoryDto.Id,
                Name = editCategoryDto.Name,
                Description = editCategoryDto.Description
            };

            return View("form", viewModel);

        }


        [HttpPost]
        public IActionResult Save(CategoryFormViewModel formData)
        { 

            if (!ModelState.IsValid)
            {
                return View("Form", formData);
            }


            if (formData.Id == 0) // yeni kayıt
            {

                var addCategoryDto = new AddCategoryDto()
                {
                    Name = formData.Name.Trim()
                };

         
                if (formData.Description is not null)
                {
                    addCategoryDto.Description = formData.Description.Trim();
                }

                var result = _categoryService.AddCategory(addCategoryDto);


                if (result)
                {
                    RedirectToAction("List");

                }
                else
                {
                    ViewBag.ErrorMessage = "Bu isimde bir kategori zaten mevcut.";
                    return View("Form", formData);
                }

            }
            else 
            {
                var editCategoryDto = new EditCategoryDto()
                {
                    Id = formData.Id,
                    Name = formData.Name,
                    Description = formData.Description
                };

                _categoryService.EditCategory(editCategoryDto);

                return RedirectToAction("List");
            }


            return RedirectToAction("List");
        }


        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("List");
        }
    }
}
