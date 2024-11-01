using System.ComponentModel.DataAnnotations.Schema;

namespace _5W2H.Core.Entities
{
    public class Department : BaseEntity
    {
        public Department() { }
        public Department(string nome)
        {
            Nome = nome;
            Users = new List<User>();
        }

        public string Nome { get; set; }
        public int? LiderId { get; set; }
        public User? Lider { get; set; }

        public int? GestorId { get; set; }

        [ForeignKey("GestorId")]
        public User? Gestor { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
