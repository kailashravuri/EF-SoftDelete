using System.Threading.Tasks;

using EntityFramework.Extentions.SoftDelete.Poc.CQS.Commands;
using EntityFramework.Extentions.SoftDelete.Poc.DataContext;
using EntityFramework.Extentions.SoftDelete.Poc.DataContext.Entities;
using EntityFramework.Extentions.SoftDelete.Poc.Interface;

namespace EntityFramework.Extentions.SoftDelete.Poc.CQS.Handlers
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
