using RestWithASPNETCore.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETCore.Repository.Generic
{
    public interface IPersonRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);

        bool Exist(long? id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
