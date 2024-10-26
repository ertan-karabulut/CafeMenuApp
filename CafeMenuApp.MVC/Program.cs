using CafeMenuApp.Persistence;
using CafeMenuApp.Application;
using CafeMenuApp.Infrastructure;
using FluentValidation.AspNetCore;
using CafeMenuApp.Application.Validation.Category;
using CafeMenuApp.Application.Validation.Product;
using CafeMenuApp.Application.Validation.Property;
using CafeMenuApp.Application.Validation.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<UpdateCategoryValidation>();
    fv.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidation>();
    fv.RegisterValidatorsFromAssemblyContaining<CreateProductValidation>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdateProductValidation>();
    fv.RegisterValidatorsFromAssemblyContaining<CreateProductValidation>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdatePropertyValidation>();
    fv.RegisterValidatorsFromAssemblyContaining<CreateUserValidation>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdateUserValidation>();
});
builder.Services.AddAuthentication("MyCookieAuthScheme")
    .AddCookie("MyCookieAuthScheme", options =>
    {
        options.LoginPath = "/User/Login";
        options.LogoutPath = "/User/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer();
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
