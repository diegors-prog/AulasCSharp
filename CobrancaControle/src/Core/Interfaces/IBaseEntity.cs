namespace Core.Interfaces
{
    public interface IBaseEntity
    {
         public long Id { get; set; }

         public abstract void IsValid();
    }
}