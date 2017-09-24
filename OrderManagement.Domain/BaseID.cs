using System.Collections.Generic;

namespace OrderManagement.Domain
{

    public interface IBaseID<T>
    {
        T ID { get; set; }
    }

    public class BaseID<T> : IBaseID<T>
    {

        public T ID { get; set; }
        public BaseID(T id)
        {
            ID = id;
        }
        protected bool Equals(BaseID<T> other)
        {
            return EqualityComparer<T>.Default.Equals(ID, other.ID);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((BaseID<T>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(ID);
        }


        public static bool operator ==(BaseID<T> a, BaseID<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(BaseID<T> a, BaseID<T> b)
        {
            return !(a == b);
        }
    }
}