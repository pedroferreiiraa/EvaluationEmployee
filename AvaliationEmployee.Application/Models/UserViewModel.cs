using _5W2H.Core.Entities;

namespace _5W2H.Application.Models;

public class UserViewModel
{
    public UserViewModel(User user)
    {
        FullName = user.FullName;
        Email = user.Email;
        Id = user.Id;
    
        IsDeleted = user.IsDeleted;
    }


    public int Id { get; set; }
    public string FullName { get;  set; }
    public string Email { get;  set; }

    public bool IsDeleted { get; set; }
    
}