using CoreDemo.DataAccess.Constructs;
using CoreDemo.DataAccess.Interfaces;
using CoreDemo.Service;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<IConnection<MsSqlConnection>, MsSqlConnection>(provider =>
{
	var conn = new MsSqlConnection();
       builder.Configuration.GetSection("DbConnection")
		.Bind(conn);
	return conn;
});
builder.Services.AddScoped<IContext<MsSqlContext>, MsSqlContext>();
builder.Services.AddScoped<IReader<MsSqlReader>, MsSqlReader>();
builder.Services.AddScoped<IWriter<MsSqlWriter>, MsSqlWriter>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskController}/{action=Index}/{id?}");
app.Run();
