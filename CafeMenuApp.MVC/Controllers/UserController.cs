using CafeMenuApp.Application.DTO.Property;
using CafeMenuApp.Application.DTO.User;
using CafeMenuApp.Application.Interface.Infrastructure.Service;
using CafeMenuApp.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeMenuApp.MVC.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Create()
    {
        return View(new DetailUserDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequestDto user, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        await _userService.CreateAsync(user);
        return View("List", await _userService.ListAsync(cancellationToken));
    }

    public async Task<IActionResult> List(CancellationToken cancellationToken = default)
    {
        return View(await _userService.ListAsync(cancellationToken));
    }

    [Route("User/Detail/{id:guid}")]
    public async Task<IActionResult> Detail(Guid id,CancellationToken cancellationToken = default)
    {
        var user = await _userService.GetDetailByIdAsync(id, cancellationToken);
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Update(DetailUserDto user, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return View("Detail", user); 
        }
        await _userService.UpdateAsync(user, cancellationToken);
        return View("List", await _userService.ListAsync(cancellationToken));
    }

    [Route("User/Delete/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _userService.GetDetailByIdAsync(id, cancellationToken);
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(DetailUserDto user, CancellationToken cancellationToken = default)
    {
        await _userService.DeleteAsync(user.Id, cancellationToken);
        return View("List",await _userService.ListAsync(cancellationToken));
    }
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost, AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (await _userService.Login(model.UserName, model.Password))
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, model.UserName)
        };

            var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuthScheme");

            await HttpContext.SignInAsync("MyCookieAuthScheme", new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Geçersiz kullanýcý adý veya þifre");
        return View();
    }
    [AllowAnonymous]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("MyCookieAuthScheme");
        return View("Login");
    }
}
