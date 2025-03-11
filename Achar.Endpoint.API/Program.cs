using Achar.Infra.Access.EfCore.Repositories;
using Achar.Infra.Db.Sql;
using AcharDomainAppService;
using AcharDomainAppService.AcharDomainAppService;
using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Entites.Config;
using AcharDomainService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



var congiguration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var siteSetting = congiguration.GetSection(nameof(SiteSetting)).Get<SiteSetting>();
builder.Services.AddSingleton(siteSetting);

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(siteSetting.ConnectionString.SqlConnection)
);











builder.Services.AddScoped<IApplicationUserAppService, ApplicationUserAppService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();

builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IExpertAppService, ExpertAppService>();
builder.Services.AddScoped<IExpertService, ExpertService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();

builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<ISubCategoryAppService, SubCategoryAppService>();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();
builder.Services.AddScoped<IRequestService, RequestService>();

builder.Services.AddScoped<IHomeServiceRepository, HomeServiceRepository>();
builder.Services.AddScoped<IHomeServiceAppService, HomeServiceAppService>();
builder.Services.AddScoped<IHomeServiceService, HomeServiceService>();





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
