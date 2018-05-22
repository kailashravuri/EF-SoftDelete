using System;
using System.Data.Common;
using System.Data.Entity;

using EntityFramework.DynamicFilters;
using EntityFramework.Ententions.SoftDelte.Poc.DataContext.Entities;

using StructureMap;

namespace EntityFramework.Ententions.SoftDelte.Poc.DataContext
{
    public class TestDataContext : DbContext
    {
        [DefaultConstructor]
        public TestDataContext():base("TestDataContext")
        {

        }

        public TestDataContext(DbConnection connection) : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Adding Filter in model build steps to exclude the IsDeleted rows
            modelBuilder.Filter("IsDeleted", (ISoftDelte d) => d.IsDeleted, false);

            //modelBuilder.Filter("IsDelete", (Person d) => d.IsDeleted, false);
        }
    }

    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            try
            {
                dbSet.RemoveRange(dbSet);
            }
            catch (Exception)
            {
                // Swallow the exception do nothing.
            }
        }
    }
}
