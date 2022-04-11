using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AjutorNevoiasiSportivi2.Entities
{
    public class AjutorNevoiasiSportivi2Context:IdentityDbContext<User,Role,string,IdentityUserClaim<string>,
        UserRole,IdentityUserLogin<string>,IdentityRoleClaim<string>,IdentityUserToken<string>>
    {
        public AjutorNevoiasiSportivi2Context(DbContextOptions<AjutorNevoiasiSportivi2Context> options) : base(options){}
        public DbSet<Adresa> Adrese { get; set; }
        public DbSet<Antrenor> Antrenori { get; set; }
        public DbSet<Club> Cluburi { get; set; }
        public DbSet<Competitie> Competitii { get; set; }
        public DbSet<Donare> Donari { get; set; }
        public DbSet<Donator> Donatori { get; set; }
        public DbSet<Inscriere>Inscrieri { get; set; }
        public DbSet<IstoricParticipare> IstoricParticipari { get; set; }
        public DbSet<Proba> Probe { get; set; }
        public DbSet<Sport>Sporturi { get; set; }
        public DbSet<TalentatNevoias> TalentatNevoiasi { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        /*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder
                        //.UseLazyLoadingProxies()
                        //.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                        .UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectSoftbinator;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                }*/
        protected override void OnModelCreating(ModelBuilder builder)
        {

            
            base.OnModelCreating(builder);

            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });
            //relatia 1-1
            builder.Entity<TalentatNevoias>()
                .HasOne(t => t.Adresa)
                .WithOne(a => a.TalentatNevoias);

            //RELATIA 1-M (CLUB-ANTRENOR)
            builder.Entity<Club>()
                .HasMany(c => c.Antrenori)
                .WithOne(a => a.Club);
            //relatia 1-M (Sport- Antrenor)
            builder.Entity<Sport>()
                .HasMany(s => s.Antrenori)
                .WithOne(a => a.Sport);

            //relatia M-M-M Competitie-Proba-Nevoias
            builder.Entity<IstoricParticipare>().HasKey(ip => new { ip.TalentatNevoiasId, ip.CompetitieId, ip.ProbaId });
            builder.Entity<IstoricParticipare>()
                .HasOne(ip => ip.TalentatNevoias)
                .WithMany(t => t.IstoricParticipari)
                .HasForeignKey(ip => ip.TalentatNevoiasId);

            builder.Entity<IstoricParticipare>()
                .HasOne(ip => ip.Competitie)
                .WithMany(c => c.IstoricParticipari)
                .HasForeignKey(ip => ip.CompetitieId);

            builder.Entity<IstoricParticipare>()
                .HasOne(ip => ip.Proba)
                .WithMany(p => p.IstoricParticipari)
                .HasForeignKey(ip => ip.ProbaId);

            //relatie M-M Nevoias-Donator
            builder.Entity<Donare>().HasKey(d => new { d.DonatorId, d.TalentatNevoiasId, d.DataDonatie, d.ElementDonat });
            builder.Entity<Donare>()
                .HasOne(d => d.Donator)
                .WithMany(don => don.Donari)
                .HasForeignKey(d => d.DonatorId);

            builder.Entity<Donare>()
                .HasOne(d => d.TalentatNevoias)
                .WithMany(t => t.Donari)
                .HasForeignKey(d => d.TalentatNevoiasId);

            //relatie M-M Nevoias-Antrenor
            builder.Entity<Inscriere>().HasKey(i => new {i.TalentatNevoiasId,i.AntrenorId,i.DataStart});
            builder.Entity<Inscriere>()
                .HasOne(i => i.Antrenor)
                .WithMany(a => a.Inscrieri)
                .HasForeignKey(i => i.AntrenorId);

            builder.Entity<Inscriere>()
                .HasOne(i => i.TalentatNevoias)
                .WithMany(t => t.Inscrieri)
                .HasForeignKey(i => i.TalentatNevoiasId);

        }

    }

}
