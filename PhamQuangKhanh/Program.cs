
using Microsoft.EntityFrameworkCore;
using PhamQuangKhanh.Models;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký MVC
builder.Services.AddControllersWithViews();

// Kết nối cơ sở dữ liệu SQL Server
builder.Services.AddDbContext<QLHangHoaContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("QLHangHoa")));

// Khởi tạo ứng dụng
var app = builder.Build();

// Cấu hình xử lý lỗi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Sử dụng file tĩnh
app.MapStaticAssets();

// Cấu hình đường dẫn MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
