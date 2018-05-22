using System.Data.Entity;
using System.Reflection;

namespace EntityFramework.Ententions.SoftDelte
{
    public static class DbSetContextExtesntions
    {
        public static void Delete<TEntity>(this DbSet<TEntity> set, TEntity entity) where TEntity : class
        {
            PropertyInfo isDeltedField = entity.GetType().GetProperty("IsDeleted");

            if (isDeltedField != null)
                isDeltedField.SetValue(entity, true);
            else
                set.Remove(entity);
        }
    }
}
