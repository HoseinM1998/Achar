using Achar.Endpoint.Razor.Middleware;
using Achar.Infra.Access.EfCore.Repositories;
using Achar.Infra.Db.Sql;
using AcharDomainAppService;
using AcharDomainAppService.AcharDomainAppService;
using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.BaseData;
using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.Image;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Entites;
using AcharDomainCore.Entites.Config;
using AcharDomainService;
using Framework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;


//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(o => {
    o.ClearProviders();
    o.AddSerilog();
}).UseSerilog((context, config) =>
{
    //config.WriteTo.Console();
    config.WriteTo.Seq("http://localhost:5341", apiKey: "81g7sJguN5KRaJbWkyBs");
});

//builder.Services.AddSerilog();



//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information()
//    .WriteTo.Console()
//    .WriteTo.Seq("http://localhost:5341", apiKey: "81g7sJguN5KRaJbWkyBs")
//    .CreateLogger();
//builder.Host.UseSerilog((context, config) =>
//{
//    config.WriteTo.Console();
//    config.WriteTo.Seq("http://localhost:5341", apiKey: "81g7sJguN5KRaJbWkyBs");
//});
//builder.Services.AddSerilog();





var congiguration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var siteSetting = congiguration.GetSection(nameof(SiteSetting)).Get<SiteSetting>();
builder.Services.AddSingleton(siteSetting);

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(siteSetting.ConnectionString.SqlConnection)
);



builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddMemoryCache();


builder.Services.AddScoped<IApplicationUserAppService, ApplicationUserAppService>();



builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminAppService, AdminAppService>();

builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();



builder.Services.AddScoped<IBaseRepository, BaseRepository>();


builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityAppService, CityAppService>();

builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IBidAppService, BidAppService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();

builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<ISubCategoryAppService, SubCategoryAppService>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();

builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IExpertAppService, ExpertAppService>();
builder.Services.AddScoped<IExpertService, ExpertService>();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();
builder.Services.AddScoped<IRequestService, RequestService>();

builder.Services.AddScoped<IHomeServiceRepository, HomeServiceRepository>();
builder.Services.AddScoped<IHomeServiceAppService, HomeServiceAppService>();
builder.Services.AddScoped<IHomeServiceService, HomeServiceService>();






builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddErrorDescriber<PersianIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppDbContext>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseErrorLogging();
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();


app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
