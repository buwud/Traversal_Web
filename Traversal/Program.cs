using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.Validations;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IValidator<Reservation>, NewReservationValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<NewReservationValidator>();

//LOGLAMA 
builder.Services.AddLogging(x =>
{
    x.ClearProviders();//log varsa temizliyor
    x.SetMinimumLevel(LogLevel.Debug);//log işlemi debugtan itibaten başlasın
    x.AddDebug();
});

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.ContainerDependencies();

builder.Services.AddHttpClient();

//builder.Services.AddAutoMapper(typeof(Startup));

//builder.Services.CustomerValidator();

//builder.Services.AddControllersWithViews().AddFluentValidation();

builder.Services.AddMvc(Config =>
{
	var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
	Config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();

//LOGLAMA




builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme
    ).AddCookie(x =>
    {
        x.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/SignIn/";
    options.LogoutPath = "/Login/SignIn/";
});

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = 5242880;//photo yükleme sınırını 5mb a ayarladım
});

builder.Host.ConfigureLogging(logging =>
{
    var path = Directory.GetCurrentDirectory();
    logging.AddFile($"{path}/Logs/Log1.txt");
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}"); 
//{0} dışarıdan bir kod alabilir demek
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
