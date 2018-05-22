using System;

namespace EntityFramework.Extentions.SoftDelete.Poc.CQS.Commands
{
    public class AddPersonCommand
    {
        public string Name { get; set; }

        public Guid? ParentId { get; set; }
    }
}
