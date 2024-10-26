using CafeMenuApp.Application.DTO.Category;
using CafeMenuApp.Application.DTO.Product;
using CafeMenuApp.Application.DTO.Property;
using CafeMenuApp.Application.Interface.Infrastructure.Service;
using CafeMenuApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;

namespace CafeMenuApp.MVC.Controllers;
[Authorize]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IPropertyService _propertyService;
    public ProductController(IProductService productService, ICategoryService categoryService, IPropertyService propertyService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _propertyService = propertyService;
    }

    public async Task<IActionResult> Create()
    {
        var categories = await _categoryService.ListAsync();
        ViewBag.Categories = categories.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString(),
        });
        return View(new DetailProductDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequestDto product, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        await _productService.CreateAsync(product);
        return View("List", await _productService.ListAsync(cancellationToken));
    }

    public async Task<IActionResult> List(CancellationToken cancellationToken = default)
    {
        return View(await _productService.ListAsync(cancellationToken));
    }

    [Route("Product/Detail/{id:guid}")]
    public async Task<IActionResult> Detail(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _productService.GetDetailByIdAsync(id, cancellationToken);
        var categories = await _categoryService.ListAsync(cancellationToken);
        ViewBag.Categories = categories.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString(),
            Selected = product.CategoryId == x.Id
        });
        var properties = await _propertyService.ListAsync(cancellationToken);
        var propertyDtoList = new List<DetailPropertyDto>();
        propertyDtoList.AddRange(product.Properties.Select(x => new DetailPropertyDto
        {
            Id = x.Id,
            IsSelected = true,
            Key = x.Key,
            Value = x.Value,
        }).ToList());
        propertyDtoList.AddRange(properties.Where(x=> !product.Properties.Select(y => y.Id).ToList().Contains(x.Id)).Select(x => new Application.DTO.Property.DetailPropertyDto
        {
            Id = x.Id,
            Key = x.Key,
            Value = x.Value,
        }).ToList());
        product.Properties = propertyDtoList;
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Update(DetailProductDto product, CancellationToken cancellationToken = default)
    {
        var categories = await _categoryService.ListAsync(cancellationToken);
        ViewBag.Categories = categories.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString(),
            Selected = product.CategoryId == x.Id
        });
        if (!ModelState.IsValid)
        {
            return View("Detail", product);
        }
        await _productService.UpdateAsync(product, cancellationToken);
        return View("List", await _productService.ListAsync(cancellationToken));
    }

    [Route("Product/Delete/{id:guid}")]

    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _productService.GetDetailByIdAsync(id, cancellationToken);
        
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProduct(DetailCategoryDto product, CancellationToken cancellationToken = default)
    {
        await _productService.DeleteAsync(product.Id, cancellationToken);
        return View("List", await _productService.ListAsync(cancellationToken));
    }
}
