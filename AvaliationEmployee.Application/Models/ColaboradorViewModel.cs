using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models;

public class ColaboradorViewModel
{
    public ColaboradorViewModel(User user)
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