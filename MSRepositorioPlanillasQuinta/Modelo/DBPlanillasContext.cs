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
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Planillacabecera> Planillacabecera { get; set; }
        public virtual DbSet<Planilladetalle> Planilladetalle { get; set; }
        public virtual DbSet<Planillas> Planillas { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Rolpermiso> Rolpermiso { get; set; }
        public virtual DbSet<Tipodocumento> Tipodocumento { get; set; }
        public virtual DbSet<Trabajador> Trabajador { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Usuariorol> Usuariorol { get; set; }

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
                    .HasName("PK__contacto__093E72055304C51E");

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

                entity.HasOne(d => d.IdplanillacabeceraNavigation)
                    .WithMany(p => p.Contactoexpediente)
                    .HasForeignKey(d => d.Idplanillacabecera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contactoe__idpla__412EB0B6");
            });

            modelBuilder.Entity<Dependencia>(entity =>
            {
                entity.HasKey(e => e.Iddependencia)
                    .HasName("PK__dependen__4DA1CE73E0F85D26");

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
                    .HasName("PK__estado__5406DDAB6B20C01F");

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
                    .HasName("PK__grupo__F8D5E6CE42ACA22C");

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

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.Idpermiso)
                    .HasName("PK__permiso__85C7F90042399286");

                entity.ToTable("permiso");

                entity.Property(e => e.Idpermiso).HasColumnName("idpermiso");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Iconmenu)
                    .HasColumnName("iconmenu")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idpadre).HasColumnName("idpadre");

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

                entity.Property(e => e.Nivel).HasColumnName("nivel");

                entity.Property(e => e.Ruta)
                    .IsRequired()
                    .HasColumnName("ruta")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Submenu)
                    .HasColumnName("submenu")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Planillacabecera>(entity =>
            {
                entity.HasKey(e => e.Idplanillacabecera)
                    .HasName("PK__planilla__387EB7B8DA09F9E3");

                entity.ToTable("planillacabecera");

                entity.HasIndex(e => e.Docuemntoingreso)
                    .HasName("UQ__planilla__0DBE5BBFB57A1C0F")
                    .IsUnique();

                entity.HasIndex(e => e.Nroexpedinte)
                    .HasName("UQ__planilla__CA66EF47C02C9053")
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

                entity.HasOne(d => d.IddependenciaNavigation)
                    .WithMany(p => p.Planillacabecera)
                    .HasForeignKey(d => d.Iddependencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__planillac__iddep__4222D4EF");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.Planillacabecera)
                    .HasForeignKey(d => d.Idestado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__planillac__idest__440B1D61");
            });

            modelBuilder.Entity<Planilladetalle>(entity =>
            {
                entity.HasKey(e => e.Idplanilladetalle)
                    .HasName("PK__planilla__66183D9BC369D973");

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

                entity.HasOne(d => d.IdplanillacabeceraNavigation)
                    .WithMany(p => p.Planilladetalle)
                    .HasForeignKey(d => d.Idplanillacabecera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__planillad__idpla__403A8C7D");

                entity.HasOne(d => d.IdtrabajadorNavigation)
                    .WithMany(p => p.Planilladetalle)
                    .HasForeignKey(d => d.Idtrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__planillad__idtra__44FF419A");
            });

            modelBuilder.Entity<Planillas>(entity =>
            {
                entity.HasKey(e => e.Idplanilla)
                    .HasName("PK__Planilla__FDCFE0E82DD743E3");

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

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Planillas)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Planillas__idusu__47DBAE45");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("PK__rol__24C6BB2020642CC9");

                entity.ToTable("rol");

                entity.Property(e => e.Idrol).HasColumnName("idrol");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
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

            modelBuilder.Entity<Rolpermiso>(entity =>
            {
                entity.HasKey(e => new { e.Idrol, e.Idpermiso })
                    .HasName("PK__rolpermi__3C9AC4B0CDCD9549");

                entity.ToTable("rolpermiso");

                entity.Property(e => e.Idrol).HasColumnName("idrol");

                entity.Property(e => e.Idpermiso).HasColumnName("idpermiso");

                entity.Property(e => e.LogEstado)
                    .HasColumnName("log_estado")
                    .HasColumnType("datetime");

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

                entity.Property(e => e.LogUsuariomodifca)
                    .IsRequired()
                    .HasColumnName("log_usuariomodifca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdpermisoNavigation)
                    .WithMany(p => p.Rolpermiso)
                    .HasForeignKey(d => d.Idpermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__rolpermis__idper__4BAC3F29");

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Rolpermiso)
                    .HasForeignKey(d => d.Idrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__rolpermis__idrol__4AB81AF0");
            });

            modelBuilder.Entity<Tipodocumento>(entity =>
            {
                entity.HasKey(e => e.Idtipodocumento)
                    .HasName("PK__tipodocu__9B26597FA7DE8CAD");

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
                    .HasName("PK__trabajad__765CB464057F7BF1");

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

                entity.HasOne(d => d.IddependenciaNavigation)
                    .WithMany(p => p.Trabajador)
                    .HasForeignKey(d => d.Iddependencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trabajado__iddep__4316F928");

                entity.HasOne(d => d.IdgrupoNavigation)
                    .WithMany(p => p.Trabajador)
                    .HasForeignKey(d => d.Idgrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trabajado__idgru__46E78A0C");

                entity.HasOne(d => d.IdtipodocumentoNavigation)
                    .WithMany(p => p.Trabajador)
                    .HasForeignKey(d => d.Idtipodocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trabajado__idtip__45F365D3");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__usuario__080A9743DCA00CE1");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Usuario1)
                    .HasName("UQ__usuario__9AFF8FC6DBAF5B2F")
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

            modelBuilder.Entity<Usuariorol>(entity =>
            {
                entity.HasKey(e => new { e.Idusuario, e.Idrol })
                    .HasName("PK__usuarior__1A46FCF16810283B");

                entity.ToTable("usuariorol");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Idrol).HasColumnName("idrol");

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

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Usuariorol)
                    .HasForeignKey(d => d.Idrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarioro__idrol__49C3F6B7");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Usuariorol)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarioro__idusu__48CFD27E");
            });
        }
    }
}
