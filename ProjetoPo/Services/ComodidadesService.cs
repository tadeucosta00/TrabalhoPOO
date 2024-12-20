using Logs;
using ProjetoPo.Models;

namespace ProjetoPo.Services
{
    public class ComodidadesService
    {
        private static readonly Logger logger = new Logger();

        public static List<Comodidades> GetAllComodidades()
        {
            try
            {
                List<Comodidades> comodidades = ComodidadesTable.GetComodidadesFromDB();
                return comodidades;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter comodidades: {ex.Message}");
                throw new Exception("Erro ao obter Comodidades.", ex);
            }
        }
    }
}
