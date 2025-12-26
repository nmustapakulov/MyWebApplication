namespace MyWebApplication.Models;

public class AllContactsViewModel
{
    public IEnumerable<User> Users { get; set; } = new List<User>();
    public IEnumerable<Phone> Phones { get; set; } = new List<Phone>();
}