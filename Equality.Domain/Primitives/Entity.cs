namespace Equality.Domain.Primitives
{
    public abstract class Entity<T>(Guid id) : ValueObject<T>
    {
        public Guid Id { get; private init; } = id;
    }
}
