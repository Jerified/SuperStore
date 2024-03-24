using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SuperStore.Models;

namespace SuperStore.Controllers;

public class CategoriesController : Controller
{

    public IActionResult Index()
    {
        var categories = CategoriesRepository.GetCategories();
        return View(categories);
    }

    public IActionResult Add()
        {
            return View();
        }
    [HttpPost]
    public IActionResult Add(Category category)
    {
        if(ModelState.IsValid)
        {
            CategoriesRepository.AddCategory(category);
            return RedirectToAction(nameof(Index));
        };
        return View(category);
    }
    public IActionResult Edit(int? id)
    {
        // var category = new Category { CategoryId = id.HasValue ? id.Value : 0 };
        var category = CategoriesRepository.GetCategory(id.HasValue ? id.Value : 0);
        return View(category);
    }
    [HttpPost]
      public IActionResult Edit(Category category)
    {
        if(ModelState.IsValid)
        {
            CategoriesRepository.UpdateCategory(category.CategoryId, category);
            return RedirectToAction(nameof(Index));
        };

        return View(category);
    }

    public IActionResult Delete(int categoryId)
    {
            CategoriesRepository.DeleteCategory(categoryId);
            return RedirectToAction(nameof(Index));
        // return View(category);
    }

}
