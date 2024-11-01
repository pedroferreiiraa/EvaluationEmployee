using System.ComponentModel.DataAnnotations.Schema;

namespace _5W2H.Core.Entities
{
    public class Department : BaseEntity
    {
        public Department() { }
        public Department(string name, int liderId, int gestorId)
        {
            Name = name;
            LiderId = liderId;
            GestorId = gestorId;
            Users = new List<User>();
        }

        public string Name { get; private set; }
        public int LiderId { get; private set; }
        public User Lider { get;  set; }
        public int GestorId { get; private set; }
        public User Gestor { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
