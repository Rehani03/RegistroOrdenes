using Microsoft.EntityFrameworkCore;
using RegistroDeOrdenes.DAL;
using RegistroDeOrdenes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroDeOrdenes.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.ordenId))//si no existe insertamos
                return Insertar(ordenes);
            else
                return Modificar(ordenes);

        }

        private static bool Insertar(Ordenes ordenes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                
                //le sumamos la cantidad de productos adquiridos al inventario del producto
                foreach (var item in ordenes.OrdenDetalles)
                {
                    var auxOrden = contexto.Productos.Find(item.productoId);
                    if (auxOrden != null)
                    {
                        auxOrden.inventario += item.cantidad;
                    }
                }
                contexto.Ordenes.Add(ordenes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        private static bool Modificar(Ordenes ordenes)
        {
            bool paso = false;
            var Anterior = Buscar(ordenes.ordenId);
            Contexto contexto = new Contexto();

            try
            {
                //aqui borro del detalle y disminuyo el producto devuelto en inventario
                foreach (var item in Anterior.OrdenDetalles)
                {
                    var auxProducto = contexto.Productos.Find(item.productoId);
                    if (!ordenes.OrdenDetalles.Exists(d => d.ordenDetalleId == item.ordenDetalleId))
                    {
                        if (auxProducto != null)
                        {
                            auxProducto.inventario -= item.cantidad;
                        }

                        contexto.Entry(item).State = EntityState.Deleted;
                    }

                }

                //aqui agrego lo nuevo al detalle
                foreach (var item in ordenes.OrdenDetalles)
                {
                    var auxProducto = contexto.Productos.Find(item.productoId);
                    if (item.ordenDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        if (auxProducto != null)
                        {
                            auxProducto.inventario += item.cantidad;
                        }

                    }
                    else
                        contexto.Entry(item).State = EntityState.Modified;
                }


                contexto.Entry(ordenes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            var Anterior = Buscar(id);
            Contexto contexto = new Contexto();

            try
            {
                if (Existe(id))
                {
                    //aqui le resto las cantidades correspondientes a los producto
                    foreach (var item in Anterior.OrdenDetalles)
                    {
                        var auxProducto = contexto.Productos.Find(item.productoId);
                        if (auxProducto != null)
                        {
                            auxProducto.inventario -= item.cantidad;
                        }
                    }

                    //aqui remueve la entidad
                    var auxOrden = contexto.Ordenes.Find(id);
                    if (auxOrden != null)
                    {
                        contexto.Ordenes.Remove(auxOrden);
                        paso = contexto.SaveChanges() > 0;
                    }
                }
               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordenes ordenes; 

            try
            {
                ordenes = contexto.Ordenes.Where(o => o.ordenId == id).Include(d => d.OrdenDetalles).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ordenes;

        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> expression)
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Ordenes.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ordenes.Any(o => o.ordenId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;

        }
    }
}
