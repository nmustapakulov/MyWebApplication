using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MyWebApplication.Models;

public class Phone
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Пожалуйста, введите номер телефона.")]
    [RegularExpression(@"^(\+996|0)\d{9}$",
        ErrorMessage = "Некорректный формат. Используйте +996... или 0... (всего 9 цифр после кода)")]
    [Display(Name = "Номер телефона")]
    public string? PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Необходимо указать владельца телефона.")]
    [Display(Name = "Пользователь")]
    public int? UserId { get; set; }
    
    [ValidateNever] 
    [ForeignKey("UserId")]
    public User? User { get; set; }
}