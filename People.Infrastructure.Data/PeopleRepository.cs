using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using People.Core.Interfaces;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;
using People.Infrastucture.Data.QueryObjects;

namespace People.Infrastucture.Data
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly IDbFactory _dbFactory;

        public PeopleRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public Person GetById(Guid id)
        {
            using (var db = _dbFactory.GetDatabase())
            {
                return db.Query(new GetPersonByIdQuery(id));
            }
        }

        public PersonWithHistory GetWithAllHistoricsById(Guid id)
        {
            using (var db = _dbFactory.GetDatabase())
            {
                return db.Query(new GetPersonWithHistoricsByIdQuery(id));
            }
        }

        public List<Person> Get()
        {
            using (var db = _dbFactory.GetDatabase())
            {
                return db.Query(new GetPeopleQuery());
            }
        }

        public List<Person> GetByPostcode(string postcode)
        {
            using (var db = _dbFactory.GetDatabase())
            {
                return db.Query(new GetPeopleByPostcodeQuery(postcode));
            }
        }

        public List<Person> GetBySurname(string surname)
        {
            using (var db = _dbFactory.GetDatabase())
            {
                return db.Query(new GetPeopleBySurnameQuery(surname));
            }
        }

        public List<Person> GetByEmail(string email)
        {
            using (var db = _dbFactory.GetDatabase())
            {
                return db.Query(new GetPeopleByEmailQuery(email));
            }
        }

        public List<Person> GetByMobile(string mobile)
        {
            using (var db = _dbFactory.GetDatabase())
            {
                return db.Query(new GetPeopleByMobileQuery(mobile));
            }
        }

        public bool Create(Person person)
        {
            using (var db = _dbFactory.GetDatabase())
            using (var transaction = db.BeginTransaction())
            {
                try
                {
                    db.ExecuteWithTransaction(new CreatePersonCommand(person), transaction);
                    transaction.Commit();
                    return true;
                }
                catch (SqlException)
                {
                    transaction.Rollback();
                }
            }

            return false;
        }
        
        public bool Update(Guid id, Person person)
        {
            using (var db = _dbFactory.GetDatabase())
            using (var transaction = db.BeginTransaction())
            {
                try
                {
                    db.ExecuteWithTransaction(new UpdatePersonCommand(id, person), transaction);
                    transaction.Commit();
                    return true;
                }
                catch (SqlException)
                {
                    transaction.Rollback();
                }
            }

            return false;
        }

        public bool Delete(Guid id)
        {
            using (var db = _dbFactory.GetDatabase())
            using (var transaction = db.BeginTransaction())
            {
                try
                {
                    db.ExecuteWithTransaction(new DeletePersonCommand(id), transaction);
                    transaction.Commit();
                    return true;
                }
                catch (SqlException)
                {
                    transaction.Rollback();
                }
            }

            return false;
        }

        public bool Blacklist(Guid id)
        {
            using (var db = _dbFactory.GetDatabase())
            using (var transaction = db.BeginTransaction())
            {
                try
                {
                    db.ExecuteWithTransaction(new BlacklistPersonCommand(id), transaction);
                    transaction.Commit();
                    return true;
                }
                catch (SqlException)
                {
                    transaction.Rollback();
                }
            }

            return false;
        }
    }
}
