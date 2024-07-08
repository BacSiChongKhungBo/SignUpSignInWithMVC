using Microsoft.EntityFrameworkCore;

namespace WebApplication5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //AddControllersWithViews() : Thêm các controller trong thư mục
            // controller vào để chạy cùng project
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MyDBContext>(options => 
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("MyDB")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection(); // định tuyến | trang web : https:googogle.com 
            app.UseStaticFiles();// appsetting.json

            app.UseRouting(); //routing

            app.UseAuthorization();//c#5

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Privacy}/{id?}");

            app.Run();
        }
    }
}