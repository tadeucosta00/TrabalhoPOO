using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoPo.Models;
using ProjetoPo.Services;
using System.Collections.Generic;

namespace ProjetoPo.Tests
{
    [TestClass]
    public class AlojamentoServiceTests
    {
        [TestMethod]
        public void CriarAlojamento()
        {
            var novoAlojamento = new Alojamento
            {
                Nome = "Hotel Teste",
                Desc = "Um hotel de teste",
                Tipo = TipoAlojamento.Hotel,
                Latitude = "41.1579",
                Longitude = "-8.6291",
                PrecoPorNoite = 100.50,
                CapacidadeMaxima = 4,
                Disponivel = true,
                Estrelas = 5,
                Photos = false,
                Local = "Porto",
                Comodidades = new List<string> { "Wi-Fi", "Ar Condicionado" }
            };

            int resultado = AlojamentoService.CriarAlojamento(novoAlojamento);

            Assert.IsTrue(resultado > 0, "O ID do alojamento deve ser maior que 0.");
        }
    }
}
