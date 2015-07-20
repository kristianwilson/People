using System;
using System.Collections.Generic;
using People.Core.Objects;

namespace People.Core.Interfaces
{
    public interface IPeopleRepository
    {
        Person GetById(Guid id);
        PersonWithHistory GetWithAllHistoricsById(Guid id);

        List<Person> Get();
        List<Person> GetByPostcode(string postcode);
        List<Person> GetBySurname(string surname);
        List<Person> GetByEmail(string email);
        List<Person> GetByMobile(string mobile);

        bool Create(Person person);
        bool Update(Guid id, Person person);
        bool Delete(Guid id);

        bool Blacklist(Guid id);
    }
}
