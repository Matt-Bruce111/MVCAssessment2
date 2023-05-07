using MVCAssessment2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Configuration Root
IConfigurationRoot configuration; //normal variable
configuration = new ConfigurationBuilder().AddJsonFile("./config.json").Build();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the connection string
builder.Services.AddDbContext<CSIROContext>(options =>
//builder.Services.AddDbContext<ApplicantDataContext>(options =>
{
    var connectionString = configuration.GetConnectionString("DBConnection");
    options.UseSqlServer(connectionString);
});

// Create a user
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<CSIROContext>()
    //.AddEntityFrameworkStores<ApplicantDataContext>()
    .AddDefaultTokenProviders();

//APIs for registering session management
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    //pattern: "{controller=Applicant}/{action=Display}/{id?}");
    pattern: "{controller=Account}/{action=Register}/{id?}");
    //pattern: "{controller=Account}/{action=Login}/{id?}");
    //pattern: "{controller=Admin}/{action=CreateRole}/{id?}");
    //pattern: "{controller=Admin}/{action=ManageRole}/{id?}");

app.Run();

// Package test