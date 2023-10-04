namespace Locadora.Domain.Entities;

public class Entity : IEquatable<Entity>
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public bool Equals(Entity? other)
    {
        throw new NotImplementedException();
    }
}