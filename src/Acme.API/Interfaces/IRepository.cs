namespace Acme.API.Interfaces
{
    public interface IRepository<T> : IGetAll<T>
    {
        T Get(int id);
        int Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}