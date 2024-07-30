using WebAPPSignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPPSignalR.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebAPPSignalRContext>(options =>
        options.UseSqlServer("Data Source=DESKTOP-H20O12E;Initial Catalog=SampleSignalRIdentityDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebAPPSignalRContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SamplePolicyName", policy =>
    {
        policy.Requirements.Add(new SampleCustomPolicy());
    });
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapHub<SampleHub>("/sampleHubRoutePattern");

app.Run();
