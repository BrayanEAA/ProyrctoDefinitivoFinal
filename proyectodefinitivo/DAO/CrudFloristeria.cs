using Microsoft.EntityFrameworkCore;
using proyectodefinitivo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectodefinitivo.DAO
{
    public class CrudFloristeria
    {

        public void AgregarProducto(Producto ParametroProducto)
        {
            using (Floristeria2Context db = new Floristeria2Context())
            {
                Producto producto = new Producto();
                producto.NombreProducto = ParametroProducto.NombreProducto;
                producto.Precio = ParametroProducto.Precio;
                producto.Descripcion = ParametroProducto.Descripcion;
                db.Add(producto);
                db.SaveChanges();

            }
        }

        public Producto productoIndividual(int id)
        {
            using (Floristeria2Context db = new Floristeria2Context())
            {

                var buscar = db.Productos.FirstOrDefault(x => x.IdProducto == id);

                return buscar;
            }

        }

        public void ActualizarProducto(Producto ParametroProducto, int Lector)
        {
            using (Floristeria2Context db = new Floristeria2Context())
            {

                var buscar = productoIndividual(ParametroProducto.IdProducto);
                if (buscar == null)
                {
                    Console.WriteLine("El id no existe");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.NombreProducto = ParametroProducto.NombreProducto;
                    }


                    db.Update(buscar);
                    db.SaveChanges();

                }


            }

        }

        public void AgregarCliente(Cliente ParametroCliente)
        {
            using (Floristeria2Context db = new Floristeria2Context())
            {
                Cliente cliente = new Cliente();
                cliente.NombreCliente = ParametroCliente.NombreCliente;
                cliente.Telefono = ParametroCliente.Telefono;
                cliente.Email = ParametroCliente.Email;
                cliente.Direccion = ParametroCliente.Direccion;
                db.Add(cliente);
                db.SaveChanges();

            }
        }

        public Cliente clienteIndividual(int id)
        {
            using (Floristeria2Context db = new Floristeria2Context())
            {

                var buscar = db.Clientes.FirstOrDefault(x => x.IdCliente == id);

                return buscar;
            }

        }

        public void ActualizarCliente(Cliente ParametroCliente, int Lector)
        {
            using (Floristeria2Context db = new Floristeria2Context())
            {

                var buscar = clienteIndividual(ParametroCliente.IdCliente);
                if (buscar == null)
                {
                    Console.WriteLine("El id no existe");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.NombreCliente = ParametroCliente.NombreCliente;
                    }

                    db.Update(buscar);
                    db.SaveChanges();

                }


            }

        }

        public List<Cliente> ListarClientes()
        {
            using (Floristeria2Context db = new Floristeria2Context())
            { return db.Clientes.ToList(); }
        }

        public bool Acceso(Cliente cliente)
        {
            using (Floristeria2Context db = new Floristeria2Context())
            {
                var Acceder = db.Clientes.Where(x => x.IdCliente == cliente.IdCliente &&
                x.NombreCliente == cliente.NombreCliente
                ).ToList();

                return Acceder.Any() ? true : false;
                //if (Acceder.Any())
                //{
                //    return true;
                //}
                //else { 
                //    return false; 
                //}

            }


        }

        public List<Producto> ListarProductos()
        {
            using (Floristeria2Context db = new Floristeria2Context())
            { return db.Productos.ToList(); }
        }


        //public void Agregarventa(Ventum ParametroVenta)
        //{
        //    using (Floristeria2Context db = new Floristeria2Context())
        //    {

        //        Ventum venta1 = new Ventum();
        //        venta1.IdCliente = ParametroVenta.IdCliente;
        //        venta1.IdProducto = ParametroVenta.IdProducto;
        //        venta1.Fechapedido = DateTime.Now;
        //        venta1.Cantidad = ParametroVenta.Cantidad;
        //        venta1.Total = ParametroVenta.Total;


        //        db.Add(venta1);

        //        db.SaveChanges();
        //    }
        //}

        //public void CalcularTotal(Ventum venta1, Producto producto)
        //{

        //    venta1.Total = (Convert.ToDecimal(producto.Precio) * Convert.ToInt32(venta1.Cantidad));


        //}

        public void AgregarVenta(Ventum venta)
        {
            using (Floristeria2Context db = new Floristeria2Context())
            {
                // Agrega la venta a la base de datos
                db.Add(venta);

                try
                {
                    // Guarda los cambios en la base de datos
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    ;
                    Console.WriteLine(e);
                }
            }
        }

        public decimal CalcularProducto(Producto producto, Ventum venta)
        {
            decimal total = 0;

            using (Floristeria2Context db = new Floristeria2Context())
            {
                producto = db.Productos.FirstOrDefault(p => p.IdProducto == venta.IdProducto);

                if (producto != null)
                {
                    total = producto.Precio * venta.Cantidad;
                }
                else
                {
                    Console.WriteLine($"El producto con ID {venta.IdProducto} no existe en la base de datos.");
                }
            }

            return total;
        }





    }
}
