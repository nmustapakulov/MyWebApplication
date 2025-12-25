using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MyWebApplication.Models;

public class User
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Пожалуйста, введите имя.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов.")]
    [Display(Name = "Имя пользователя")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Пожалуйста, введите адрес электронной почты.")]
    [EmailAddress(ErrorMessage = "Некорректный формат адреса электронной почты.")]
    [Display(Name = "Электронная почта")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Пожалуйста, укажите дату рождения.")]
    [DataType(DataType.Date)]
    [Display(Name = "Дата рождения")]
    public DateOnly? DateOfBirth { get; set; }
    
    [ValidateNever]
    public ICollection<Phone> Phones { get; set; } = new List<Phone>();
}