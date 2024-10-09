using StudentSystem.Models;

namespace StudentSystem.Repository
{
    public interface IRepository<T>
    {
        public void Add(T std);
        public List<T> GetAll();
        public void Update(T std);
        public void Delete(T std);
        public T? GetByID(int id);
        public void Save();

    }
}
