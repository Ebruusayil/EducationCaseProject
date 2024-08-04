using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Kategori listeleme işlemi
        public async Task<IActionResult> Index()
        {
            var categories = _categoryService.TGetList();
            return View(categories);
        }

        // Yeni kategori ekleme işlemi
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.TInsert(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
