using System.Collections.Generic;

using EntityFramework.Extentions.SoftDelete.Poc.Models;

namespace EntityFramework.Extentions.SoftDelete.Poc.Interface
{
    public interface ITransactionService
    {
        bool Update(string name, bool isDelete);

        bool Create(List<PersonDto> persons);

        PersonDto Get(string personName);

        PersonDto GetIncludeSoftDelete(string personName);
    }
}
