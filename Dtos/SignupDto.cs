using System.ComponentModel.DataAnnotations;

public class SignupDto
{
    [Required]
    public required string FullName { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required, MinLength(6)]
    public required string Password { get; set; }
}
