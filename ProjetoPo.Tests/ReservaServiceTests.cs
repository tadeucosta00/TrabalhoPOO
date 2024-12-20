using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoPo.Models;
using ProjetoPo.Services;
using ProjetoPo.Utils;
using System;

namespace ProjetoPo.Tests
{
    [TestClass]
    public class ReservaServiceTests
    {
        [TestMethod]
        public void ObterReservaById()
        {
            var reservaObtida = ReservasService.getReservaById(22);
        }
    }
}
