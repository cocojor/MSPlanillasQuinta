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

        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<Contactoexpediente> Contactoexpediente { get; set; }
        public virtual DbSet<Cuentabancaria> Cuentabancaria { get; set; }
        public virtual DbSet<Dependencia> Dependencia { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Planillacabecera> Planillacabecera { get; set; }
        public virtual DbSet<Planilladetalle> Planilladetalle { get; set; }
        public virtual DbSet<Planillas> Planillas { get; set; }
        public virtual DbSet<Retencion> Retencion { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Rolpermiso> Rolpermiso { get; set; }
        public virtual DbSet<Tipodocumento> Tipodocumento { get; set; }
        public virtual DbSet<Tiporetencion> Tiporetencion { get; set; }
        public virtual DbSet<Topetrabajador> Topetrabajador { get; set; }
        public virtual DbSet<Trabajador> Trabajador { get; set; }
        public virtual DbSet<Trabajadorgrupo> Trabajadorgrupo { get; set; }
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

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.HasKey(e => e.Idbanco)
                    .HasName("PK__Banco__A087EB290A0787CC");

                entity.Property(e => e.Idbanco).HasColumnName("idbanco");

                entity.Property(e => e.Codigobanco)
                    .IsRequired()
                    .HasColumnName("codigobanco")
                    .HasMaxLength(10)
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

                entity.Property(e => e.Nombrebanco)
                    .IsRequired()
                    .HasColumnName("nombrebanco")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contactoexpediente>(entity =>
            {
                entity.HasKey(e => e.Idcontactoexpediente)
                    .HasName("PK__contacto__093E7205829A6584");

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
                    .HasConstraintName("FK__contactoe__idpla__4D94879B");
            });

            modelBuilder.Entity<Cuentabancaria>(entity =>
            {
                entity.HasKey(e => e.Idcuenta)
                    .HasName("PK__cuentaba__3F3026491B3EFA41");

                entity.ToTable("cuentabancaria");

                entity.Property(e => e.Idcuenta).HasColumnName("idcuenta");

                entity.Property(e => e.Idbanco).HasColumnName("idbanco");

                entity.Property(e => e.Idtrabajador).HasColumnName("idtrabajador");

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

                entity.Property(e => e.Nrocuenta)
                    .IsRequired()
                    .HasColumnName("nrocuenta")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdbancoNavigation)
                    .WithMany(p => p.Cuentabancaria)
                    .HasForeignKey(d => d.Idbanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cuentaban__idban__5DCAEF64");

                entity.HasOne(d => d.IdtrabajadorNavigation)
                    .WithMany(p => p.Cuentabancaria)
                    .HasForeignKey(d => d.Idtrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cuentaban__idtra__534D60F1");
            });

            modelBuilder.Entity<Dependencia>(entity =>
            {
                entity.HasKey(e => e.Iddependencia)
                    .HasName("PK__dependen__4DA1CE7377C2CB95");

                entity.ToTable("dependencia");

                entity.Property(e => e.Iddependencia).HasColumnName("iddependencia");

                entity.Property(e => e.Codigodependencia)
                    .IsRequired()
                    .HasColumnName("codigodependencia")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Codigofacultad)
                    .IsRequired()
                    .HasColumnName("codigofacultad")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idparent).HasColumnName("idparent");

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

                entity.HasOne(d => d.IdparentNavigation)
                    .WithMany(p => p.InverseIdparentNavigation)
                    .HasForeignKey(d => d.Idparent)
                    .HasConstraintName("FK__dependenc__idpar__5070F446");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.Idestado)
                    .HasName("PK__estado__5406DDAB2DA925A3");

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
                    .HasName("PK__grupo__F8D5E6CEF8C7B859");

                entity.ToTable("grupo");

                entity.Property(e => e.Idgrupo).HasColumnName("idgrupo");

                entity.Property(e => e.Codgrupo)
                    .IsRequired()
                    .HasColumnName("codgrupo")
                    .HasMaxLength(4)
                    .IsUnicode(false);

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

                entity.Property(e => e.Tipogrupo)
                    .IsRequired()
                    .HasColumnName("tipogrupo")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.Idpermiso)
                    .HasName("PK__permiso__85C7F900A9CBFF3F");

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
                    .HasName("PK__planilla__387EB7B8F789B232");

                entity.ToTable("planillacabecera");

                entity.HasIndex(e => e.Docuemntoingreso)
                    .HasName("UQ__planilla__0DBE5BBF6D15FC04")
                    .IsUnique();

                entity.HasIndex(e => e.Nroexpedinte)
                    .HasName("UQ__planilla__CA66EF4777BA0991")
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
                    .HasColumnType("text");

                entity.Property(e => e.Centrocostos)
                    .HasColumnName("centrocostos")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Docuemntoingreso)
                    .IsRequired()
                    .HasColumnName("docuemntoingreso")
                    .HasMaxLength(50)
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

                entity.Property(e => e.Mesprocesamiento).HasColumnName("mesprocesamiento");

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
                    .HasColumnType("text");

                entity.Property(e => e.Periodoexpedientes)
                    .HasColumnName("periodoexpedientes")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Planilla)
                    .HasColumnName("planilla")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Presupuestal)
                    .HasColumnName("presupuestal")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Procesamiento)
                    .HasColumnName("procesamiento")
                    .HasColumnType("datetime");

                entity.Property(e => e.Seccionfuncional)
                    .HasColumnName("seccionfuncional")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Siaf)
                    .HasColumnName("siaf")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IddependenciaNavigation)
                    .WithMany(p => p.Planillacabecera)
                    .HasForeignKey(d => d.Iddependencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__planillac__iddep__4E88ABD4");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.Planillacabecera)
                    .HasForeignKey(d => d.Idestado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__planillac__idest__5165187F");
            });

            modelBuilder.Entity<Planilladetalle>(entity =>
            {
                entity.HasKey(e => e.Idplanilladetalle)
                    .HasName("PK__planilla__66183D9B67880F10");

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

                entity.Property(e => e.Descuentoadicional)
                    .HasColumnName("descuentoadicional")
                    .HasColumnType("decimal(5, 4)");

                entity.Property(e => e.Dias)
                    .HasColumnName("dias")
                    .HasColumnType("text");

                entity.Property(e => e.Diasmes).HasColumnName("diasmes");

                entity.Property(e => e.Grupo)
                    .HasColumnName("grupo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Horarios)
                    .HasColumnName("horarios")
                    .HasColumnType("text");

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
                    .HasConstraintName("FK__planillad__idpla__4CA06362");

                entity.HasOne(d => d.IdtrabajadorNavigation)
                    .WithMany(p => p.Planilladetalle)
                    .HasForeignKey(d => d.Idtrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__planillad__idtra__52593CB8");
            });

            modelBuilder.Entity<Planillas>(entity =>
            {
                entity.HasKey(e => e.Idplanilla)
                    .HasName("PK__planilla__FDCFE0E853484041");

                entity.ToTable("planillas");

                entity.Property(e => e.Idplanilla).HasColumnName("idplanilla");

                entity.Property(e => e.Correlativo)
                    .IsRequired()
                    .HasColumnName("correlativo")
                    .HasMaxLength(10)
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

                entity.Property(e => e.Tipoplanilla)
                    .IsRequired()
                    .HasColumnName("tipoplanilla")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Planillas)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__planillas__idusu__59063A47");
            });

            modelBuilder.Entity<Retencion>(entity =>
            {
                entity.HasKey(e => e.Idretencion)
                    .HasName("PK__retencio__867D403905749F20");

                entity.ToTable("retencion");

                entity.Property(e => e.Idretencion).HasColumnName("idretencion");

                entity.Property(e => e.Idtiporetencion).HasColumnName("idtiporetencion");

                entity.Property(e => e.Idtrabajador).HasColumnName("idtrabajador");

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

                entity.Property(e => e.Monto)
                    .HasColumnName("monto")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Porcentaje)
                    .HasColumnName("porcentaje")
                    .HasColumnType("decimal(5, 4)");

                entity.HasOne(d => d.IdtiporetencionNavigation)
                    .WithMany(p => p.Retencion)
                    .HasForeignKey(d => d.Idtiporetencion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__retencion__idtip__5EBF139D");

                entity.HasOne(d => d.IdtrabajadorNavigation)
                    .WithMany(p => p.Retencion)
                    .HasForeignKey(d => d.Idtrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__retencion__idtra__5441852A");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("PK__rol__24C6BB2053874BBD");

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
                    .HasName("PK__rolpermi__3C9AC4B0837EAE58");

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
                    .HasConstraintName("FK__rolpermis__idper__5CD6CB2B");

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Rolpermiso)
                    .HasForeignKey(d => d.Idrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__rolpermis__idrol__5BE2A6F2");
            });

            modelBuilder.Entity<Tipodocumento>(entity =>
            {
                entity.HasKey(e => e.Idtipodocumento)
                    .HasName("PK__tipodocu__9B26597FB2CC0ABD");

                entity.ToTable("tipodocumento");

                entity.Property(e => e.Idtipodocumento).HasColumnName("idtipodocumento");

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

                entity.Property(e => e.Nombredocumento)
                    .IsRequired()
                    .HasColumnName("nombredocumento")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tiporetencion>(entity =>
            {
                entity.HasKey(e => e.Idtiporetencion)
                    .HasName("PK__tiporete__5B230EBEF214390E");

                entity.ToTable("tiporetencion");

                entity.Property(e => e.Idtiporetencion).HasColumnName("idtiporetencion");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500)
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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topetrabajador>(entity =>
            {
                entity.HasKey(e => e.Idtopetrabajador)
                    .HasName("PK__topetrab__9358BAAA10E38CA5");

                entity.ToTable("topetrabajador");

                entity.Property(e => e.Idtopetrabajador).HasColumnName("idtopetrabajador");

                entity.Property(e => e.Anho).HasColumnName("anho");

                entity.Property(e => e.Idtrabajador).HasColumnName("idtrabajador");

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

                entity.Property(e => e.Mes).HasColumnName("mes");

                entity.Property(e => e.Montotope)
                    .HasColumnName("montotope")
                    .HasColumnType("decimal(10, 4)");

                entity.HasOne(d => d.IdtrabajadorNavigation)
                    .WithMany(p => p.Topetrabajador)
                    .HasForeignKey(d => d.Idtrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__topetraba__idtra__5629CD9C");
            });

            modelBuilder.Entity<Trabajador>(entity =>
            {
                entity.HasKey(e => e.Idtrabajador)
                    .HasName("PK__trabajad__765CB464A3BC0D05");

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
                    .HasConstraintName("FK__trabajado__iddep__4F7CD00D");

                entity.HasOne(d => d.IdtipodocumentoNavigation)
                    .WithMany(p => p.Trabajador)
                    .HasForeignKey(d => d.Idtipodocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trabajado__idtip__571DF1D5");
            });

            modelBuilder.Entity<Trabajadorgrupo>(entity =>
            {
                entity.HasKey(e => new { e.Idtrabajador, e.Idgrupo })
                    .HasName("PK__trabajad__89D1EA08318D45D6");

                entity.ToTable("trabajadorgrupo");

                entity.HasIndex(e => e.Codigopersonal)
                    .HasName("UQ__trabajad__0BA3EAB015F2AF9D")
                    .IsUnique();

                entity.Property(e => e.Idtrabajador).HasColumnName("idtrabajador");

                entity.Property(e => e.Idgrupo).HasColumnName("idgrupo");

                entity.Property(e => e.Codigopersonal)
                    .IsRequired()
                    .HasColumnName("codigopersonal")
                    .HasMaxLength(10)
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

                entity.HasOne(d => d.IdgrupoNavigation)
                    .WithMany(p => p.Trabajadorgrupo)
                    .HasForeignKey(d => d.Idgrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trabajado__idgru__5812160E");

                entity.HasOne(d => d.IdtrabajadorNavigation)
                    .WithMany(p => p.Trabajadorgrupo)
                    .HasForeignKey(d => d.Idtrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trabajado__idtra__5535A963");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__usuario__080A974397CC4BE1");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Usuario1)
                    .HasName("UQ__usuario__9AFF8FC6CFEA8CB6")
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
                    .HasName("PK__usuarior__1A46FCF1ACE72A0F");

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
                    .HasConstraintName("FK__usuarioro__idrol__5AEE82B9");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Usuariorol)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarioro__idusu__59FA5E80");
            });
        }
    }
}
