using Logs;
using ProjetoPo.Models;
using ProjetoPo.Services;
using System;
using System.Collections.Generic;

namespace ProjetoPo.Controllers
{
    public class PessoaController
    {
        private readonly Logger logger;

        public PessoaController()
        {
            logger = new Logger();
        }
        public void CriarConta(Pessoa pessoa)
        {
            try
            {
                PessoaService.CriarConta(pessoa);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao criar: {ex.Message}");
                throw new Exception($"Erro ao criar conta: {ex.Message}", ex);
            }
        }
            

        public Pessoa ValidarLogin(string email, string senhaHash)
        {
            try
            {
                return PessoaService.ValidarLogin(email, senhaHash);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao validar login: {ex.Message}");
                throw new Exception($"Erro ao validar login: {ex.Message}", ex);
            }
        }

        
        public void EditarPerfil(int id, string nome, string documentoId, string telefone)
        {
            try
            {
                PessoaService.EditarPerfil(id, nome, documentoId, telefone);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao editar perfil: {ex.Message}");
                throw new Exception($"Erro ao editar perfil: {ex.Message}", ex);
            }
        }

    
        public void AlterarSenha(int idUserLogged, string password, string passwordNova, string passwordNovaRepetida)
        {
            try
            {
                PessoaService.AlterarPassword(idUserLogged, password, passwordNova, passwordNovaRepetida);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao alterar senha: {ex.Message}");
                throw new Exception($"Erro ao alterar senha: {ex.Message}", ex);
            }
        }


        public List<Pessoa> GetAllPessoas()
        {
            try
            {
                return PessoaService.GetAllPessoas();
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter pessoas: {ex.Message}");
                throw new Exception($"Erro ao obter pessoas: {ex.Message}", ex);
            }
        }

        public Pessoa GetById(int userId)
        {
            try
            {
                return PessoaService.GetById(userId);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter a Utilizador com ID {userId}: {ex.Message}");
                throw new Exception($"Erro ao obter a Utilizador com ID {userId}: {ex.Message}", ex);
            }
        }

        public void CriarPessoa(Pessoa pessoa)
        {
            try
            {
                PessoaService.CriarPessoa(pessoa);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao criar pessoa: {ex.Message}");
                throw new Exception($"Erro ao criar pessoa: {ex.Message}", ex);
            }
        }

      
        public void AtualizarPessoa(Pessoa pessoa)
        {
            try
            {
                PessoaService.AtualizarPessoa(pessoa);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao atualizar pessoa: {ex.Message}");
                throw new Exception($"Erro ao atualizar pessoa: {ex.Message}", ex);
            }
        }
    }
}
