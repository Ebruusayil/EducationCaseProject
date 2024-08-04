namespace Dto
{
    public class UpdateProfileDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsInstructor { get; set; }
        public string? CurrentPassword { get; set; } 
        public string? NewPassword { get; set; } 
        public string? ConfirmNewPassword { get; set; }
        public List<EducationDto>? Educations { get; set; }
    }
}