using CafeMenuApp.Application.DTO.Property;
using CafeMenuApp.Application.Interface.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeMenuApp.MVC.Controllers;
[Authorize]
public class PropertyController : Controller
{
    private readonly IPropertyService _propertyService;

    public PropertyController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    public IActionResult Create()
    {
        return View(new DetailPropertyDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePropertyRequestDto property, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        await _propertyService.CreateAsync(property);
        return View("List", await _propertyService.ListAsync(cancellationToken));
    }

    public async Task<IActionResult> List(CancellationToken cancellationToken = default)
    {
        return View(await _propertyService.ListAsync(cancellationToken));
    }

    public async Task<IActionResult> Detail(int id,CancellationToken cancellationToken = default)
    {
        var property = await _propertyService.GetDetailByIdAsync(id, cancellationToken);
        return View(property);
    }

    [HttpPost]
    public async Task<IActionResult> Update(DetailPropertyDto property, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return View("Detail", property); 
        }
        await _propertyService.UpdateAsync(property, cancellationToken);
        return View("List", await _propertyService.ListAsync(cancellationToken));
    }


    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
    {
        var property = await _propertyService.GetDetailByIdAsync(id, cancellationToken);
        return View(property);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProperty(DetailPropertyDto property, CancellationToken cancellationToken = default)
    {
        await _propertyService.DeleteAsync(property.Id, cancellationToken);
        return View("List",await _propertyService.ListAsync(cancellationToken));
    }
}
