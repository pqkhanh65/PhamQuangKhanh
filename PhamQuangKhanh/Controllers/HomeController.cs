
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhamQuangKhanh.Models;

namespace PhamQuangKhanh.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLHangHoaContext _context;

        public HomeController(QLHangHoaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.LoaiHangs = await _context.LoaiHangs.ToListAsync();

            var hangHoas = await _context.HangHoas
                .Where(h => h.Gia >= 100)
                .ToListAsync();

            return View(hangHoas);
        }

        public async Task<IActionResult> LocHangHoa(int id)
        {
            var hangHoas = await _context.HangHoas
                .Where(h => h.MaLoai == id && h.Gia >= 100)
                .ToListAsync();

            return PartialView("PhamQuangKhanh_MainContent", hangHoas);
        }
    }
}
