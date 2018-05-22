using System.Linq;

using EntityFramework.DynamicFilters;
using EntityFramework.Extentions.SoftDelete.Poc.CQS.Commands;
using EntityFramework.Extentions.SoftDelete.Poc.DataContext;
using EntityFramework.Extentions.SoftDelete.Poc.Interface;
using EntityFramework.Extentions.SoftDelete.Poc.Models;

namespace EntityFramework.Extentions.SoftDelete.Poc.CQS.Handlers
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

            Context.DisableFilter("IsDeleted");

            var person = Context.Persons.FirstOrDefault(p => p.Name == query.Name);

            if (person == null)
            {
                return null;
            }

            //Enable the filter again
            Context.EnableFilter("IsDeleted");

            return new PersonDto()
            {
                Name = person.Name,
                Id = person.Id,
                IsDeleted = person.IsDeleted
            };
        }
    }
}
