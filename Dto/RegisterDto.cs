﻿namespace Dto;

public class RegisterDto
{
    public string FullName { get; set; }
    
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Role { get; set; }
    public int? InstructorTypeId { get; set; }
 
    
}
