using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class DBPlanillasContext : DbContext
    {
        public DBPlanillasContext()
        {
        }

        public DBPlanillasContext(DbContextOptions<DBPlanillasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contactoexpediente> Contactoexpediente { get; set; }
        public virtual DbSet<Dependencia> Dependencia { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Planillacabecera> Planillacabecera { get; set; }
        public virtual DbSet<Planilladetalle> Planilladetalle { get; set; }
        public virtual DbSet<Planillas> Planillas { get; set; }
        public virtual DbSet<Tipodocumento> Tipodocumento { get; set; }
        public virtual DbSet<Trabajador> Trabajador { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DBPlanillas;User ID=adminplan;Password=planillas123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Contactoexpediente>(entity =>
            {
                entity.HasKey(e => e.Idcontactoexpediente)
                    .HasName("PK__contacto__093E7205A94B7E2D");

                entity.ToTable("contactoexpediente");

                entity.Property(e => e.Idcontactoexpediente).HasColumnName("idcontactoexpediente");

                entity.Property(e => e.Contacto)
                    .IsRequired()
                    .HasColumnName("contacto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fechacontacto)
                    .HasColumnName("fechacontacto")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idplanillacabecera).HasColumnName("idplanillacabecera");

                entity.Property(e => e.LogEstado).HasColumnName("log_estado");

                entity.Property(e => e.LogFechacrea)
                    .HasColumnName("log_fechacrea")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogFechamodifica)
                    .HasColumnName("log_fechamodifica")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogUsuariocrea)
                    .IsRequired()
                    .HasColumnName("log_usuariocrea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogUsuariomodifica)
                    .IsRequired()
                    .HasColumnName("log_usuariomodifica")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Motivo)
                    .HasColumnName("motivo")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dependencia>(entity =>
            {
                entity.HasKey(e => e.Iddependencia)
                    .HasName("PK__dependen__4DA1CE7350FCED85");

                entity.ToTable("dependencia");

                entity.Property(e => e.Iddependencia).HasColumnName("iddependencia");

                entity.Property(e => e.Codigodependencia)
                    .IsRequired()
                    .HasColumnName("codigodependencia")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Codigofacultad)
                    .IsRequired()
                    .HasColumnName("codigofacultad")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogEstado).HasColumnName("log_estado");

                entity.Property(e => e.LogFechacrea)
                    .HasColumnName("log_fechacrea")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogFechamodifica)
                    .HasColumnName("log_fechamodifica")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogUsuariocrea)
                    .IsRequired()
                    .HasColumnName("log_usuariocrea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogUsuariomodifica)
                    .IsRequired()
                    .HasColumnName("log_usuariomodifica")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.Idestado)
                    .HasName("PK__estado__5406DDABAB4DF2B5");

                entity.ToTable("estado");

                entity.Property(e => e.Idestado).HasColumnName("idestado");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LogEstado).HasColumnName("log_estado");

                entity.Property(e => e.LogFechacrea)
                    .HasColumnName("log_fechacrea")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogFechamodifica)
                    .HasColumnName("log_fechamodifica")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogUsuariocrea)
                    .IsRequired()
                    .HasColumnName("log_usuariocrea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogUsuariomodifica)
                    .IsRequired()
                    .HasColumnName("log_usuariomodifica")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.Idgrupo)
                    .HasName("PK__grupo__F8D5E6CE176764D7");

                entity.ToTable("grupo");

                entity.Property(e => e.Idgrupo).HasColumnName("idgrupo");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo1)
                    .IsRequired()
                    .HasColumnName("grupo")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.LogEstado).HasColumnName("log_estado");

                entity.Property(e => e.LogFechacrea)
                    .HasColumnName("log_fechacrea")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogFechamodifica)
                    .HasColumnName("log_fechamodifica")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogUsuariocrea)
                    .IsRequired()
                    .HasColumnName("log_usuariocrea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogUsuariomodifica)
                    .IsRequired()
                    .HasColumnName("log_usuariomodifica")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Planillacabecera>(entity =>
            {
                entity.HasKey(e => e.Idplanillacabecera)
                    .HasName("PK__planilla__387EB7B84F78A2F0");

                entity.ToTable("planillacabecera");

                entity.HasIndex(e => e.Docuemntoingreso)
                    .HasName("UQ__planilla__0DBE5BBF1A1B05A7")
                    .IsUnique();

                entity.HasIndex(e => e.Nroexpedinte)
                    .HasName("UQ__planilla__CA66EF4742C09A3D")
                    .IsUnique();

                entity.Property(e => e.Idplanillacabecera).HasColumnName("idplanillacabecera");

                entity.Property(e => e.Actividadoperativa)
                    .HasColumnName("actividadoperativa")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Anhodocumento).HasColumnName("anhodocumento");

                entity.Property(e => e.Anhoejecucion).HasColumnName("anhoejecucion");

                entity.Property(e => e.Asunto)
                    .HasColumnName("asunto")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Centrocostos)
                    .HasColumnName("centrocostos")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Docuemntoingreso)
                    .IsRequired()
                    .HasColumnName("docuemntoingreso")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fechaactualizacion)
                    .HasColumnName("fechaactualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechaingreso)
                    .HasColumnName("fechaingreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Folio)
                    .HasColumnName("folio")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Iddependencia).HasColumnName("iddependencia");

                entity.Property(e => e.Idestado).HasColumnName("idestado");

                entity.Property(e => e.LogEstado).HasColumnName("log_estado");

                entity.Property(e => e.LogFechacrea)
                    .HasColumnName("log_fechacrea")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogFechamodifica)
                    .HasColumnName("log_fechamodifica")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogUsuariocrea)
                    .IsRequired()
                    .HasColumnName("log_usuariocrea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogUsuariomodifica)
                    .IsRequired()
                    .HasColumnName("log_usuariomodifica")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notatransaccion)
                    .HasColumnName("notatransaccion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nroexpedinte)
                    .IsRequired()
                    .HasColumnName("nroexpedinte")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Periodoexpedientes)
                    .HasColumnName("periodoexpedientes")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Planilla)
                    .HasColumnName("planilla")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Procesamiento)
                    .HasColumnName("procesamiento")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Seccionfuncional)
                    .HasColumnName("seccionfuncional")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Planilladetalle>(entity =>
            {
                entity.HasKey(e => e.Idplanilladetalle)
                    .HasName("PK__planilla__66183D9B78B7D482");

                entity.ToTable("planilladetalle");

                entity.Property(e => e.Idplanilladetalle).HasColumnName("idplanilladetalle");

                entity.Property(e => e.Anhopago).HasColumnName("anhopago");

                entity.Property(e => e.Banco)
                    .HasColumnName("banco")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Concepto)
                    .HasColumnName("concepto")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento)
                    .HasColumnName("descuento")
                    .HasColumnType("decimal(5, 4)");

                entity.Property(e => e.Dias)
                    .HasColumnName("dias")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Diasmes).HasColumnName("diasmes");

                entity.Property(e => e.Horarios)
                    .HasColumnName("horarios")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idplanillacabecera).HasColumnName("idplanillacabecera");

                entity.Property(e => e.Idtrabajador).HasColumnName("idtrabajador");

                entity.Property(e => e.Judicial)
                    .HasColumnName("judicial")
                    .HasColumnType("decimal(5, 4)");

                entity.Property(e => e.LogEstado).HasColumnName("log_estado");

                entity.Property(e => e.LogFechacrea)
                    .HasColumnName("log_fechacrea")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogFechamodifica)
                    .HasColumnName("log_fechamodifica")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogUsuariocrea)
                    .IsRequired()
                    .HasColumnName("log_usuariocrea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogUsuariomodifica)
                    .IsRequired()
                    .HasColumnName("log_usuariomodifica")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Meses).HasColumnName("meses");

                entity.Property(e => e.Monto)
                    .HasColumnName("monto")
                    .HasColumnType("decimal(5, 4)");

                entity.Property(e => e.Montototal)
                    .HasColumnName("montototal")
                    .HasColumnType("decimal(5, 4)");

                entity.Property(e => e.Numerocuenta)
                    .HasColumnName("numerocuenta")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Porcentajejudicial)
                    .HasColumnName("porcentajejudicial")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Porcentajequinta)
                    .HasColumnName("porcentajequinta")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Quinta)
                    .HasColumnName("quinta")
                    .HasColumnType("decimal(5, 4)");

                entity.Property(e => e.Totaldias).HasColumnName("totaldias");
            });

            modelBuilder.Entity<Planillas>(entity =>
            {
                entity.HasKey(e => e.Idplanilla)
                    .HasName("PK__Planilla__FDCFE0E8B2A16B19");

                entity.Property(e => e.Idplanilla).HasColumnName("idplanilla");

                entity.Property(e => e.Correlativo)
                    .IsRequired()
                    .HasColumnName("correlativo")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcionplanilla)
                    .IsRequired()
                    .HasColumnName("descripcionplanilla")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.LogEstado).HasColumnName("log_estado");

                entity.Property(e => e.LogFechacrea)
                    .HasColumnName("log_fechacrea")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogFechamodifica)
                    .HasColumnName("log_fechamodifica")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogUsauriomodifica)
                    .IsRequired()
                    .HasColumnName("log_usauriomodifica")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogUsuariocrea)
                    .IsRequired()
                    .HasColumnName("log_usuariocrea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipoplanilla)
                    .IsRequired()
                    .HasColumnName("tipoplanilla")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipodocumento>(entity =>
            {
                entity.HasKey(e => e.Idtipodocumento)
                    .HasName("PK__tipodocu__9B26597F495B3061");

                entity.ToTable("tipodocumento");

                entity.Property(e => e.Idtipodocumento).HasColumnName("idtipodocumento");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasColumnName("documento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LogEstado).HasColumnName("log_estado");

                entity.Property(e => e.LogFechacrea)
                    .HasColumnName("log_fechacrea")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogFechamodifica)
                    .HasColumnName("log_fechamodifica")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogUsuariocrea)
                    .IsRequired()
                    .HasColumnName("log_usuariocrea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogUsuariomodifica)
                    .IsRequired()
                    .HasColumnName("log_usuariomodifica")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trabajador>(entity =>
            {
                entity.HasKey(e => e.Idtrabajador)
                    .HasName("PK__trabajad__765CB4644268DE70");

                entity.ToTable("trabajador");

                entity.Property(e => e.Idtrabajador).HasColumnName("idtrabajador");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasColumnName("documento")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Iddependencia).HasColumnName("iddependencia");

                entity.Property(e => e.Idgrupo).HasColumnName("idgrupo");

                entity.Property(e => e.Idtipodocumento).HasColumnName("idtipodocumento");

                entity.Property(e => e.LogEstado).HasColumnName("log_estado");

                entity.Property(e => e.LogFechacrea)
                    .HasColumnName("log_fechacrea")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogFechamodifica)
                    .HasColumnName("log_fechamodifica")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogUsuariocrea)
                    .IsRequired()
                    .HasColumnName("log_usuariocrea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogUsuariomodifica)
                    .IsRequired()
                    .HasColumnName("log_usuariomodifica")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombreapellido)
                    .HasColumnName("nombreapellido")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__usuario__080A974369CCA2C5");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Usuario1)
                    .HasName("UQ__usuario__9AFF8FC62FC93A96")
                    .IsUnique();

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LogEstado).HasColumnName("log_estado");

                entity.Property(e => e.LogFechacrea)
                    .HasColumnName("log_fechacrea")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogFechamodifica)
                    .HasColumnName("log_fechamodifica")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogUsuariocrea)
                    .IsRequired()
                    .HasColumnName("log_usuariocrea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogUsuariomodifica)
                    .IsRequired()
                    .HasColumnName("log_usuariomodifica")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
