//configure services
using DataLayer;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<ForwardedHeadersOptions>(opts =>
{
    // my attempt
    opts.KnownProxies.Add(IPAddress.Parse("http://127.1.1.1:2666"));

    opts.KnownProxies.Add(IPAddress.Parse("server.noelwiz.gay"));

    //tutorial's thing, but with my ip
    opts.KnownProxies.Add(IPAddress.Parse("185.148.129.105"));
});


builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));


builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgres")));





//configure app
var app = builder.Build();



app.MapReverseProxy();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// adds /controller/action routes
app.MapDefaultControllerRoute();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
