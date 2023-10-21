using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Numerics;

namespace Back.Models
{
    public class AplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Quimico> Quimicos { get; set; }
        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<Legal> Legals { get; set; }

        public DbSet<Plano> Planos { get; set; }
        public DbSet<Historial> Historials { get; set; }
        public DbSet<Ats> Atss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Tecnico>()
            //  .HasOne(t => t.Licenciado)
            //  .WithMany(l => l.Tecnicos)
            //  .HasForeignKey(t => t.LicenciadoId);

            //modelBuilder.Entity<Tecnico>()
            //    .HasOne(t => t.Empleador)
            //    .WithMany(e => e.Tecnicos)
            //    .HasForeignKey(t => t.IdEmpleador);

            //modelBuilder.Entity<Tecnico>()
            //    .HasOne(t => t.Empresa)
            //    .WithMany(e => e.Tecnicos)
            //    .HasForeignKey(t => t.IdEmpresa);


            //modelBuilder.Entity<Licenciado>()
            //  .HasOne(l => l.Empleadors)
            //.WithMany(e => e.Licenciados)
            //   .HasForeignKey(l => l.IdEmpleador);

            //modelBuilder.Entity<Calendario>()
            //.HasOne(e => e.Licenciados)
            // .WithOne(l => l.Calendarios)
            //  .HasForeignKey<Calendario>(l => l.LicenciadoId);

            //modelBuilder.Entity<Empresa>()
            // .HasOne(l => l.Empleadors)
            // .WithMany(e => e.Empresas)
            //  .HasForeignKey(l => l.IdEmpleador);

            //modelBuilder.Entity<A_T_S>()
            //   .HasOne(t => t.Tecnico)
            //   .WithMany(l => l.A_T_S)
            //    .HasForeignKey(t => t.IdTecnico);

            //modelBuilder.Entity<Multimedia>()
            //   .HasOne(t => t.Tecnico)
            //   .WithMany(l => l.Multimedia)
            //    .HasForeignKey(t => t.IdTecnico);

            //modelBuilder.Entity<Empresa>()
            //  .HasOne(e => e.Emergencias)
            //  .WithOne(em => em.Empresa)
            //  .HasForeignKey<Emergencia>(em => em.IdEmpresa);

            //modelBuilder.Entity<Empresa>()
            //  .HasOne(e => e.Historials)
            //  .WithOne(h => h.Empresa)
            //  .HasForeignKey<Historial>(h => h.IdEmpresa);

            //modelBuilder.Entity<Empresa>()
            //  .HasOne(e => e.Legals)
            //  .WithOne(l => l.Empresa)
            //  .HasForeignKey<Legal>(l => l.IdEmpresa);

            //modelBuilder.Entity<Empresa>()
            //.HasOne(e => e.Planos)
            //  .WithOne(p => p.Empresa)
            //  .HasForeignKey<Planos>(p => p.IdEmpresa);

            //modelBuilder.Entity<Empresa>()
            //     .HasMany(e => Quimicoss)
            //     .WithMany(q => q.Empresas)
            //     .HasForeignKey(e => e.idEmpresa)
            //     .IsRequired()
            //     .OnDelete(DeleteBehavior.Cascade);

            //if (modelBuilder == null)
            //    throw new ArgumentNullException("modelBuilder");

            //// for the other conventions, we do a metadata model loop
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //    entityType.SetTableName(entityType.DisplayName());

            //    // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //    entityType.GetForeignKeys()
            //        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
            //        .ToList()
            //        .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            //}

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Tecnico",
                NormalizedName = "TECNICO",
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),

            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Licenciado",
                NormalizedName = "Licenciado",
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),

            });
        }

    }
}

