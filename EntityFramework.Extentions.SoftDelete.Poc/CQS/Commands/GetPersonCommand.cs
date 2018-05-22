using EntityFramework.Extentions.SoftDelete.Poc.Interface;
using EntityFramework.Extentions.SoftDelete.Poc.Models;

namespace EntityFramework.Extentions.SoftDelete.Poc.CQS.Commands
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
