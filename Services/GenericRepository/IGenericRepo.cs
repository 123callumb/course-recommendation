using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.GenericRepository
{
    /// I may not put as many comments around the app as this. This place/folder is the hookline and sinker between the db,
    /// these managers will be used a lot!
    /// This is a generic repository that subtracts the need for entity repositories.
    public interface IGenericRepo
    {
        /// Add a row to the database.
        Task<int> Add<Entity>(Entity entity) where Entity : class;

        /// Add a multiple rows to the database.
        Task<int> AddRange<Entity>(List<Entity> entity) where Entity : class;

        /// Remove rows from the database.
        /// <typeparam name="Entity">Must be of type that belongs the entites generated by entity frameworks scaffold/</typeparam>
        /// <returns>An integer for how many rows in the db have been affected.</returns>
        Task<int> RemoveRange<Entity>(List<Entity> entity) where Entity : class;

        /// Remove a row from the database.
        /// <typeparam name="Entity">Must be of type that belongs the entites generated by entity frameworks scaffold/</typeparam>
        /// <returns>An integer for how many rows in the db have been affected.</returns>
        Task<int> Remove<Entity>(Entity entity) where Entity : class;

        /// Used after editing dbset entities.
        /// <returns>An integer for how many rows in the db have been affected.</returns>
        Task<int> SaveChanges();
    }
}
