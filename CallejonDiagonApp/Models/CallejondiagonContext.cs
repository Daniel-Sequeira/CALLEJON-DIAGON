using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CallejonDiagonApp.Models;

public partial class CallejondiagonContext : DbContext
{
    public CallejondiagonContext()
    {
    }

    public CallejondiagonContext(DbContextOptions<CallejondiagonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Areastrabajo> Areastrabajos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<CategoriasHasProducto> CategoriasHasProductos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Comprasdetalle> Comprasdetalles { get; set; }

    public virtual DbSet<Detallehorariotrabajo> Detallehorariotrabajos { get; set; }

    public virtual DbSet<Detallesalario> Detallesalarios { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Historialventa> Historialventas { get; set; }

    public virtual DbSet<Horariostrabajo> Horariostrabajos { get; set; }

    public virtual DbSet<Metodopago> Metodopagos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Salario> Salarios { get; set; }

    public virtual DbSet<Unidadesmedida> Unidadesmedidas { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<Ventasdetalle> Ventasdetalles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;User=root;Password=Nuevocamino2056*;Database=callejondiagon");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Areastrabajo>(entity =>
        {
            entity.HasKey(e => e.IdArea).HasName("PRIMARY");

            entity.ToTable("areastrabajo");

            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.NombreArea)
                .HasMaxLength(45)
                .HasColumnName("nombreArea");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.CategoriaStatus)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("categoriaStatus");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(20)
                .HasColumnName("nombreCategoria");
        });

        modelBuilder.Entity<CategoriasHasProducto>(entity =>
        {
            entity.HasKey(e => new { e.CategoriasIdCategoria, e.ProductosIdProducto }).HasName("PRIMARY");

            entity.ToTable("categorias_has_productos");

            entity.HasIndex(e => e.CategoriasIdCategoria, "fk_Categorias_has_Productos_Categorias1_idx");

            entity.HasIndex(e => e.ProductosIdProducto, "fk_Categorias_has_Productos_Productos1_idx");

            entity.Property(e => e.CategoriasIdCategoria).HasColumnName("Categorias_idCategoria");
            entity.Property(e => e.ProductosIdProducto).HasColumnName("Productos_idProducto");

            entity.HasOne(d => d.CategoriasIdCategoriaNavigation).WithMany(p => p.CategoriasHasProductos)
                .HasForeignKey(d => d.CategoriasIdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Categorias_has_Productos_Categorias1");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.CedulaCliente, "cedulaCliente_UNIQUE").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.ApellidosCliente)
                .HasMaxLength(50)
                .HasColumnName("apellidosCliente");
            entity.Property(e => e.CedulaCliente).HasColumnName("cedulaCliente");
            entity.Property(e => e.ClienteStatus)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("clienteStatus");
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(100)
                .HasColumnName("direccionCliente");
            entity.Property(e => e.EmailCliente)
                .HasMaxLength(45)
                .HasColumnName("emailCliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(15)
                .HasColumnName("nombreCliente");
            entity.Property(e => e.TelefonoCliente)
                .HasMaxLength(20)
                .HasColumnName("telefonoCliente");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => new { e.IdCompra, e.ProveedoresIdProveedor }).HasName("PRIMARY");

            entity.ToTable("compras");

            entity.HasIndex(e => e.IdEmpleado, "FK_Compras_Empleados_idx");

            entity.HasIndex(e => e.IdMetodoPago, "FK_Compras_MPago_idx");

            entity.HasIndex(e => e.ProveedoresIdProveedor, "fk_Compras_Proveedores1_idx");

            entity.Property(e => e.IdCompra)
                .ValueGeneratedOnAdd()
                .HasColumnName("idCompra");
            entity.Property(e => e.ProveedoresIdProveedor).HasColumnName("Proveedores_idProveedor");
            entity.Property(e => e.CompraStatus)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("compraStatus");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("datetime")
                .HasColumnName("fechaCompra");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.ImporteTotalCompra)
                .HasPrecision(10)
                .HasColumnName("importeTotalCompra");
            entity.Property(e => e.Iva)
                .HasPrecision(4)
                .HasColumnName("iva");
            entity.Property(e => e.SubtotalCompra)
                .HasPrecision(10)
                .HasColumnName("subtotalCompra");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compras_Empleados");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdMetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compras_MPago");

            entity.HasOne(d => d.ProveedoresIdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProveedoresIdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compras_Proveedores1");
        });

        modelBuilder.Entity<Comprasdetalle>(entity =>
        {
            entity.HasKey(e => new { e.IdCompraDetalle, e.ComprasIdCompra, e.ComprasProveedoresIdProveedor }).HasName("PRIMARY");

            entity.ToTable("comprasdetalles");

            entity.HasIndex(e => new { e.ComprasIdCompra, e.ComprasProveedoresIdProveedor }, "fk_comprasDetalles_Compras1_idx");

            entity.Property(e => e.IdCompraDetalle)
                .ValueGeneratedOnAdd()
                .HasColumnName("idCompraDetalle");
            entity.Property(e => e.ComprasIdCompra).HasColumnName("Compras_idCompra");
            entity.Property(e => e.ComprasProveedoresIdProveedor).HasColumnName("Compras_Proveedores_idProveedor");
            entity.Property(e => e.Cantidad)
                .HasColumnType("mediumint")
                .HasColumnName("cantidad");
            entity.Property(e => e.IdCompra).HasColumnName("idCompra");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.ImporteTotalCompra)
                .HasPrecision(12)
                .HasColumnName("importeTotalCompra");
            entity.Property(e => e.PrecioCostoUnitario)
                .HasPrecision(12)
                .HasColumnName("precioCostoUnitario");

            entity.HasOne(d => d.Compra).WithMany(p => p.Comprasdetalles)
                .HasForeignKey(d => new { d.ComprasIdCompra, d.ComprasProveedoresIdProveedor })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_comprasDetalles_Compras1");
        });

        modelBuilder.Entity<Detallehorariotrabajo>(entity =>
        {
            entity.HasKey(e => e.IdDetalleHorarioT).HasName("PRIMARY");

            entity.ToTable("detallehorariotrabajo");

            entity.HasIndex(e => e.IdHorarioTrabajo, "FK_DetalleHT_HorarioT_idx");

            entity.Property(e => e.IdDetalleHorarioT).HasColumnName("idDetalleHorarioT");
            entity.Property(e => e.CantidadHoras).HasColumnName("cantidadHoras");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.HoraEntada)
                .HasColumnType("time")
                .HasColumnName("horaEntada");
            entity.Property(e => e.HoraSalida)
                .HasColumnType("time")
                .HasColumnName("horaSalida");
            entity.Property(e => e.IdHorarioTrabajo).HasColumnName("idHorarioTrabajo");

            entity.HasOne(d => d.IdHorarioTrabajoNavigation).WithMany(p => p.Detallehorariotrabajos)
                .HasForeignKey(d => d.IdHorarioTrabajo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleHT_HorarioT");
        });

        modelBuilder.Entity<Detallesalario>(entity =>
        {
            entity.HasKey(e => e.IdDetalleSalario).HasName("PRIMARY");

            entity.ToTable("detallesalario");

            entity.HasIndex(e => e.IdSalario, "FK_DetalleSal_Salario_idx");

            entity.Property(e => e.IdDetalleSalario).HasColumnName("idDetalleSalario");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdSalario).HasColumnName("idSalario");
            entity.Property(e => e.SubtotalSalario)
                .HasColumnType("decimal(10,2) unsigned")
                .HasColumnName("subtotalSalario");
            entity.Property(e => e.TotalSalario)
                .HasColumnType("decimal(10,2) unsigned")
                .HasColumnName("totalSalario");

            entity.HasOne(d => d.IdSalarioNavigation).WithMany(p => p.Detallesalarios)
                .HasForeignKey(d => d.IdSalario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleSal_Salario");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.IdArea, "FK_EMP_Areas_idx");

            entity.HasIndex(e => e.IdRol, "FK_Emp_Rol_idx");

            entity.HasIndex(e => e.CedulaEmpleado, "cedulaEmpleado_UNIQUE").IsUnique();

            entity.HasIndex(e => e.EmailEmpleado, "emailEmpleado_UNIQUE").IsUnique();

            entity.HasIndex(e => e.LoginUs, "usuario_UNIQUE").IsUnique();

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.ApellidosEmpleado)
                .HasMaxLength(60)
                .HasColumnName("apellidosEmpleado");
            entity.Property(e => e.CedulaEmpleado).HasColumnName("cedulaEmpleado");
            entity.Property(e => e.DireccionEmpleado)
                .HasMaxLength(100)
                .HasColumnName("direccionEmpleado");
            entity.Property(e => e.EmailEmpleado)
                .HasMaxLength(45)
                .HasColumnName("emailEmpleado");
            entity.Property(e => e.EmpleadoStatus)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("empleadoStatus");
            entity.Property(e => e.FechaAlta)
                .HasColumnType("date")
                .HasColumnName("fechaAlta");
            entity.Property(e => e.FechaBaja)
                .HasColumnType("date")
                .HasColumnName("fechaBaja");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.LoginUs)
                .HasMaxLength(45)
                .HasColumnName("loginUs");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(20)
                .HasColumnName("nombreEmpleado");
            entity.Property(e => e.PasswordEmpleado)
                .HasMaxLength(20)
                .HasColumnName("passwordEmpleado");
            entity.Property(e => e.TelefonoEmpleado)
                .HasMaxLength(20)
                .HasColumnName("telefonoEmpleado");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EMP_Areas");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emp_Rol");
        });

        modelBuilder.Entity<Historialventa>(entity =>
        {
            entity.HasKey(e => e.IdHistorialVentas).HasName("PRIMARY");

            entity.ToTable("historialventas");

            entity.HasIndex(e => e.IdMetodoPago, "FK_HISTORIAL_MPago_idx");

            entity.HasIndex(e => e.IdCliente, "FK_Historial_Cliente_idx");

            entity.HasIndex(e => e.IdEmpleado, "FK_Historial_Emp_idx");

            entity.HasIndex(e => e.IdProducto, "FK_Historial_Produc_idx");

            entity.HasIndex(e => e.FechaVenta, "Fecha");

            entity.HasIndex(e => new { e.FechaVenta, e.IdEmpleado, e.IdProducto, e.IdCliente }, "FechaEmpProdClient");

            entity.Property(e => e.IdHistorialVentas).HasColumnName("idHistorialVentas");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("datetime")
                .HasColumnName("fechaVenta");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.TotalVenta)
                .HasColumnType("decimal(20,2) unsigned")
                .HasColumnName("totalVenta");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Historialventa)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Cliente");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Historialventa)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Emp");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.Historialventa)
                .HasForeignKey(d => d.IdMetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HISTORIAL_MPago");
        });

        modelBuilder.Entity<Horariostrabajo>(entity =>
        {
            entity.HasKey(e => e.IdHorarioTrabajo).HasName("PRIMARY");

            entity.ToTable("horariostrabajo");

            entity.HasIndex(e => e.IdEmpleado, "FK_HorarioT_Emp_idx");

            entity.Property(e => e.IdHorarioTrabajo).HasColumnName("idHorarioTrabajo");
            entity.Property(e => e.DescripcionHorario)
                .HasMaxLength(20)
                .HasDefaultValueSql("'1'")
                .HasColumnName("descripcionHorario");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Horariostrabajos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HorarioT_Emp");
        });

        modelBuilder.Entity<Metodopago>(entity =>
        {
            entity.HasKey(e => e.IdMetodoPago).HasName("PRIMARY");

            entity.ToTable("metodopago");

            entity.Property(e => e.IdMetodoPago)
                .ValueGeneratedOnAdd()
                .HasColumnName("idMetodoPago");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(20)
                .HasColumnName("tipoPago");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => new { e.IdProducto, e.UnidadesMedidasIdUnidadMedida, e.ProveedoresIdProveedor }).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.IdProveedor, "FK_Productos_Prov_idx");

            entity.HasIndex(e => e.UnidadesMedidasIdUnidadMedida, "fk_Productos_UnidadesMedidas1_idx");

            entity.Property(e => e.IdProducto)
                .ValueGeneratedOnAdd()
                .HasColumnName("idProducto");
            entity.Property(e => e.UnidadesMedidasIdUnidadMedida).HasColumnName("UnidadesMedidas_idUnidadMedida");
            entity.Property(e => e.ProveedoresIdProveedor).HasColumnName("Proveedores_idProveedor");
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(80)
                .HasColumnName("descripcionProducto");
            entity.Property(e => e.Descuento)
                .HasColumnType("decimal(12,2) unsigned")
                .HasColumnName("descuento");
            entity.Property(e => e.Existencias)
                .HasColumnType("mediumint")
                .HasColumnName("existencias");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.IdUnidadMedida).HasColumnName("idUnidadMedida");
            entity.Property(e => e.ImagenProducto)
                .HasColumnType("blob")
                .HasColumnName("imagenProducto");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(20)
                .HasColumnName("nombreProducto");
            entity.Property(e => e.PrecioCosto)
                .HasColumnType("decimal(12,2) unsigned")
                .HasColumnName("precioCosto");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(12,2) unsigned")
                .HasColumnName("precioVenta");
            entity.Property(e => e.ProductoStatus)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("productoStatus");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Prov");

            entity.HasOne(d => d.UnidadesMedidasIdUnidadMedidaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.UnidadesMedidasIdUnidadMedida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Productos_UnidadesMedidas1");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.HasIndex(e => e.CedulaProveedor, "cedulaProveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.CedulaProveedor).HasColumnName("cedulaProveedor");
            entity.Property(e => e.EmailProveedor)
                .HasMaxLength(45)
                .HasColumnName("emailProveedor");
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(50)
                .HasColumnName("nombreProveedor");
            entity.Property(e => e.ProveedorStatus)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("proveedorStatus");
            entity.Property(e => e.TelefonoProveedor)
                .HasMaxLength(20)
                .HasColumnName("telefonoProveedor");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol)
                .ValueGeneratedOnAdd()
                .HasColumnName("idRol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(15)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<Salario>(entity =>
        {
            entity.HasKey(e => e.IdSalario).HasName("PRIMARY");

            entity.ToTable("salarios");

            entity.HasIndex(e => e.IdEmpleado, "FK_Salarios_EMP_idx");

            entity.Property(e => e.IdSalario).HasColumnName("idSalario");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.SalarioBase)
                .HasColumnType("decimal(10,2) unsigned")
                .HasColumnName("salarioBase");
            entity.Property(e => e.ValorHora)
                .HasColumnType("decimal(8,2) unsigned")
                .HasColumnName("valorHora");
            entity.Property(e => e.ValorHoraExtra)
                .HasPrecision(8)
                .HasColumnName("valorHoraExtra");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Salarios)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Salarios_EMP");
        });

        modelBuilder.Entity<Unidadesmedida>(entity =>
        {
            entity.HasKey(e => e.IdUnidadMedida).HasName("PRIMARY");

            entity.ToTable("unidadesmedidas");

            entity.Property(e => e.IdUnidadMedida).HasColumnName("idUnidadMedida");
            entity.Property(e => e.AbreviaturaMedida)
                .HasMaxLength(3)
                .HasColumnName("abreviaturaMedida");
            entity.Property(e => e.DescripcionMedida)
                .HasMaxLength(20)
                .HasColumnName("descripcionMedida");
            entity.Property(e => e.MedidaStatus)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("medidaStatus");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PRIMARY");

            entity.ToTable("ventas");

            entity.HasIndex(e => e.IdEmpleado, "FK_Ventas_Emp_idx");

            entity.HasIndex(e => e.IdMetodoPago, "FK_Ventas_MPago_idx");

            entity.HasIndex(e => e.ClientesIdCliente, "fk_Ventas_Clientes1_idx");

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.ClientesIdCliente)
                .ValueGeneratedOnAdd()
                .HasColumnName("Clientes_idCliente");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("datetime")
                .HasColumnName("fechaVenta");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");
            entity.Property(e => e.ImporteTotalVenta)
                .HasColumnType("decimal(10,2) unsigned")
                .HasColumnName("importeTotalVenta");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(4,2) unsigned")
                .HasColumnName("iva");
            entity.Property(e => e.SubttotalVenta)
                .HasColumnType("decimal(10,2) unsigned")
                .HasColumnName("subttotalVenta");
            entity.Property(e => e.VentaStatus)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("ventaStatus");

            entity.HasOne(d => d.ClientesIdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClientesIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Clientes");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Emp");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdMetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_MPago");
        });

        modelBuilder.Entity<Ventasdetalle>(entity =>
        {
            entity.HasKey(e => new { e.IdVentaDetalle, e.VentasIdVenta, e.VentasClientesIdCliente, e.ProductosIdProducto, e.ProductosUnidadesMedidasIdUnidadMedida, e.ProductosProveedoresIdProveedor }).HasName("PRIMARY");

            entity.ToTable("ventasdetalles");

            entity.HasIndex(e => e.ProductosIdProducto, "fk_ventasDetalles_Productos1_idx");

            entity.HasIndex(e => e.VentasIdVenta, "fk_ventasDetalles_Ventas1_idx");

            entity.Property(e => e.IdVentaDetalle).HasColumnName("idVentaDetalle");
            entity.Property(e => e.VentasIdVenta).HasColumnName("Ventas_idVenta");
            entity.Property(e => e.VentasClientesIdCliente).HasColumnName("Ventas_Clientes_idCliente");
            entity.Property(e => e.ProductosIdProducto).HasColumnName("Productos_idProducto");
            entity.Property(e => e.ProductosUnidadesMedidasIdUnidadMedida).HasColumnName("Productos_UnidadesMedidas_idUnidadMedida");
            entity.Property(e => e.ProductosProveedoresIdProveedor).HasColumnName("Productos_Proveedores_idProveedor");
            entity.Property(e => e.Cantidad)
                .HasColumnType("mediumint")
                .HasColumnName("cantidad");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.ImporteTotalVenta).HasColumnType("decimal(12,2) unsigned");
            entity.Property(e => e.PrecioVentaUnitario)
                .HasColumnType("decimal(12,2) unsigned")
                .HasColumnName("precioVentaUnitario");

            entity.HasOne(d => d.VentasIdVentaNavigation).WithMany(p => p.Ventasdetalles)
                .HasForeignKey(d => d.VentasIdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ventasDetalles_Ventas1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
