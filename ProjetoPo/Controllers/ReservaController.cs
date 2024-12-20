using Logs;
using Microsoft.VisualBasic.ApplicationServices;
using ProjetoPo.Models;
using ProjetoPo.Services;
using System;
using System.Collections.Generic;

namespace ProjetoPo.Controllers
{
    public class ReservasController
    {
        private readonly Logger logger;

        public ReservasController()
        {
            logger = new Logger();
        }
        public List<Reserva> GetAllReservas()
        {
            try
            {
                return ReservasService.GetAllReserva();
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter reservas: {ex.Message}");
                throw new Exception($"Erro ao obter reservas: {ex.Message}", ex);
            }
        }

        public Reserva GetReservaById(int idReserva)
        {
            try
            {
                return ReservasService.getReservaById(idReserva);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter reserva com ID {idReserva}: {ex.Message}");
                throw new Exception($"Erro ao obter a reserva com ID {idReserva}: {ex.Message}", ex);
            }
        }

        public List<Reserva> GetReservasByUserId(int userId)
        {
            try
            {
                return ReservasService.GetReservaByUserId(userId);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter reservas utilizador com ID {userId}: {ex.Message}");
                throw new Exception($"Erro ao obter reservas do utilizador com ID {userId}: {ex.Message}", ex);
            }
        }

        public void CheckIn(Reserva reserva)
        {
            try
            {
                ReservasService.CheckIn(reserva);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao realizar check-in: {ex.Message}");
                throw new Exception($"Erro ao realizar o check-in: {ex.Message}", ex);
            }
        }

        public void CriarReserva(Reserva reserva)
        {
            try
            {
                ReservasService.Reservar(reserva);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao criar reserva: {ex.Message}");
                throw new Exception($"Erro ao criar reserva: {ex.Message}", ex);
            }
        }

        public void AtualizarReserva(Reserva reserva)
        {
            try
            {
                ReservasService.AtualizarReserva(reserva);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao atualizar reserva: {ex.Message}");
                throw new Exception($"Erro ao atualizar reserva: {ex.Message}", ex);
            }
        }
    }
}
