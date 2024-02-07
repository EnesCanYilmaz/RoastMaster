using CoffeeProject.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddPersistenceServices();
builder.Services.AddDistributedMemoryCache(); // Bellekte oturum verilerini tutmak için bir önbellek sağlar
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "MyApp.Session"; // Session çerezinin adı
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturumun ne kadar süreyle aktif kalacağı
    options.Cookie.HttpOnly = true; // Sadece sunucu tarafından okunabilen bir çerez olmasını sağlar
    options.Cookie.IsEssential = true; // GDPR uyumluluğu için gereklidir
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

