using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjetoPo.Models
{
    public class PessoaManager
    {
        private static PessoaManager _instance;
        private Pessoa _pessoa;

        private PessoaManager()
        {
        }

        public static PessoaManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PessoaManager();
                }
                return _instance;
            }
        }

        public void AdicionarPessoa(Pessoa pessoa)
        {
            _pessoa = pessoa;
            _pessoa.Senha = "";
        }

        public Pessoa ObterUtilziadorLogado()
        {
            return _pessoa;
        }
    }
}
