using Microsoft.EntityFrameworkCore;
using DbApp_CRUD.Data; // Unga namespace check pannikonga

var builder = WebApplication.CreateBuilder(args);

// --- INTHA IDATHULA THAAN DATABASE SERVICE-AH ADD PANNANUM ---
// Ithu thaan Dependency Injection (DI) container-la AppDbContext-ah register pannuthu.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("EmployeeDb")); 
// -----------------------------------------------------------

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build(); // Service registration ithuku munnaadiye mudiyanum

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();