using GamesApi.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace GamesApi.Infra.Repository
{
    public class EFRepositoryBase<T> : IRepository<T> where T : ModelBase
    {
        //private readonly IConfiguration _configuration;

        //protected EFRepositoryBase(IConfiguration configuration)
        //{
        //    _configuration=configuration;
        //}

        private AmiibooDbContext _context = null;
        private DbSet<T> table = null;

        protected EFRepositoryBase(AmiibooDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public void Delete(int id)
        {
            T dataRemove = table.Find(id);
            table.Remove(dataRemove);
            Save();
        }

        public IEnumerable<T> FindAll(Expression<Func<T,bool>> clausula)
        {
            return table.Where(clausula);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Create(T entity)
        {
            table.Add(entity);
            _context.Entry(entity).State = EntityState.Added;
            Save();
        }

        public void CreateMore(List<T> entity)
        {
            entity.ForEach(x =>
            {
                table.AddRange(x);
                _context.Entry(x).State = EntityState.Added;
            });
            Save();
        }
        public void Update(T entity)
        {
            table.Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        void Save()
        {
            _context.SaveChanges();
        }
    }
}
