namespace _5W2H.Core.Entities
{
    public class Department : BaseEntity
    {
        
        public Department() {}
        public Department(string nome)
        {
            Nome = nome;
            
            Users = new List<User>();
        }

        public string Nome { get; set; }
        public int? LiderId { get; set; }
        public User? Lider { get; set; } // O líder é um colaborador
        public int? GestorId { get; set; }
        public User? Gestor { get; set; } // O gestor também é um colaborador
        public ICollection<User> Users { get; set; }
    }
}