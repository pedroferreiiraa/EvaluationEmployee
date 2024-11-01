using _5W2H.Core.Entities;

namespace _5W2H.Application.Models;

public class UpdateUserViewModel
{
    public UpdateUserViewModel(User user)
    {
        FullName = user.FullName;
        Role = user.Role;
        TypeMo = user.TypeMo;
        
        DepartmentId = user.DepartmentId;
        
    }

   
    public string FullName { get;  set; }
    public string Role { get; set; }
    public string TypeMo { get; set;  }
    public int? DepartmentId { get; set; }
    
}