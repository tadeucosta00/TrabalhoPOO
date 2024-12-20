using Logs;
using ProjetoPo.Models;
using ProjetoPo.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace ProjetoPo.Services
{
    public static class AlojamentoService
    {
        private static readonly Logger logger = new Logger();

        public static List<Alojamento> GetAllAlojamentos()
        {
            try
            {
                List<Alojamento> alojamentos = AlojamentosTable.GetAllAlojamentos();
                return alojamentos;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter todos os alojamentos: {ex.Message}");
                throw new Exception("Erro ao obter Alojamentos.", ex);
            }
        }

        public static List<Alojamento> GetAlojamentos()
        {
            try
            {
                List<Alojamento> alojamentos = AlojamentosTable.GetAlojamentosDisponiveis();
                return alojamentos;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter alojamentos disponíveis: {ex.Message}");
                throw new Exception("Erro ao obter Alojamentos.", ex);
            }
        }

        public static Alojamento getAlojamentoById(int idAlojamento)
        {
            try
            {
                Alojamento alojamento = AlojamentosTable.GetAlojamentoById(idAlojamento);
                return alojamento;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter alojamento com ID {idAlojamento}: {ex.Message}");
                throw new Exception("Erro ao obter Alojamento.", ex);
            }
        }

        public static List<Alojamento> Pesquisar(string pesquisa)
        {
            try
            {
                List<Alojamento> resultados = AlojamentosTable.GetAlojamentosPorLocal(pesquisa);
                return resultados;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao pesquisar alojamentos com a pesquisa '{pesquisa}': {ex.Message}");
                throw new Exception("Erro ao obter Alojamentos.", ex);
            }
        }

        public static List<Alojamento> AplicarFiltros(string valorMin, string valorMax, string selectedTipo, string selectedIComodidades)
        {
            try
            {
                List<Alojamento> resultados = AlojamentosTable.getByFiltros(valorMin, valorMax, selectedTipo, selectedIComodidades);
                return resultados;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao aplicar filtros nos alojamentos (ValorMin: {valorMin}, ValorMax: {valorMax}, Tipo: {selectedTipo}, Comodidades: {selectedIComodidades}): {ex.Message}");
                throw new Exception("Erro ao obter Alojamentos.", ex);
            }
        }

        private static void ValidarAlojamento(Alojamento alojamento)
        {
            try
            {
                if (!int.TryParse(alojamento.Estrelas.ToString(), out int estrelasInt) || estrelasInt < 1 || estrelasInt > 5)
                {
                    throw new Exception("O campo Estrelas deve ser um número entre 1 e 5.");
                }

                if (!int.TryParse(alojamento.CapacidadeMaxima.ToString(), out int capacidadeInt) || capacidadeInt < 1)
                {
                    throw new Exception("O campo Capacidade deve ser um número superior a 1.");
                }

                if (!double.TryParse(alojamento.Latitude, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
                {
                    throw new Exception("O campo Latitude deve conter um valor numérico válido.");
                }

                if (!double.TryParse(alojamento.Longitude, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
                {
                    throw new Exception("O campo Longitude deve conter um valor numérico válido.");
                }

                if (!decimal.TryParse(alojamento.PrecoPorNoite.ToString(), out decimal precoDecimal) || precoDecimal < 0)
                {
                    throw new Exception("O campo Preço por Noite deve conter um valor numérico válido e positivo.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro na validação do alojamento: {ex.Message}");
                throw;
            }
        }

        public static int CriarAlojamento(Alojamento alojamento)
        {
            try
            {
                ValidarAlojamento(alojamento);
                int novoId = AlojamentosTable.AdicionarAlojamento(alojamento);

                if (novoId == 0)
                {
                    throw new Exception("Ocorreu um erro ao salvar o alojamento.");
                }

                MessageBox.Show("Alojamento criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return novoId;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao criar alojamento: {ex.Message}");
                throw new Exception("Erro ao criar alojamento.", ex);
            }
        }

        public static void AtualizarAlojamento(Alojamento alojamento)
        {
            try
            {
                ValidarAlojamento(alojamento);
                bool sucesso = AlojamentosTable.EditarAlojamento(alojamento);
                if (sucesso)
                {
                    MessageBox.Show("Alojamento editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao atualizar alojamento: {ex.Message}");
                throw new Exception("Erro ao atualizar alojamento.", ex);
            }
        }
    }
}
