using CafeMenuApp.Application.DTO.Category;
using CafeMenuApp.Application.Interface.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CafeMenuApp.MVC.Controllers;
[Authorize]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Create()
    {
        var parentCategories = await _categoryService.ListAsync();
        ViewBag.ParentCategories = parentCategories.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString(),
        });
        return View(new DetailCategoryDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryRequestDto category, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        await _categoryService.CreateAsync(category);
        return View("List", await _categoryService.ListAsync(cancellationToken));
    }

    public async Task<IActionResult> List(CancellationToken cancellationToken = default)
    {
        return View(await _categoryService.ListAsync(cancellationToken));
    }

    [Route("Category/Detail/{id:guid}")]
    public async Task<IActionResult> Detail(Guid id,CancellationToken cancellationToken = default)
    {
        var categoriy = await _categoryService.GetDetailByIdAsync(id, cancellationToken);
        var parentCategories = await _categoryService.ListAsync(cancellationToken);
        ViewBag.ParentCategories = parentCategories.Where(x => x.Id != id).Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString(),
            Selected = categoriy.ParentCategoryId == x.Id
        });
        return View(categoriy);
    }

    [HttpPost]
    public async Task<IActionResult> Update(DetailCategoryDto category, CancellationToken cancellationToken = default)
    {
        var parentCategories = await _categoryService.ListAsync(cancellationToken);
        ViewBag.ParentCategories = parentCategories.Where(x => x.Id != category.Id).Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString(),
            Selected = category.ParentCategoryId == x.Id
        });
        if (!ModelState.IsValid)
        {
            return View("Detail", category); 
        }
        await _categoryService.UpdateAsync(category, cancellationToken);
        return View("Detail", category);
    }

    [Route("Category/Delete/{id:guid}")]

    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var categoriy = await _categoryService.GetDetailByIdAsync(id, cancellationToken);
        return View(categoriy);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCategory(DetailCategoryDto category, CancellationToken cancellationToken = default)
    {
        await _categoryService.DeleteAsync(category.Id, cancellationToken);
        return View("List",await _categoryService.ListAsync(cancellationToken));
    }
}
