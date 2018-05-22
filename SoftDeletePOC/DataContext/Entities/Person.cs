using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Ententions.SoftDelte.Poc.DataContext.Entities
{
    public class Person : ISoftDelte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(255)]
        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("ParentId")]
        public virtual List<Person> Children { get; set; }
    }
}
