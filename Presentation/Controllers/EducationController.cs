using Dto;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Teacher, Admin")]
    public class EducationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IEducationService _educationService;
        private readonly IInstructorService _instructorService; 
        private readonly EducationPortalDbContext _context;
        private readonly UserManager<User> _userManager;

        public EducationController(ICategoryService categoryService, IEducationService educationService, IInstructorService instructorService, EducationPortalDbContext context)
        {
            _categoryService = categoryService;
            _educationService = educationService;
            _instructorService = instructorService;
            _context = context;
        }




        public IActionResult Index()
        {

            var availableEducations = _context.Educations
           .Include(e => e.Category)          
           .Include(e => e.Instructor) 
           .Where(e => e.IsActive && !e.IsDeleted)
           .Select(e => new EducationDto
           {
               Id = e.Id,
               Name = e.Name,
               Quota = e.Quota,
               Price = e.Price,
               Duration = e.Duration,
               CategoryFullName = e.Category.Name,
               InstructorFullName = e.Instructor.FullName
           }).ToList();
            return View(availableEducations);
        }

      
        [HttpGet]
        public IActionResult Create()
        {
          
            ViewBag.Categories = new SelectList(_categoryService.TGetList(), "Id", "Name");
            ViewBag.InstructorTypes = new SelectList(_instructorService.TGetList(), "Id", "Name");

            return View();
        }

 
        [HttpPost]
        public IActionResult Create(EducationDto educationDto)
        {
            if (ModelState.IsValid)
            {
                var education = new Education
                {
                    Name = educationDto.Name,
                    Quota = educationDto.Quota,
                    Price = educationDto.Price,
                    Duration = educationDto.Duration,
                    CategoryId = educationDto.CategoryId
                };

                _educationService.TInsert(education);

                TempData["SuccessMessage"] = "Eğitim başarıyla tanımlandı!";
                return RedirectToAction("Create");
            }

           
            ViewBag.Categories = new SelectList(_categoryService.TGetList(), "Id", "Name");
            ViewBag.InstructorTypes = new SelectList(_instructorService.TGetList(), "Id", "Name");

            return View(educationDto);
        }
    }
}
