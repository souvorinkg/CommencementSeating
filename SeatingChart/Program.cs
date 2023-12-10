using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SeatingChart.Data;
var builder = WebApplication.CreateBuilder(args);

//Thread.Sleep(1000 * 60 * 5);

// Add services to the container.
builder.Services.AddRazorPages();
// builder.Services.AddDbContext<ChartContext>(options =>
//     options.UseSqlite(builder.Configuration.GetConnectionString("ChartContext") ?? throw new InvalidOperationException("Connection string 'ChartContext' not found.")));

builder.Services.AddDbContext<ChartContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("A")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ChartContext>();
    //context.Database.EnsureCreated();

    // for (; ; )
    // {
    //     try
    //     {
            DbInitializer.Initialize(context);
    //         break;
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine(ex.Message);
    //         Thread.Sleep(1000*10);
    //     }
    // }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
