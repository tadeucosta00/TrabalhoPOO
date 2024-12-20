using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoPo.Models;
using ProjetoPo.Services;
using ProjetoPo.Utils;

namespace ProjetoPo.Tests
{
    [TestClass]
    public class PessoaServiceTests
    {
        [TestMethod]
        public void CriarPessoa()
        {
            var novaPessoa = new Pessoa
            {
                Nome = "João Silva",
                Email = "joao.silva@test.com",
                Telefone = "912345678",
                DocumentoIdentidade = "123456789",
                Senha = "SenhaSegura123",
                Adm = false,
                Ativo = true
            };

            PessoaService.CriarConta(novaPessoa); 
        }
    }
}
