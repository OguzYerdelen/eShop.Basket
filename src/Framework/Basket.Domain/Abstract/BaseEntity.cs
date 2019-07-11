namespace Basket.Domain.Abstract
{
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        public virtual T Id { get ; set; }
        
    }
}
