using System;
using System.Collections.Generic;
using People.Core.Interfaces;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly IDbFactory _dbFactory;

        public PeopleRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<Person> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public Person GetPersonByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Person GetPersonByMobile(string mobileTelephoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
