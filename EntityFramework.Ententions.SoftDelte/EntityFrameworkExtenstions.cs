using System.Data.Entity;

namespace EntityFramework.Ententions.SoftDelte
{
    public static class DbSetContextExtesntions
    {
        public static void Delete<TEntity>(this DbSet<TEntity> set, TEntity entity) where TEntity : class
        {
            var isDeltedField = entity.GetType().GetProperty("IsDeleted");
            isDeltedField?.SetValue(entity, true);

            //            var field = entity.GetType().GetField("_entityWrapper");
            //            var wrapper = field.GetValue(entity);
            //            var property = wrapper.GetType().GetProperty("Context");
            //            var context = (ObjectContext)property.GetValue(wrapper, null);
        }
    }

//    public class DbSetExtentions<TEntity> : DbSet<TEntity> where TEntity : class
//    {
//        public override TEntity Remove(TEntity entity)
//        {
//            var isDeltedField = entity.GetType().GetProperty("IsDeleted");
//            if (isDeltedField == null)
//            {
//                return base.Remove(entity);
//            }
//
//            isDeltedField.SetValue(entity, true);
//            return entity;
//        }
//    }
}
