using Logs;
using ProjetoPo.Services;
using ProjetoPo.Models;
using System;
using System.Collections.Generic;

namespace ProjetoPo.Controllers
{
    public class ComodidadesController
    {
        private readonly Logger logger;

        public ComodidadesController()
        {
            logger = new Logger();
        }
        public List<Comodidades> GetAllComodidades()
        {
            try
            {
                return ComodidadesService.GetAllComodidades();
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter comodidades: {ex.Message}");
                throw new Exception($"Erro ao obter comodidades: {ex.Message}", ex);
            }
        }
    }
}
