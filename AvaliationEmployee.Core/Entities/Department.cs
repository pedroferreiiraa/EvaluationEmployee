using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities
{
    public class Department : BaseEntity
    {
        public Department(string nome, int liderId,  int gestorId)
        {
            Nome = nome;
            LiderId = liderId;
            GestorId = gestorId;
           
            Users = new List<User>();
        }

        public Department(string nome, int liderId, User gestorId, int i, User gestor)
        {
            throw new NotImplementedException();
        }


        public string Nome { get; set; }
        public int LiderId { get; set; }
        public User Lider { get; set; } // O líder é um colaborador
        public int GestorId { get; set; }
        public User Gestor { get; set; } // O gestor também é um colaborador
        public ICollection<User> Users { get; set; }
    }
}