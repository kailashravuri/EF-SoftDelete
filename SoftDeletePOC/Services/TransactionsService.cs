using System;
using System.Collections.Generic;

using EntityFramework.Ententions.SoftDelte.Poc.CQS.Commands;
using EntityFramework.Ententions.SoftDelte.Poc.Interface;
using EntityFramework.Ententions.SoftDelte.Poc.Models;

using log4net;

namespace EntityFramework.Ententions.SoftDelte.Poc.Services
{
    public class TransactionsService : ITransactionService
    {
        private readonly ICommandHandler<ModifyPersonCommand> _modifyPersonCommandHandler;
        private readonly ICommandHandler<AddPersonCommand> _addPersonCommandHandler;
        private readonly IQueryHandler<GetPersonQuery, PersonDto> _getPersonQueryHandler;
        private readonly IQueryHandler<GetPersonWithDeletedQuery, PersonDto> _getPersonsIncludeingDeltedQueryHandler;
        private readonly ILog _logger;

        public TransactionsService(ICommandHandler<ModifyPersonCommand> modifyPersonCommandHandler,
            ICommandHandler<AddPersonCommand> addPersonCommandHandler,
            IQueryHandler<GetPersonQuery, PersonDto> getPersonQueryHandler,
            IQueryHandler<GetPersonWithDeletedQuery, PersonDto> getPersonsIncludeingDeltedQueryHandler, ILog logger)
        {
            _modifyPersonCommandHandler = modifyPersonCommandHandler;
            _addPersonCommandHandler = addPersonCommandHandler;
            _getPersonQueryHandler = getPersonQueryHandler;
            _getPersonsIncludeingDeltedQueryHandler = getPersonsIncludeingDeltedQueryHandler;
            _logger = logger;
        }

        public bool Update(string newName, bool isDelte)
        {
            try
            {
                _modifyPersonCommandHandler.HandleAsync(new ModifyPersonCommand(newName, isDelte)).Wait();
            }
            catch (Exception exception)
            {
                _logger.Error(exception);

                throw;
            }

            return true;
        }

        public bool Create(List<PersonDto> persons)
        {
            try
            {
                foreach (PersonDto person in persons)
                {
                    _addPersonCommandHandler.HandleAsync(new AddPersonCommand()
                    {
                        Name = person.Name,
                    }).Wait();
                }
            }
            catch (Exception exception)
            {
                _logger.Error(exception);
            }
            return true;
        }

        public PersonDto Get(string personName)
        {
            try
            {

                return _getPersonQueryHandler.Handle(new GetPersonQuery(personName));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public PersonDto GetIncludeSoftDelete(string personName)
        {
            try
            {
                return _getPersonsIncludeingDeltedQueryHandler.Handle(new GetPersonWithDeletedQuery(personName));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
