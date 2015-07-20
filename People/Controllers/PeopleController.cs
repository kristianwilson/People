using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using People.Core.Interfaces;
using People.Models;

namespace People.Controllers
{
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {
        private readonly IPeopleService _peopleService;
        private readonly IMapToNew<Core.Objects.Person, Person> _personModelMapper;
        private readonly IMapToNew<Core.Objects.PersonWithHistory, PersonWithHistory> _fullPersonModelMapper;
        private readonly IMapToNew<Person, Core.Objects.Person> _personMapper;

        public PeopleController(IPeopleService peopleService, 
                                IMapToNew<Core.Objects.Person, Person> mapper,
                                IMapToNew<Core.Objects.PersonWithHistory, PersonWithHistory> fullPersonMapper, 
                                IMapToNew<Person, Core.Objects.Person> personMapper)
        {
            _peopleService = peopleService;
            _personModelMapper = mapper;
            _fullPersonModelMapper = fullPersonMapper;
            _personMapper = personMapper;
        }

        [HttpGet, Route("")]
        public List<Person> GetPeople()
        {
            return _peopleService.GetPeople().Select(x => _personModelMapper.Map(x)).ToList();
        }

        [HttpGet, Route("{id:guid}")]
        public Person GetPerson(Guid id)
        {
            return _personModelMapper.Map(_peopleService.GetPersonById(id));
        }

        [HttpGet, Route("{id:guid}/details")]
        public PersonWithHistory GetPersonDetail(Guid id)
        {
            return _fullPersonModelMapper.Map(_peopleService.GetPersonWithHistoryById(id));
        }

        [HttpPost, Route("{id:guid}/blacklist")]
        public HttpResponseMessage BlackListPerson(Guid id)
        {
            var result = _peopleService.BlacklistPerson(id);

            return result
                ? new HttpResponseMessage {StatusCode = HttpStatusCode.OK}
                : new HttpResponseMessage {StatusCode = HttpStatusCode.InternalServerError};
        }

        [HttpGet, Route("postcode/{postcode}")]
        public List<Person> GetPeopleByPostcode(string postcode)
        {
            return _peopleService.GetPeopleByPostcode(postcode).Select(x => _personModelMapper.Map(x)).ToList();
        }

        [HttpGet, Route("surname/{surname}")]
        public List<Person> GetPeopleBySurname(string surname)
        {
            return _peopleService.GetPeopleBySurname(surname).Select(x => _personModelMapper.Map(x)).ToList();
        }

        [HttpGet, Route("email/{email}")]
        public List<Person> GetPeopleByEmailAddress(string email)
        {
            return _peopleService.GetPeopleByEmail(email).Select(x => _personModelMapper.Map(x)).ToList();
        }

        [HttpGet, Route("mobile/{mobile}")]
        public List<Person> GetPeopleByMobile(string mobile)
        {
            return _peopleService.GetPeopleByMobile(mobile).Select(x => _personModelMapper.Map(x)).ToList();
        }

        [HttpPost]
        public HttpResponseMessage Post(Person person)
        {
            var result = _peopleService.CreatePerson(_personMapper.Map(person));

            return result
                ? new HttpResponseMessage {StatusCode = HttpStatusCode.Created}
                : new HttpResponseMessage {StatusCode = HttpStatusCode.InternalServerError};
        }

        [HttpPut]
        public HttpResponseMessage Put(Guid id, Person person)
        {
            var result = _peopleService.UpdatePerson(id, _personMapper.Map(person));

            return result
                ? new HttpResponseMessage {StatusCode = HttpStatusCode.OK}
                : new HttpResponseMessage {StatusCode = HttpStatusCode.InternalServerError};
        }

        [HttpDelete, Route("{id:int}")]
        public HttpResponseMessage Delete(Guid id)
        {
            var result = _peopleService.DeletePerson(id);

            return result
                ? new HttpResponseMessage {StatusCode = HttpStatusCode.NoContent}
                : new HttpResponseMessage {StatusCode = HttpStatusCode.NotImplemented};
        }
    }
}
