using System.Threading.Tasks;

using EntityFramework.Ententions.SoftDelte.Poc.CQS.Commands;
using EntityFramework.Ententions.SoftDelte.Poc.DataContext;
using EntityFramework.Ententions.SoftDelte.Poc.DataContext.Entities;
using EntityFramework.Ententions.SoftDelte.Poc.Interface;

namespace EntityFramework.Ententions.SoftDelte.Poc.CQS.Handlers
{
    public class EfAddPersonCommandHandler : ICommandHandler<AddPersonCommand>
    {
        public TestDataContext Context { get; }

        public EfAddPersonCommandHandler(TestDataContext context)
        {
            Context = context;
        }

        public async Task HandleAsync(AddPersonCommand person)
        {
            var newPerson = new Person()
            {
                Name = person.Name,
                ParentId = person.ParentId
            };

            Context.Persons.Add(newPerson);

            await Context.SaveChangesAsync();
        }
    }
}
