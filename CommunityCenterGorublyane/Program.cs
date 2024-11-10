using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CommunityCenterDbContextConnection") ?? throw new InvalidOperationException("Connection string 'CommunityCenterDbContextConnection' not found.");

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Activity All",
        pattern: "Deinosti/Vsichki",
        defaults: new { Controller = "Activity", Action = "All" }
    );

    endpoints.MapControllerRoute(
        name: "Activity Details",
        pattern: "/Deinosti/Detaili/{id}/{information}",
        defaults: new { Controller = "Activity", Action = "Details" }
    );

    endpoints.MapControllerRoute(
        name: "Activity Add",
        pattern: "Deinosti/Dobavi",
        defaults: new { Controller = "Activity", Action = "Add" }
    );

    endpoints.MapControllerRoute(
       name: "Activity Edit",
       pattern: "Deinosti/{id}/Redaktirai",
       defaults: new { Controller = "Activity", Action = "Edit" }
   );

    endpoints.MapControllerRoute(
       name: "Activity Delete",
       pattern: "Deinosti/Iztrii/{id}",
       defaults: new { Controller = "Activity", Action = "Delete" }
   );

    endpoints.MapControllerRoute(
        name: "News All",
        pattern: "Novini/Vsichki",
        defaults: new { Controller = "News", Action = "All" }
    );

    endpoints.MapControllerRoute(
        name: "News Details",
        pattern: "/Novini/Detaili/{id}/{information}",
        defaults: new { Controller = "Activity", Action = "Details" }
    );

    endpoints.MapControllerRoute(
        name: "News Add",
        pattern: "Novini/Dobavi",
        defaults: new { Controller = "Activity", Action = "Add" }
    );

    endpoints.MapControllerRoute(
       name: "News Edit",
       pattern: "Novini/{id}/Redaktirai",
       defaults: new { Controller = "Activity", Action = "Edit" }
   );

    endpoints.MapControllerRoute(
       name: "News Delete",
       pattern: "Novini/Iztrii/{id}",
       defaults: new { Controller = "Activity", Action = "Delete" }
   );

    endpoints.MapControllerRoute(
        name: "History",
        pattern: "Istoriq",
        defaults: new { Controller = "History", Action = "Index" }
    );

    endpoints.MapControllerRoute(
       name: "Contacts",
       pattern: "Kontakti",
       defaults: new { Controller = "Contact", Action = "Index" }
   );

    endpoints.MapControllerRoute(
        name: "Gallery All",
        pattern: "Galeriq",
        defaults: new { Controller = "Gallery", Action = "All" }
    );

    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

await app.CreateAdminRoleAsync();

await app.RunAsync();
