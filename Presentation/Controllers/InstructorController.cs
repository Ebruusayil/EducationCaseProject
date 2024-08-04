using Business.Abstract;
using Dto;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Controllers
{
[Authorize(Roles = "Admin")]  
    public class InstructorController : Controller
    {
        private readonly IInstructorTypeService _instructorTypeService;
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorTypeService instructorTypeService, IInstructorService instructorService)
        {
            _instructorTypeService = instructorTypeService;
            _instructorService = instructorService;
        }

      
        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.InstructorTypes = new SelectList(_instructorTypeService.TGetList(), "Id", "Name");
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(InstructorDto instructorDto)
        {
            if (ModelState.IsValid)
            {
                var instructor = new Instructor
                {
                    FullName= instructorDto.FullName,
                    UserId = instructorDto.UserId,
                    InstructorTypeId = instructorDto.InstructorTypeId 
                };

                _instructorService.TInsert(instructor);

                TempData["SuccessMessage"] = "Instructor successfully created!";
                return RedirectToAction("Create");
            }

           
            ViewBag.InstructorTypes = new SelectList(_instructorTypeService.TGetList(), "Id", "Name");
            return View(instructorDto);
        }
    }
}
