using _5W2H.Core.Entities;

namespace _5W2H.Application.Models;

public class SetorViewModel
{
    public SetorViewModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    
    public static SetorViewModel FromEntity(Department entity)
        => new(entity.Id, entity.Nome);
}