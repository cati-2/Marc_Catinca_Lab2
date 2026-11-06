using Microsoft.EntityFrameworkCore;
using Marc_Catinca_Lab2.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<Marc_Catinca_Lab2Context>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("Marc_Catinca_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Marc_Catinca_Lab2Context' not found.")));


builder.Services.AddDbContext<LibraryIdentityContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString ("LibraryIdentityContext") ?? throw new InvalidOperationException("Connection string 'LibraryIdentityContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();



app.Run();

