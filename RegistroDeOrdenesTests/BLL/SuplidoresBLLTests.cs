﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroDeOrdenes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroDeOrdenes.BLL.Tests
{
    [TestClass()]
    public class SuplidoresBLLTests
    {
        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Suplidores>();
            lista = SuplidoresBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }
    }
}