namespace Locadora.Domain.ValueObjects
{
    public class ValueObject : IEquatable<ValueObject>
    {
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public bool Equals(ValueObject? other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}