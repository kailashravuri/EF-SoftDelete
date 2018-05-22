using System.Collections.Generic;

using EntityFramework.Ententions.SoftDelte.Poc.Models;

namespace EntityFramework.Ententions.SoftDelte.Poc.Interface
{
    public interface ITransactionService
    {
        bool Update(string name, bool isDelete);

        bool Create(List<PersonDto> persons);

        PersonDto Get(string personName);

        PersonDto GetIncludeSoftDelete(string personName);
    }
}
