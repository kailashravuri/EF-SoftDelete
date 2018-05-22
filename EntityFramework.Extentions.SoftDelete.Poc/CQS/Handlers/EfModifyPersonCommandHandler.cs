using System;
using System.Linq;
using System.Threading.Tasks;

using EntityFramework.Ententions.SoftDelte;
using EntityFramework.Extentions.SoftDelete.Poc.CQS.Commands;
using EntityFramework.Extentions.SoftDelete.Poc.DataContext;
using EntityFramework.Extentions.SoftDelete.Poc.DataContext.Entities;
using EntityFramework.Extentions.SoftDelete.Poc.Interface;

namespace EntityFramework.Extentions.SoftDelete.Poc.CQS.Handlers
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
            Context.Persons.Delete(person);
            //Context.Persons.SoftDelete(person);
            changes = Context.ChangeTracker.Entries();
            await Context.SaveChangesAsync();
        }

    }
}
