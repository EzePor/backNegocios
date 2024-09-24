using Microsoft.EntityFrameworkCore;
using backNegocio.Models.Commons;
using backNegocio.Models.Detalles;
using backNegocio.Enums;

namespace backNegocio.DataContext
{
    public class NegocioContext : DbContext
    {
        public NegocioContext(DbContextOptions<NegocioContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string cadenaConexion = configuration.GetConnectionString("mysqlremoto");

            //optionsBuilder.UseSqlServer(cadenaConexion) ;
            optionsBuilder.UseMySql(cadenaConexion,
                                    ServerVersion.AutoDetect(cadenaConexion));
        }
       
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Clientes
            #region Datos semilla de clientes
            var cliente1 = new Cliente { id = 1, apellidoNombre = "Porchietto Ezequiel Gustavo",cuitDni = "25730663", direccion = " Juan Mantovani 1877", telefono = "3498 431264", email = "ezeporche@gmail.com", Localidad = "San Justo", CodigoPostal = "3040", Provincia = "Santa Fe" };

            var cliente2 = new Cliente { id = 2, apellidoNombre = "Perez Camila",cuitDni = "33258369", direccion = "Calle 31 324 ", telefono = "3498 452385", email = "camiperez@gamil.com", Localidad = "Videla", CodigoPostal = "3048", Provincia = "Santa Fe" };

            modelBuilder.Entity<Cliente>().HasData(cliente1);
            modelBuilder.Entity<Cliente>().HasData(cliente2);
            #endregion

            // Empleados
            #region Datos semilla de empleados
            var empleado1 = new Empleado
            {
                id = 1,
                apellidoNombre = "Gomez Juan",
                dni = "12345678",
            };

            var empleado2 = new Empleado
            {
                id = 2,
                apellidoNombre = "Cantero Maria",
                dni = "87654321",
            };

            modelBuilder.Entity<Empleado>().HasData(empleado1);
            modelBuilder.Entity<Empleado>().HasData(empleado2);
            #endregion

            // Productos
            #region Datos semilla de productos
            var producto1 = new Producto { id = 1, nombre = "Auricular inalámbrico F9", Rubro = RubroEnum.Auriculares , precio = 13500m, stock = 100 };
            var producto2 = new Producto { id = 2, nombre = "Album 200F 13x18 New Album", Rubro = RubroEnum.Fotografia, precio = 17900m, stock = 100 };
            var producto3 = new Producto { id = 3, nombre = "Reloj Digital Dakot 1845", Rubro = RubroEnum.Relojes, precio = 22300m, stock = 100 };

            modelBuilder.Entity<Producto>().HasData(producto1); 
            modelBuilder.Entity<Producto>().HasData(producto2);
            modelBuilder.Entity<Producto>().HasData(producto3);

            #endregion

            // Impresiones
            #region Datos semilla de impresiones
            var impresion1 = new Impresion { id = 1, tamanio = "7x10", precioBase = 800m, descuento10 = 0.10m, descuento20 = 0.20m, descuento50 = 0.50m };
            var impresion2 = new Impresion { id = 2, tamanio = "10x15", precioBase = 1000m, descuento10 = 0.10m, descuento20 = 0.20m, descuento50 = 0.50m };
            var impresion3 = new Impresion { id = 3, tamanio = "13x18", precioBase = 1500m, descuento10 = 0.10m, descuento20 = 0.20m, descuento50 = 0.50m };
            var impresion4 = new Impresion { id = 4, tamanio = "15x21", precioBase = 2000m, descuento10 = 0.10m, descuento20 = 0.20m, descuento50 = 0.50m };

            modelBuilder.Entity<Impresion>().HasData(impresion1);
            modelBuilder.Entity<Impresion>().HasData(impresion2);
            modelBuilder.Entity<Impresion>().HasData(impresion3);
            modelBuilder.Entity<Impresion>().HasData(impresion4);
            #endregion

            // Modos de pago
            #region Datos semilla de modo de pago
            var modoPago1 = new ModoPago { id = 1, nombre = "efectivo", ajuste = -0.5m };
            var modoPago2 = new ModoPago { id = 2, nombre = "débito", ajuste = 0m };
            var modoPago3 = new ModoPago { id = 3, nombre = "crédito", ajuste = 0m };
            var modoPago4 = new ModoPago { id = 4, nombre = "transferencia", ajuste = -0.5m };

            modelBuilder.Entity<ModoPago>().HasData(modoPago1);
            modelBuilder.Entity<ModoPago>().HasData(modoPago2);
            modelBuilder.Entity<ModoPago>().HasData(modoPago3);
            modelBuilder.Entity<ModoPago>().HasData(modoPago4);
            #endregion


        }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Impresion> Impresion { get; set; } 
        public DbSet<ModoPago> ModoPago { get; set; }
        public DbSet<DetalleImpresion> DetalleImpresion { get; set; } 
        public DbSet<DetallePedido> DetallePedido { get; set; } 
        public DbSet<Pedido> Pedido { get; set; } 


    }

   
}
