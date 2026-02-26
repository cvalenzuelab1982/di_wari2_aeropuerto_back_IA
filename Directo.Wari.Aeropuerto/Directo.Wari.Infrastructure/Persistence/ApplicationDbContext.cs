using Directo.Wari.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Directo.Wari.Infrastructure.Persistence
{
    /// <summary>
    /// DbContext principal de la aplicación.
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IReadDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public DbSet<Servicio> Servicios => Set<Servicio>();
        //public DbSet<Destino> Destinos => Set<Destino>();
        //public DbSet<Cliente> Clientes => Set<Cliente>();
        //public DbSet<Conductor> Conductores => Set<Conductor>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica todas las configuraciones de IEntityTypeConfiguration del assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Convención: nombres de tablas en snake_case (PostgreSQL)
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(ToSnakeCase(entity.GetTableName()!));

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ToSnakeCase(property.GetColumnName()));
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(ToSnakeCase(key.GetName()!));
                }

                foreach (var fk in entity.GetForeignKeys())
                {
                    fk.SetConstraintName(ToSnakeCase(fk.GetConstraintName()!));
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(ToSnakeCase(index.GetDatabaseName()!));
                }
            }
        }

        /// <summary>
        /// IReadDbContext implementation para queries de solo lectura.
        /// </summary>
        IQueryable<T> IReadDbContext.Set<T>() => Set<T>().AsNoTracking();

        private static string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var result = new System.Text.StringBuilder();
            for (var i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (char.IsUpper(c))
                {
                    if (i > 0) result.Append('_');
                    result.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
