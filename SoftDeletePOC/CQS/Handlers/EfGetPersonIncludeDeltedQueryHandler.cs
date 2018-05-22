using System.Linq;

using EntityFramework.DynamicFilters;
using EntityFramework.Ententions.SoftDelte.Poc.CQS.Commands;
using EntityFramework.Ententions.SoftDelte.Poc.DataContext;
using EntityFramework.Ententions.SoftDelte.Poc.Interface;
using EntityFramework.Ententions.SoftDelte.Poc.Models;

namespace EntityFramework.Ententions.SoftDelte.Poc.CQS.Handlers
{
    public class EfGetPersonIncludeDeltedQueryHandler : IQueryHandler<GetPersonWithDeletedQuery, PersonDto>
    {
        public TestDataContext Context { get; }

        public EfGetPersonIncludeDeltedQueryHandler(TestDataContext context)
        {
            Context = context;
        }

        public PersonDto Handle(GetPersonWithDeletedQuery query)
        {
            // Disable the filter to include the deleted rows in Get query.

            Context.DisableFilter("IsDelete");

            var person = Context.Persons.FirstOrDefault(p => p.Name == query.Name);

            if (person == null)
            {
                return null;
            }

            //Enable the filter again
            Context.EnableFilter("IsDelete");

            return new PersonDto()
            {
                Name = person.Name,
                Id = person.Id,
                IsDeleted = person.IsDeleted
            };
        }
    }
}
