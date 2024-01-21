using MatuszewskiStasiak.SuperBooks.BLC;
using MatuszewskiStasiak.SuperBooks.DAOSQL;
using MatuszewskiStasiak.SuperBooks.Interfaces;
using MatuszewskiStasiak.SuperBooks.Web;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<BLC>();
builder.Services.AddControllersWithViews();
builder.Services.AddServerSideBlazor();

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

app.MapBlazorHub();

var rewriteOptions = new RewriteOptions();
rewriteOptions.AddRewrite("_blazor(.*)", "/_blazor$1", skipRemainingRules: true);
app.UseRewriter(rewriteOptions);

app.Run();
