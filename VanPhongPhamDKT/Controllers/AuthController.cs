using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using VanPhongPhamDKT.Models;

public class AuthController : Controller
{
    private readonly VanPhongPhamContext _context;
    public AuthController(VanPhongPhamContext context)
    {
        _context = context;
    }

    // GET: /Auth/DangNhap
    public IActionResult DangNhap()
    {
        return View();
    }

    // POST: /Auth/DangNhap
    [HttpPost]
    public async Task<IActionResult> DangNhap(string email, string matKhau)
    {
        var user = _context.KhachHangs
            .FirstOrDefault(x => x.Email == email && x.MatKhau == matKhau);

        if (user == null)
        {
            ViewBag.Error = "Email hoặc mật khẩu không đúng!";
            return View();
        }

        // Tạo claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.HoTen),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.ChucVu ?? "khachhang")  // lấy từ cột ChucVu
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        // Điều hướng theo ChucVu
        if (user.ChucVu != null && user.ChucVu.ToLower() == "admin")
        {
            return RedirectToAction("Index", "Dashboard", new { area = "admins" });
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }

    // Đăng xuất
    public async Task<IActionResult> DangXuat()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("DangNhap");
    }

    public IActionResult KhongDuQuyen()
    {
        // Có thể truyền thêm ViewBag.Message nếu muốn
        return View();
    }
}
