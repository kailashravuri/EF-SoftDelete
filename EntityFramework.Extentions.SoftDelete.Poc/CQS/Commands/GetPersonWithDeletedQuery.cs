using EntityFramework.Extentions.SoftDelete.Poc.Interface;
using EntityFramework.Extentions.SoftDelete.Poc.Models;

namespace EntityFramework.Extentions.SoftDelete.Poc.CQS.Commands
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
