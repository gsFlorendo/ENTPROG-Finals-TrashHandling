using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrashHandling.Areas.Identity.Data;
using TrashHandling.Config;
using TrashHandling.Data;
using TrashHandling.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PatientConsultAuthDBContextConnection") ?? throw new InvalidOperationException("Connection string 'PatientConsultAuthDBContextConnection' not found.");

builder.Services.AddDbContext<PatientConsultAuthDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<PatientConsultAuthDBContext>();

// Add AutoMapper configuration
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));                   //---

builder.Services.AddScoped<ITrashCollectionRepo, TrashCollectionRepo>();    //---
builder.Services.AddScoped<IFacilityRepo, FacilityRepo>();                  //---
builder.Services.AddScoped<IShopRepo, ShopRepo>();                          //---

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
