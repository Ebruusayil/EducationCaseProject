using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Entities.Concrete;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dto;
using DataAccess.Concrete;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly EducationPortalDbContext _context;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, EducationPortalDbContext context, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _context = context;
        _signInManager = signInManager;
    }

    [HttpGet]
    public async Task<IActionResult> UpdateProfile()
    {
        var userId = _userManager.GetUserId(User);
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(userId)  );

        if (user == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var dto = new UpdateProfileDto
        {
            FullName = user.FullName,
            Email = user.Email,
            // Initialize other properties if needed
        };

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProfile(UpdateProfileDto dto)
    {
        if (ModelState.IsValid)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));

            if (user != null)
            {
                user.FullName = dto.FullName;
                user.Email = dto.Email;

                if (!string.IsNullOrEmpty(dto.CurrentPassword) && !string.IsNullOrEmpty(dto.NewPassword))
                {
                    if (dto.NewPassword != dto.ConfirmNewPassword)
                    {
                        ModelState.AddModelError("", "Yeni şifre ve onay şifresi uyuşmuyor.");
                        return View(dto);
                    }

                    var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(dto);
                    }
                }

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    // Log exception (ex) here
                    ModelState.AddModelError("", "Güncelleme işlemi sırasında bir hata oluştu.");
                    return View(dto);
                }

                return RedirectToAction("UpdateProfile");
            }
        }

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Login");
    }

    public IActionResult ProfileUpdated()
    {
        return View();
    }
}
