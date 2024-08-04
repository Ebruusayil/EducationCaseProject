using Dto;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;

namespace Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly EducationPortalDbContext _context;

        public RegisterController(UserManager<User> userManager, RoleManager<Role> roleManager, EducationPortalDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.InstructorTypes = new SelectList(_context.InstructorTypes.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                User appUser = new User()
                {
                    UserName = appUserRegisterDto.Email,
                    FullName = appUserRegisterDto.FullName,
                    Email = appUserRegisterDto.Email,
                };

                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

                if (result.Succeeded)
                {
                    var selectedRole = appUserRegisterDto.Role;

                    if (!await _roleManager.RoleExistsAsync(selectedRole))
                    {
                        await _roleManager.CreateAsync(new Role { Name = selectedRole });
                    }

                    await _userManager.AddToRoleAsync(appUser, selectedRole);

                    if (selectedRole == "Student")
                    {
                        Student student = new Student()
                        {
                            FullName = appUserRegisterDto.FullName,
                            UserId = appUser.Id,
                            IsActive = true,
                            IsDeleted = false,
                            CreationTime = DateTime.Now
                        };
                        _context.Students.Add(student);
                    }
                    else if (selectedRole == "Teacher")
                    {
                        Instructor instructor = new Instructor()
                        {
                            FullName = appUserRegisterDto.FullName,
                            UserId = appUser.Id,
                            InstructorTypeId= 1,
                            IsActive = true,
                            IsDeleted = false,
                            CreationTime = DateTime.Now
                        };
                        _context.Instructors.Add(instructor);
                    }

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            ViewBag.InstructorTypes = new SelectList(_context.InstructorTypes.ToList(), "Id", "Name");
            return View(appUserRegisterDto);
        }
    }
}
