using System.Data.Entity;

using EntityFramework.Extentions.SoftDelete.Poc.CQS.Commands;
using EntityFramework.Extentions.SoftDelete.Poc.CQS.Handlers;
using EntityFramework.Extentions.SoftDelete.Poc.DataContext;
using EntityFramework.Extentions.SoftDelete.Poc.Interface;
using EntityFramework.Extentions.SoftDelete.Poc.Models;
using EntityFramework.Extentions.SoftDelete.Poc.Services;

using log4net;

using StructureMap;

namespace EntityFramework.Extentions.SoftDelete.Poc.StructureMap
{
    public class TestHarnessRegistry : Registry
    {
        public TestHarnessRegistry()
        {
            DoScan();

            For<ILog>()
                .Use(logger => LogManager.GetLogger(logger.ParentType ?? typeof(ILog)))
                .AlwaysUnique();

            DatabaseRegistries();

            CommandHandlerRegistries();

            For<ITransactionService>()
                .Use<TransactionsService>();
        }

        private void DoScan()
        {
            Scan(scanner =>
            {
                scanner.Assembly("EntityFramework.Extentions.SoftDelete.Poc");

                scanner.SingleImplementationsOfInterface();

                scanner.LookForRegistries();
            });
        }

        private void CommandHandlerRegistries()
        {
            For<ICommandHandler<ModifyPersonCommand>>()
                .Use<EfModifyPersonCommandHandler>();

            For<ICommandHandler<AddPersonCommand>>()
                .Use<EfAddPersonCommandHandler>();

            For<IQueryHandler<GetPersonQuery, PersonDto>>()
                .Use<EfGetPersonQueryHandler>();

            For<IQueryHandler<GetPersonWithDeletedQuery , PersonDto>>()
                .Use<EfGetPersonIncludeDeltedQueryHandler>();
        }

        private void DatabaseRegistries()
        {
            For<DbContext>()
                .Use<TestDataContext>();
        }
    }
}
