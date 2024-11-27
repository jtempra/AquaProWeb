using AquaProWeb.Application.Repositories;
using AquaProWeb.Domain.Contracts;
using AquaProWeb.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AquaProWeb.Infrastructure.Repositories
{

    public class ReadRepositoryAsync<T> : IReadRepositoryAsync<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public ReadRepositoryAsync(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<List<T>> GetAllWithIncludesAsync(params Func<IQueryable<T>, IQueryable<T>>[] includeSelectors)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeSelector in includeSelectors)
            {
                query = includeSelector(query);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            query = query.Where(e => e.Id == Id);

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetByTextAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new List<T>();
            }


            var lowerSearchTerm = searchTerm.ToLower();

            // Crear la consulta inicial

            var query = _context.Set<T>().AsQueryable();
            var parameter = Expression.Parameter(typeof(T), "x");

            // Usar reflexión para buscar en todas las propiedades de tipo string

            var properties = typeof(T).GetProperties()
                .Where(prop => prop.PropertyType == typeof(string));

            // Crear una lista de expresiones para combinar

            var predicates = new List<Expression>();

            foreach (var property in properties)
            {
                // Crear la expresión de búsqueda

                var propertyAccess = Expression.Property(parameter, property);
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                // Construir la expresión de búsqueda

                var containsExpression = Expression.Call(propertyAccess, containsMethod, Expression.Constant(lowerSearchTerm));
                predicates.Add(containsExpression);
            }

            // Combinar las expresiones con OR

            var finalPredicate = predicates.Count > 1
                ? predicates.Aggregate<Expression>((x, y) => Expression.OrElse(x, y))
                : predicates.First();

            var lambda = Expression.Lambda<Func<T, bool>>(finalPredicate, parameter);

            // Aplicar la expresión de búsqueda a la consulta

            query = query.Where(lambda);

            return await query.ToListAsync();
        }
    }
}
