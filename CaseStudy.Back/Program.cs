using CaseStudy.Data.Context;
using CaseStudy.Entities.Models;
using Microsoft.EntityFrameworkCore;
using CaseStudy.Business.Factories;
using Microsoft.Extensions.Configuration;
using CaseStudy.Business.Providers.Email;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CaseStudyContext>(opt =>
{
    opt.UseSqlServer("server=(localdb)\\mssqllocaldb; database=CaseStudy; integrated security=true;");
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CaseStudyContext>();

//Factory pattern 
builder.Services.AddDependenciesFactory();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

//builder.Services.AddSession();
//builder.Services.AddAuthentication();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
