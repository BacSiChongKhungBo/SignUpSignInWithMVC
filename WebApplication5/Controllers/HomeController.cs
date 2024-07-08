using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyDBContext _dbContext;
        public HomeController(ILogger<HomeController> logger, MyDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        //Không có tương tác gì với CSDL từ màn hình => ko cần post ở đây
        public IActionResult SignUp() //thực hiện hiển thị view
        {
            return View();
        }

        //muốn đẩy dữ liệu từ màn hình => DB : Cần phương thức POST trong web
        [HttpPost] //hàm code dưới phương thức này sẽ thực thi nhiệm vụ tương tự
        //muốn truyền dữ liệu từ View => controller: cần bind text từ bên views sang
        public IActionResult SignUp([Bind("UserName,Password")]User user)
        {
            //kiểm tra xem có user nào trùng trong DB ko
            bool isFound = _dbContext.Users.Any(x=> x.UserName.Equals(user.UserName));
            if (!isFound) //ko có username trùng
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return View("Index"); //trở về trang index nếu đki thành công
            }
            //nếu trùng tk tồn tại trong DB
            return View();//ở lại trang signUp
        }

        [HttpPost] //hàm code dưới phương thức này sẽ thực thi nhiệm vụ tương tự
        //muốn truyền dữ liệu từ View => controller: cần bind text từ bên views sang
        public IActionResult Login([Bind("UserName,Password")] User user)
        {
            //kiểm tra xem có user nào trùng trong DB ko
            bool isFound = _dbContext.Users.Any(x => x.UserName.Equals(user.UserName));
            if (!isFound) //ko có username trùng
            {
                return View();//ở lại trang Login
                
            }
            return View("Index"); //trở về trang index nếu đki thành công

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}