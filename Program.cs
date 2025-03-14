using Microsoft.EntityFrameworkCore;
using MyBooks.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
ServerVersion serverVersion = new MariaDbServerVersion(new Version(10, 4, 32));

builder.Services.AddDbContext<MyBooksDbContext>(options =>
 options.UseMySql(builder.Configuration.GetConnectionString("MyBooksDb"), serverVersion)
 .LogTo(Console.WriteLine, LogLevel.Information)
//  .EnableSensitiveDataLogging()
//  .EnableDetailedErrors()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// C:\Users\Yemzzy\Desktop\CPA\3rd year\1st Semester\C#\Learn\Publish\PublishMyBooks
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
