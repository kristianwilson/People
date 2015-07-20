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

        public Person GetPersonById(Guid id)
        {
            return _peopleRepository.GetById(id);
        }

        public PersonWithHistory GetPersonWithHistoryById(Guid id)
        {
            return _peopleRepository.GetWithAllHistoricsById(id);
        }

        public List<Person> GetPeople()
        {
            return _peopleRepository.Get();
        }

        public List<Person> GetPeopleByPostcode(string postcode)
        {
            return _peopleRepository.GetByPostcode(postcode);
        }

        public List<Person> GetPeopleBySurname(string surname)
        {
            return _peopleRepository.GetBySurname(surname);
        }

        public List<Person> GetPeopleByEmail(string email)
        {
            return _peopleRepository.GetByEmail(email);
        }

        public List<Person> GetPeopleByMobile(string mobile)
        {
            return _peopleRepository.GetByMobile(mobile);
        }

        public bool CreatePerson(Person person)
        {
            return _peopleRepository.Create(person);
        }

        public bool UpdatePerson(Guid id, Person person)
        {
            return _peopleRepository.Update(id, person);
        }

        public bool DeletePerson(Guid id)
        {
            return _peopleRepository.Delete(id);
        }

        public bool BlacklistPerson(Guid id)
        {
            return _peopleRepository.Blacklist(id);
        }
    }
}
