using Fcx.Library.Application.Mediator;
using Fcx.Library.Application.Messages;
using Fcx.Library.Application.Port;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;
using Fcx.Caixa.Domain;

namespace Fcx.Caixa.Infrastructure
{
    public sealed class MovimentoContext : DbContext, IUnitOfWork
    {
        public MovimentoContext(DbContextOptions<MovimentoContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Movimento> Movimentos { get; set; }

        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<ValidationResult>();
            builder.Ignore<Event>();

            foreach (var property in builder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(50)");

            foreach (var relationship in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            builder.ApplyConfigurationsFromAssembly(typeof(MovimentoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            return sucesso;
        }
    }
}
