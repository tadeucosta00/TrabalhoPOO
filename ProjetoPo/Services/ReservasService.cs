using Logs;
using ProjetoPo.Models;
using System;
using System.Collections.Generic;

namespace ProjetoPo.Services
{
    public static class ReservasService
    {
        private static readonly Logger logger = new Logger();

        public static List<Reserva> GetAllReserva()
        {
            try
            {
                List<Reserva> reservas = ReservasTable.GetAllReservasFromDB();
                return reservas;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter todas as reservas: {ex.Message}");
                throw new Exception("Erro a obter Reservas.", ex);
            }
        }

        public static Reserva getReservaById(int idReserva)
        {
            try
            {
                Reserva reserva = ReservasTable.GetReservaById(idReserva);
                return reserva;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter reserva com ID {idReserva}: {ex.Message}");
                throw new Exception("Erro a obter Reserva.", ex);
            }
        }

        public static List<Reserva> GetReservaByUserId(int userId)
        {
            try
            {
                List<Reserva> reservas = ReservasTable.GetReservaByUserId(userId);
                return reservas;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter reservas para o usuário com ID {userId}: {ex.Message}");
                throw new Exception("Erro a obter Reservas.", ex);
            }
        }

        public static void CheckIn(Reserva reserva)
        {
            try
            {
                if (reserva.CheckIN)
                {
                    throw new ArgumentException("Check-In já realizado!.");
                }
                reserva.CheckIN = true;
                ReservasTable.CheckInReservaNaDB(reserva);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao realizar Check-In para a reserva com ID {reserva.Id}: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        public static void Reservar(Reserva reserva)
        {
            try
            {
                if (reserva.Hospedes <= 0)
                {
                    throw new Exception("Por favor, preencha o número de hóspedes.");
                }

                TimeSpan diferenca = reserva.DataCheckOut - reserva.DataCheckIn;
                int numeroDeDias = diferenca.Days;

                if (numeroDeDias <= 0)
                {
                    throw new Exception("A data de Check-Out deve ser posterior à data de Check-In.");
                }

                reserva.ValorTotal = ReservasTable.CalcularValorTotal(reserva);
                ReservasTable.AdcionarReservaNaDB(reserva);
                MessageBox.Show("Reserva efetuada com sucesso!");
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao efetuar reserva: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        public static void AtualizarReserva(Reserva reserva)
        {
            try
            {
                if (reserva.Hospedes <= 0)
                {
                    throw new Exception("Por favor, preencha o número de hóspedes.");
                }

                TimeSpan diferenca = reserva.DataCheckOut - reserva.DataCheckIn;
                int numeroDeDias = diferenca.Days;

                if (numeroDeDias <= 0)
                {
                    throw new Exception("A data de Check-Out deve ser posterior à data de Check-In.");
                }

                reserva.ValorTotal = ReservasTable.CalcularValorTotal(reserva);
                ReservasTable.AtualizarReservaNaDB(reserva);
                MessageBox.Show("Reserva atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao atualizar reserva com ID {reserva.Id}: {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
