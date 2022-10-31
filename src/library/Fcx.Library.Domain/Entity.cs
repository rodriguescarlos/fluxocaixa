namespace Fcx.Library.Domain
{
    public abstract class Entity
    {
        public Guid Identificador { get; set; }

        protected Entity()
        {
            Identificador = Guid.NewGuid();
        }

        #region Comparações

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Identificador.Equals(compareTo.Identificador);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Identificador.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Identificador}]";
        }

        #endregion
    }
}