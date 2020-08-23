using System.Collections.Generic;
using System.Linq;
using RestWithASPNETCore.Data.Converter;
using RestWithASPNETCore.Data.VO;
using RestWithASPNETCore.Model;

namespace RestWithASPNETCore.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return new Person();
            return new Person
            {
                Id = origin.Id, 
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null) return new PersonVO();
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Person> ParseList(List<PersonVO> origins)
        {
            if (origins == null) return new List<Person>();
            return origins.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> ParseList(List<Person> origins)
        {
            if (origins == null) return new List<PersonVO>();
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
