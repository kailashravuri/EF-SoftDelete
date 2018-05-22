using System;
using System.Linq;
using System.Threading.Tasks;

using EntityFramework.Ententions.SoftDelte.Poc.CQS.Commands;
using EntityFramework.Ententions.SoftDelte.Poc.DataContext;
using EntityFramework.Ententions.SoftDelte.Poc.DataContext.Entities;
using EntityFramework.Ententions.SoftDelte.Poc.Interface;
using EntityFramework.Ententions.SoftDelte;

namespace EntityFramework.Ententions.SoftDelte.Poc.CQS.Handlers
{
    public class EfModifyPersonCommandHandler : ICommandHandler<ModifyPersonCommand>
    {
        public TestDataContext Context { get; }

        public EfModifyPersonCommandHandler(TestDataContext context)
        {
            Context = context;
        }

        public async Task HandleAsync(ModifyPersonCommand command)
        {

            Person person = Context.Persons.FirstOrDefault(p => p.Name == command.Name);

            if (person == null)
            {
                throw new Exception("No such person.");
            }
            //person.IsDeleted = command.IsDelete;
            var changes = Context.ChangeTracker.Entries();
            Context.Persons.Remove(person);
            //Context.Persons.SoftDelete(person);
            changes = Context.ChangeTracker.Entries();
            await Context.SaveChangesAsync();
        }

    }
}
