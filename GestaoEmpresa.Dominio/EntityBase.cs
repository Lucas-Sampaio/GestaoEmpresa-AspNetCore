namespace GestaoEmpresa.Dominio
{
    public class EntityBase
    {
        public int Id { get; set; }
        #region Comparacoes
        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityBase;
            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(this, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }
        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 97 + Id.GetHashCode();
        }
        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }
        public static bool operator !=(EntityBase a, EntityBase b)
        {
            return !(a == b);
        }
        #endregion
    }
}
