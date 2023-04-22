namespace RentAPI.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity data);
        void Update(TEntity data);
        void Delete(int id);
        void Save();
        
    }
}
