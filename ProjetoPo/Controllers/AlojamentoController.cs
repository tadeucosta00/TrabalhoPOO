using Logs;
using ProjetoPo.Services;
using ProjetoPo.Models;
using System;
using System.Collections.Generic;

namespace ProjetoPo.Controllers
{
    public class AlojamentoController
    {
        private readonly Logger logger;

        public AlojamentoController()
        {
            logger = new Logger();
        }

        public List<Alojamento> GetAllAlojamentos()
        {
            try
            {
                return AlojamentoService.GetAllAlojamentos();
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter alojamentos: {ex.Message}");
                throw new Exception($"Erro ao obter alojamentos: {ex.Message}", ex);
            }
        }

       
        public List<Alojamento> GetAlojamentosDisponiveis()
        {
            try
            {
                return AlojamentoService.GetAlojamentos();
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter alojamentos disponiveis: {ex.Message}");
                throw new Exception($"Erro ao obter alojamentos disponíveis: {ex.Message}", ex);
            }
        }

       
        public Alojamento GetAlojamentoById(int id)
        {
            try
            {
                return AlojamentoService.getAlojamentoById(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter alojamentos com ID {id}: {ex.Message}");
                throw new Exception($"Erro ao obter alojamento com ID {id}: {ex.Message}", ex);
            }
        }


        public List<Alojamento> PesquisarAlojamentos(string pesquisa)
        {
            try
            {
                return AlojamentoService.Pesquisar(pesquisa);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao pesquisar alojamentos: {ex.Message}");
                throw new Exception($"Erro ao pesquisar alojamentos: {ex.Message}", ex);
            }
        }

  
        public List<Alojamento> FiltrarAlojamentos(string valorMin, string valorMax, string tipo, string comodidades)
        {
            try
            {
                return AlojamentoService.AplicarFiltros(valorMin, valorMax, tipo, comodidades);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao filtrar alojamentos: {ex.Message}");
                throw new Exception($"Erro ao filtrar alojamentos: {ex.Message}", ex);
            }
        }


        public int CriarAlojamento(Alojamento alojamento)
        {
            try
            {
                return AlojamentoService.CriarAlojamento(alojamento);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao criar alojamento: {ex.Message}");
                throw new Exception($"Erro ao criar alojamento: {ex.Message}", ex);
            }
        }


        public void AtualizarAlojamento(Alojamento alojamento)
        {
            try
            {
                AlojamentoService.AtualizarAlojamento(alojamento);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao atualizar alojamento: {ex.Message}");
                throw new Exception($"Erro ao atualizar alojamento: {ex.Message}", ex);
            }
        }
    }
}
