using System;

namespace EntityFramework.Ententions.SoftDelte.Poc.Models
{
    public class PersonDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
