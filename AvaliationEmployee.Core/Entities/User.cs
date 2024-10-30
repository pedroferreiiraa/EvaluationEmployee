namespace _5W2H.Core.Entities
{
    public class User : BaseEntity
    {
        
        public User() { }
        
        public User(string fullName, string email, string password, string role, int departmentId, int codFuncionario, string typeMo)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
        
            DepartmentId = departmentId;
            CodFuncionario = codFuncionario;
            TypeMo = typeMo;

        }
        
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public string TypeMo { get; private set; }
        public int CodFuncionario { get; private set; }
        public Department Department { get; private set; } 
        public int? DepartmentId { get; private set; }
        

        public void Update(string fullName, string email, Department department)
        {
            FullName = fullName;
            Email = email;
            Department = department; 
        }
    }
}