using System;

namespace Rafaela.DDD
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; }
        
        public Entity(TId id)
        {            
            if (Object.Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the default value.", nameof(id));
            }
            Id = id;
        }        

        public override bool Equals(object other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            var otherEntity = other as Entity<TId>;

            return Equals(otherEntity);
        }

        
        public override int GetHashCode()
        {
            unchecked
            {
                return this.Id.GetHashCode();
            }
        }

        public bool Equals(Entity<TId> other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }
    }
}
