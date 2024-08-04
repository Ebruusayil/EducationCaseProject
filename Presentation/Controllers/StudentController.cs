using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Entities.Concrete;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dto;
using DataAccess.Concrete;

public class StudentController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly EducationPortalDbContext _context;

    public StudentController(UserManager<User> userManager, EducationPortalDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [HttpGet]
    public IActionResult AvailableEducations()
    {
        var userId = _userManager.GetUserId(User);
        var student = _context.Students
            .Include(s => s.Educations)
            .FirstOrDefault(s => s.UserId == int.Parse(userId));

        if (student == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var availableEducations = _context.Educations
            .Include(e => e.Category)        
            .Include(e => e.Instructor)       
            .Where(e => e.IsActive && !e.IsDeleted && !student.Educations.Contains(e))
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

    [HttpPost]
    public IActionResult RegisterForEducation(int educationId)
    {
        var userId = _userManager.GetUserId(User);
        var student = _context.Students
            .Include(s => s.Educations)
            .FirstOrDefault(s => s.UserId == int.Parse(userId));

        if (student == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var education = _context.Educations
            .Include(e => e.Category)          
            .Include(e => e.Instructor)        
            .FirstOrDefault(e => e.Id == educationId);

        if (education == null || !education.IsActive || education.IsDeleted)
        {
            return NotFound();
        }

        student.Educations.Add(education);
        _context.SaveChanges();

        return RedirectToAction("AvailableEducations");
    }

    [HttpGet]
    public IActionResult MyEnrollments()
    {
        var userId = _userManager.GetUserId(User);
        var student = _context.Students
            .Include(s => s.Educations)
            .ThenInclude(e => e.Category)     
            .Include(s => s.Educations)
            .ThenInclude(e => e.Instructor)   
            .FirstOrDefault(s => s.UserId == int.Parse(userId));

        if (student == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var enrolledEducations = student.Educations.Select(e => new EducationDto
        {
            Id = e.Id,
            Name = e.Name,
            Quota = e.Quota,
            Price = e.Price,
            Duration = e.Duration,
            CategoryFullName = e.Category.Name,
            InstructorFullName = e.Instructor.FullName
        }).ToList();

        return View(enrolledEducations);
    }

    [HttpPost]
    public IActionResult UnregisterFromEducation(int educationId)
    {
        var userId = _userManager.GetUserId(User);
        var student = _context.Students
            .Include(s => s.Educations)
            .FirstOrDefault(s => s.UserId == int.Parse(userId));

        if (student == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var education = student.Educations.FirstOrDefault(e => e.Id == educationId);

        if (education == null)
        {
            return NotFound();
        }

        student.Educations.Remove(education);
        _context.SaveChanges();

        return RedirectToAction("MyEnrollments");
    }
}
