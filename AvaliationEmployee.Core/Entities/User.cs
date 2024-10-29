using System.Collections.Generic;
using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities
{
    public class User : BaseEntity
    {
        
        public User() { }
        
        public User(string fullName, string email, string password, string role, Department department, int setorId, int codFuncionario, string typeMo)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
        
            Department = department;
            SetorId = setorId;
            CodFuncionario = codFuncionario;
            TypeMo = typeMo;

        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public string TypeMo { get; private set; }
        public int CodFuncionario { get; private set; }
        public Department Department { get; set; } 
        public int SetorId { get; set; }
        

        public void Update(string requestFullName, string fullName, string email, Department department)
        {
            FullName = fullName;
            Email = email;
            Department = department; 
        }
    }
}