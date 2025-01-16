using Microsoft.EntityFrameworkCore;
using PracticaFullCursoEFCore.Models;

namespace PracticaFullCursoEFCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
                
        }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Membresias> Membresias {  get; set; }

        public DbSet<Pedidos> Pedidos { get; set; }

        public DbSet<Productos> Productos { get; set; }

        public DbSet<PedidoProductos> PedidoProductos { get; set; }

        public DbSet<VistaMembresia> VistaMembresias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relación muchos a muchos Pedido/Producto primary key compuesta
            //modelBuilder.Entity<PedidoProductos>().HasKey(pedidoProducto => new { pedidoProducto.ID_Pedido, pedidoProducto.ID_Producto});
            //Clave Primaria
            modelBuilder.Entity<PedidoProductos>().HasKey(pp => pp.ID);
            //Que el email se unico - Clientes
            modelBuilder.Entity<Clientes>().HasIndex(c => c.Correo).IsUnique();
            //Presición de decimales costoMensual - Membresias
            modelBuilder.Entity<Membresias>().Property(m => m.CostoMensual).HasPrecision(18, 2);
            //Presición de decimales Total - Pedidos
            modelBuilder.Entity<Pedidos>().Property(p => p.Total).HasPrecision(18, 2);
            //Presición de decimales Precio - Productos
            modelBuilder.Entity<Productos>().Property(p => p.Precio).HasPrecision(18, 2);

            //Carga la vista
            modelBuilder.Entity<VistaMembresia>().HasNoKey().ToView("ObtenerMembresias");


            base.OnModelCreating(modelBuilder);
        }
    }
}
