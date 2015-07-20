using System;
using People.Core.Interfaces;
using People.Core.Objects;

namespace People.Mapping
{
    public class PersonModelMapper : IMapToNew<Person, Models.Person>
    {
        private readonly IMapToNew<Address, Models.Address> _mapper;

        public PersonModelMapper(IMapToNew<Address, Models.Address> mapper)
        {
            _mapper = mapper;
        }

        public Models.Person Map(Person source)
        {
            return new Models.Person
            {
                Firstname = source.Name.Firstname,
                Surname = source.Name.Surname,
                DateOfBirth = source.DateOfBirth.Value ?? DateTime.MinValue,
                Email = source.Email.ToString(),
                Mobile = source.Mobile.ToString(),
                Landline = source.Landline.ToString(),
                Address = _mapper.Map(source.Address),
            };
        }
    }
}