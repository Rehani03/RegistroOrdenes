using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroDeOrdenes.BLL;
using RegistroDeOrdenes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroDeOrdenes.BLL.Tests
{
    [TestClass()]
    public class OrdenesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Ordenes ordenes = new Ordenes();
            ordenes.ordenId = 0;
            ordenes.suplidorId = 1;
            ordenes.fecha = DateTime.Now;
            ordenes.monto = 100;
            ordenes.OrdenDetalles.Add(new OrdenesDetalle
            {
                ordenDetalleId = 0,
                ordenId = 0,
                productoId = 1,
                costo = 100,
                cantidad = 1
            });
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = OrdenesBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Ordenes ordenes = new Ordenes();
            ordenes = OrdenesBLL.Buscar(1);
            Assert.IsNotNull(ordenes);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Ordenes>();
            lista = OrdenesBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = OrdenesBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }
    }
}