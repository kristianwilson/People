using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.UI.WebControls;
using People.Core.Interfaces;
using People.Models;

namespace People.Controllers
{
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet, Route("")]
        public List<Person> GetPeople()
        {
            return _peopleService.GetPeople().Select(x => new Person
            {

            }).ToList();
        }

        [HttpGet, Route("{id:int}")]
        public Person GetPerson(int id)
        {
            return new Person();
        }

        [HttpGet, Route("{id:int}/details")]
        public FullPerson GetPersonDetail(int id)
        {
            return new FullPerson();
        }

        [HttpGet, Route("postcode/{postcode}")]
        public List<Person> GetPeopleByPostcode(string postcode)
        {
            return _peopleService.GetPeopleByPostcode(postcode).Select(x => new Person
            {

            }).ToList();
        }

        [HttpGet, Route("surname/{surname}")]
        public List<Person> GetPeopleBySurname(string surname)
        {
            return _peopleService.GetPeopleBySurname(surname).Select(x => new Person
            {

            }).ToList();
        }

        [HttpGet, Route("email/{email}")]
        public List<Person> GetPeopleByEmailAddress(string email)
        {
            return _peopleService.GetPeopleByEmail(email).Select(x => new Person
            {

            }).ToList();
        }

        [HttpGet, Route("mobile/{mobile}")]
        public List<Person> GetPeopleByMobile(string mobile)
        {
            return _peopleService.GetPeopleByMobile(mobile).Select(x => new Person
            {

            }).ToList();
        }

        [HttpPost]
        public HttpResponseMessage Post(Person person)
        {
            var result = _peopleService.CreatePerson();

            return result ? new HttpResponseMessage {StatusCode = HttpStatusCode.Created} : new HttpResponseMessage {StatusCode = HttpStatusCode.InternalServerError};
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Person person)
        {
            var result = _peopleService.UpdatePerson(id, person);

            return result ? new HttpResponseMessage {StatusCode = HttpStatusCode.OK} : new HttpResponseMessage {StatusCode = HttpStatusCode.InternalServerError};
        }

        [HttpDelete, Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = _peopleService.DeletePerson(id);

            return result ? new HttpResponseMessage {StatusCode = HttpStatusCode.NoContent} : new HttpResponseMessage {StatusCode = HttpStatusCode.NotImplemented};
        }
    }
}
