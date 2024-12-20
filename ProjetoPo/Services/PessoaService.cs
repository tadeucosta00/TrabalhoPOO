using Logs;
using Mono.Unix.Native;
using ProjetoPo.Models;
using ProjetoPo.Utils;
using System;
using System.Collections.Generic;

namespace ProjetoPo.Services
{
    public class PessoaService
    {
        private static readonly Logger logger = new Logger();

        public static void CriarConta(Pessoa pessoa)
        {
            try
            {
                if (string.IsNullOrEmpty(pessoa.Nome) || string.IsNullOrEmpty(pessoa.Email) ||
                    string.IsNullOrEmpty(pessoa.Telefone) || string.IsNullOrEmpty(pessoa.DocumentoIdentidade) ||
                    string.IsNullOrEmpty(pessoa.Senha))
                {
                    throw new ArgumentException("Todos os campos devem ser preenchidos.");
                }

                if (PessoaTable.EmailJaExistente(pessoa.Email))
                {
                    throw new InvalidOperationException("Este e-mail já está em uso.");
                }

                pessoa.Senha = HashHelper.GerarHashSHA256(pessoa.Senha);

                PessoaTable.Salvar(pessoa);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao criar conta: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        public static Pessoa ValidarLogin(string email, string senhaHash)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senhaHash))
                {
                    throw new ArgumentException("Email e senha são obrigatórios.");
                }

                Pessoa usuario = PessoaTable.GetByEmailAndPassword(email, senhaHash);

                if (usuario == null)
                {
                    throw new InvalidOperationException("Email ou senha incorretos.");
                }

                return usuario;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao validar login: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        public static void EditarPerfil(int id, string nome, string documentoid, string telefone)
        {
            try
            {
                if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(documentoid) || string.IsNullOrEmpty(telefone))
                {
                    throw new Exception("Todos os campos devem ser preenchidos.");
                }

                PessoaTable.Editar(id, nome, documentoid, telefone);

                MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao editar perfil: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        public static void AlterarPassword(int idUserLogged, string password, string passwordNova, string passwordNovaRepetida)
        {
            try
            {
                if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordNova) || string.IsNullOrEmpty(passwordNovaRepetida))
                {
                    throw new Exception("Todos os campos devem ser preenchidos.");
                }

                if (passwordNova != passwordNovaRepetida)
                {
                    throw new Exception("As passwords não coincidem!");
                }

                Pessoa user = PessoaTable.GetById(idUserLogged);

                string passwordHash = HashHelper.GerarHashSHA256(password);
                if (passwordHash != user.Senha)
                {
                    throw new Exception("A senha atual está incorreta!");
                }

                string passwordNovaHash = HashHelper.GerarHashSHA256(passwordNova);
                user.Senha = passwordNovaHash;

                PessoaTable.AtualizarSenha(user);

                MessageBox.Show("Senha atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao alterar senha: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        public static List<Pessoa> GetAllPessoas()
        {
            try
            {
                List<Pessoa> pessoas = PessoaTable.GetAll();
                return pessoas;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter todas as pessoas: {ex.Message}");
                throw new Exception("Erro a obter Pessoas.", ex);
            }
        }

        public static Pessoa GetById(int userId)
        {
            try
            {
                Pessoa pessoa = PessoaTable.GetById(userId);
                return pessoa;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter pessoa pelo ID {userId}: {ex.Message}");
                throw new Exception("Erro a obter Pessoa.", ex);
            }
        }

        public static void CriarPessoa(Pessoa pessoa)
        {
            try
            {
                if (string.IsNullOrEmpty(pessoa.Nome) || string.IsNullOrEmpty(pessoa.Email) || string.IsNullOrEmpty(pessoa.Telefone) || string.IsNullOrEmpty(pessoa.DocumentoIdentidade))
                {
                    throw new Exception("Todos os campos devem ser preenchidos.");
                }
                pessoa.Senha = HashHelper.GerarHashSHA256(pessoa.Senha);
                PessoaTable.Salvar(pessoa);
                MessageBox.Show("Pessoa criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao criar pessoa: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        public static void AtualizarPessoa(Pessoa pessoa)
        {
            try
            {
                if (string.IsNullOrEmpty(pessoa.Nome) || string.IsNullOrEmpty(pessoa.Email) || string.IsNullOrEmpty(pessoa.Telefone) || string.IsNullOrEmpty(pessoa.DocumentoIdentidade))
                {
                    throw new Exception("Todos os campos devem ser preenchidos.");
                }
                pessoa.Senha = HashHelper.GerarHashSHA256(pessoa.Senha);
                PessoaTable.Atualizar(pessoa);
                MessageBox.Show("Pessoa atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao atualizar pessoa: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
