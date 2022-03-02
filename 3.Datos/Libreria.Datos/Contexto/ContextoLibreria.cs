namespace Libreria.Datos.Contexto
{
    using Libreria.Datos.Repositorio;
    using Microsoft.EntityFrameworkCore;
    public partial class ContextoLibreria : DbContext
    {  
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("autor_pk")
                    .IsClustered(false);

                entity.ToTable("autor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Identificacion).HasColumnName("identificacion");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("primer_apellido");

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("primer_nombre");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("segundo_apellido");

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("segundo_nombre");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("editorial_pk")
                    .IsClustered(false);

                entity.ToTable("editorial");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.RegistroMaximo).HasColumnName("registro_maximo");

                entity.Property(e => e.Telefono).HasColumnName("telefono");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("libro_pk")
                    .IsClustered(false);

                entity.ToTable("libro");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Anio).HasColumnName("anio");

                entity.Property(e => e.AutorId).HasColumnName("autor_id");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.EditorialId).HasColumnName("editorial_id");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("genero");

                entity.Property(e => e.Paginas).HasColumnName("paginas");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
