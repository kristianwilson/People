using System;
using System.Collections.Generic;
using People.Core.Objects;

namespace People.Core.Interfaces
{
    public interface IPeopleService
    {
        Person GetPersonById(Guid id);
        PersonWithHistory GetPersonWithHistoryById(Guid id);

        List<Person> GetPeople();
        List<Person> GetPeopleByPostcode(string postcode);
        List<Person> GetPeopleBySurname(string surname);
        List<Person> GetPeopleByEmail(string email);
        List<Person> GetPeopleByMobile(string mobile);
        
        bool CreatePerson(Person person);
        bool UpdatePerson(Guid id, Person person);
        bool DeletePerson(Guid id);
        
        bool BlacklistPerson(Guid id);
    }
}
