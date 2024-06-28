using ContactBook.DBL;
using ContactBook.DBL.Stores;
using ContactBook.Services.Interfaces;
using ContactBook.Services.Mapper;
using ContactBook.Services.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ContactStore>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddDbContext<ContactDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ContactConnString")));




// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 60000000; // Adjust limit as needed
});

var app = builder.Build();

try
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ContactDBContext>();
        context.Database.Migrate();
    }
}
catch (Exception)
{
}


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
    pattern: "{controller=Contact}/{action=Index}/{id?}");

app.Run();
