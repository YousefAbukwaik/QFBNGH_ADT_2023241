using System.Linq;

namespace QFBNGH_ADT_2023241.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T obj);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T obj);
        void Delete(int id);
    }
}