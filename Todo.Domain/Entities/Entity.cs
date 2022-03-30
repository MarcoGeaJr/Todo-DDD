using System;

namespace Todo.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public bool IsActive { get; private set; } = true;

        public void Disable()
        {
            IsActive = false;
        }
        public void Enable()
        {
            IsActive = true;
        }

        public bool Equals(Entity? other)
        {
            return other?.Id == Id;
        }
    }
}
