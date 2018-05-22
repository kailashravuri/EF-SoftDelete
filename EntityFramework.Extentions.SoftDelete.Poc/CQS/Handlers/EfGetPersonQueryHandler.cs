using System.Linq;

using EntityFramework.Extentions.SoftDelete.Poc.CQS.Commands;
using EntityFramework.Extentions.SoftDelete.Poc.DataContext;
using EntityFramework.Extentions.SoftDelete.Poc.Interface;
using EntityFramework.Extentions.SoftDelete.Poc.Models;

namespace EntityFramework.Extentions.SoftDelete.Poc.CQS.Handlers
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
