using EntityFramework.Ententions.SoftDelte.Poc.Interface;
using EntityFramework.Ententions.SoftDelte.Poc.Models;

namespace EntityFramework.Ententions.SoftDelte.Poc.CQS.Commands
{
    public class GetPersonWithDeletedQuery : IQuery<PersonDto>
    {
        public string Name { get; }

        public GetPersonWithDeletedQuery(string name)
        {
            Name = name;
        }
    }
}
