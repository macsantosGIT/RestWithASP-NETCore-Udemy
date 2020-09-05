using RestWithASPNETCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETCore.Repository.Generic
{
    public interface IPersonRepository : IPersonRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}
