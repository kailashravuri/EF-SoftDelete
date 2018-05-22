using System.Linq;

using EntityFramework.Ententions.SoftDelte.Poc.CQS.Commands;
using EntityFramework.Ententions.SoftDelte.Poc.DataContext;
using EntityFramework.Ententions.SoftDelte.Poc.Interface;
using EntityFramework.Ententions.SoftDelte.Poc.Models;

namespace EntityFramework.Ententions.SoftDelte.Poc.CQS.Handlers
{
    public class EfGetPersonQueryHandler : IQueryHandler<GetPersonQuery, PersonDto>
    {
        public TestDataContext Context { get; }

        public EfGetPersonQueryHandler(TestDataContext context)
        {
            Context = context;
        }

        public PersonDto Handle(GetPersonQuery query)
        {
            var person = Context.Persons.FirstOrDefault(p => p.Name == query.Name);

            if (person == null)
            {
                return null;
            }

            return new PersonDto()
            {
                Name = person.Name,
                Id = person.Id,
                IsDeleted = person.IsDeleted
            };
        }
    }
}
