using _5W2H.Core.Entities;

namespace _5W2H.Application.Models;

public class UserViewModel
{
    public UserViewModel(User user)
    {
        Id = user.Id;
        FullName = user.FullName;
        Email = user.Email;
        Role = user.Role;
        TypeMo = user.TypeMo;
        CodFuncionario = user.CodFuncionario;
        DepartmentId = user.DepartmentId;
        IsDeleted = user.IsDeleted;
    }

    public int Id { get; set; }
    public string FullName { get;  set; }
    public string Email { get;  set; }
    public string Role { get; set; }
    public string TypeMo { get; set;  }
    public int CodFuncionario { get; set; }
    public int? DepartmentId { get; set; }
    public bool IsDeleted { get; set; }
    
    
}