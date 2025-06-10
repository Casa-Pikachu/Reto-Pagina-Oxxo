using Pagina_Oxxo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();  
builder.Services.AddControllers();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.Add(new ServiceDescriptor(typeof(DataBaseContext), new DataBaseContext()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()){
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".data"] = "application/octet-stream";
provider.Mappings[".wasm"] = "application/wasm";
app.UseStaticFiles(new StaticFileOptions()
{
    ContentTypeProvider = provider,
});

app.UseSession();


app.MapStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();
app.MapControllers();

app.Run();