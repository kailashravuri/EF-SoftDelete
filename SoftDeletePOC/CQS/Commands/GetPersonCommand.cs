using EntityFramework.Ententions.SoftDelte.Poc.Interface;
using EntityFramework.Ententions.SoftDelte.Poc.Models;

namespace EntityFramework.Ententions.SoftDelte.Poc.CQS.Commands
{
    public class GetPersonQuery : IQuery<PersonDto>
    {
        public string Name { get; }

        public GetPersonQuery(string name)
        {
            Name = name;
        }
    }
}
