using Microsoft.EntityFrameworkCore;
using WebAppEFCoreCodeFirst.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddScoped<GenericRepository<Customer>>();
builder.Services.AddScoped<GenericRepository<Product>>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SampleDbContext>(
        options => options.UseSqlServer("Data Source=DESKTOP-H20O12E;Initial Catalog=SampleThiagoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

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
app.UseMvc();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
