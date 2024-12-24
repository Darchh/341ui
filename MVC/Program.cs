using BLL.DAL;
using BLL.Models;
using BLL.Services;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = "server=(localdb)\\mssqllocaldb;database=EstateAgency;trusted_connection=true;";
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IService<Agent, AgentModel>, AgentService>();

builder.Services.AddScoped<IService<Customer, CustomerModel>, CustomerService>();

builder.Services.AddScoped<IService<Sale, SaleModel>, SaleService>();

builder.Services.AddScoped<IService<Residence, ResidenceModel>, ResidenceService>();

builder.Services.AddScoped<IService<Document, DocumentModel>, DocumentService>();

builder.Services.AddScoped<IService<Interview, InterviewModel>, InterviewService>();


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

app.Run();
