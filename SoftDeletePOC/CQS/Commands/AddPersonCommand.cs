using System;

namespace EntityFramework.Ententions.SoftDelte.Poc.CQS.Commands
{
    public class AddPersonCommand
    {
        public string Name { get; set; }

        public Guid? ParentId { get; set; }
    }
}
