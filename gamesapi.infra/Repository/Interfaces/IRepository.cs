using System.Linq.Expressions;

namespace GamesApi.Infra.Repository.Interfaces
{
    public interface IRepository<T> where T : ModelBase
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindAll(Expression<Func<T, bool>> clausula);
        void Delete(int id);
        //void Save();
        void Create(T entity);
        void CreateMore(List<T> entity);
        void Update(T entity);

    }
}
