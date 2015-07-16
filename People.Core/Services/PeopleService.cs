using System;
using System.Collections.Generic;
using People.Core.Interfaces;
using People.Core.Objects;

namespace People.Core.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public Person GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPeople()
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPeopleByPostcode(string postcode)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPeopleBySurname(string surname)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPeopleByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPeopleByMobile(string mobile)
        {
            throw new NotImplementedException();
        }

        public bool CreatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(int id, Person person)
        {
            throw new NotImplementedException();
        }

        public bool DeletePerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}
