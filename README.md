# EF-SoftDelete
## # Welcome to the EF-SoftDelete wiki!

a simple extension implementation of EF softdeletes

This code is a simple Entity Framework extension method on > **DbSet<TEntity>** named > **Delete** .

When the Delete extension method is called on any DbSet<TEntity> `e.g Context.Persons.Delete(person);`
* It looks for a column Named "IsDelted" in the entity
* If it found the column it will update the column to _true_
* If it hasn't found any such column it will call the existing **Remove** implementation (i.e delete the entry from table).

**Pre-Requisites**
Table should have a column **IsDelted**
