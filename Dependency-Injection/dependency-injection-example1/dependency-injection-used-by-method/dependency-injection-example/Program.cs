using dependency_injection_example.Services.Log;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


/*
 *  Dependency Injection registration
 */
builder.Services.Add(new ServiceDescriptor(typeof(ILog), new DefaultLog()));  //share single instance throughout the application life time
//builder.Services.Add(new ServiceDescriptor(typeof(ILog), new DefaultLog()), ServiceLifetime.Transient);  //Create new instance when you ask it
//builder.Services.Add(new ServiceDescriptor(typeof(ILog), new DefaultLog()), ServiceLifetime.Scoped);     //Create new instance for every single request


/*
 *  Dependency Injection registration by methods
 */
//builder.Services.AddSingleton<ILog, DefaultLog>();
//builder.Services.AddTransient<ILog, DefaultLog>();
//builder.Services.AddScoped<ILog, DefaultLog>();



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

app.Run();
