using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using PlanilhaPatricia.Domain.Entidades;
using PlanilhaPatricia.Infra.Data.Database.DBSettings;

namespace PlanilhaPatricia.Infra.Data.DAO
{
    class ReservaDAO
    {
        public bool ReservarHorario(Reserva reserva)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT INTO RESERVA VALUES(@HorarioInicio, @HorarioFim, @IdSala, @IdFuncionario);";

                    ConverterObjetoEmSql(comando, reserva);

                    comando.CommandText = sql;

                    try
                    {
                        comando.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                        Console.ReadKey();

                        return false;
                    }
                }
            }

        }

        public List<Reserva> ValidarReserva(Reserva reserva)
        {
            List<Reserva> listaDeReservas = null;

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT R.*, F.NOME AS NOME_FUNCIONARIO, S.NOME AS NOME_SALA FROM RESERVA R INNER JOIN FUNCIONARIO F ON (R.ID_FUNCIONARIO = F.ID) INNER JOIN SALA S ON (R.ID_SALA = S.ID) WHERE HORARIO_INICIO <= @HorarioInicio AND HORARIO_FIM >= @HorarioInicio AND ID_SALA = @IdSala;";

                    comando.Parameters.AddWithValue("@HorarioInicio", reserva.HorarioInicio);
                    comando.Parameters.AddWithValue("@IdSala", reserva.IdSala);

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();

                        if (leitor.HasRows)
                            listaDeReservas = new List<Reserva>();

                        while (leitor.Read())
                        {
                            string nomeFuncionario = (leitor["NOME_FUNCIONARIO"].ToString() is null) ? String.Empty : leitor["NOME_FUNCIONARIO"].ToString();

                            Reserva novaReserva = new()
                            {
                                Id = int.Parse(leitor["ID"].ToString()),
                                HorarioInicio = DateTime.Parse(leitor["HORARIO_INICIO"].ToString()),
                                HorarioFim = DateTime.Parse(leitor["HORARIO_FIM"].ToString()),
                                IdSala = int.Parse(leitor["ID_SALA"].ToString()),
                                IdFuncionario = int.Parse(leitor["ID_FUNCIONARIO"].ToString()),
                                NomeFuncionario = nomeFuncionario,
                                NomeSala = leitor["NOME_SALA"].ToString(),
                            };

                            listaDeReservas.Add(novaReserva);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
            }

            return listaDeReservas;
        }

        private string BuscarNomeDoFuncionario(int idFuncionario)
        {
            string nome = String.Empty;

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM FUNCIONARIO WHERE ID = @IdFuncionario;";

                    comando.Parameters.AddWithValue("@IdFuncionario", idFuncionario);

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();

                        while (leitor.Read())
                        {
                            nome = leitor["NOME"].ToString();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
            }


            return nome;
        }

        private Reserva ConverterSqlEmObjeto(SqlDataReader leitor)
        {
            Reserva reserva = new();

            while (leitor.Read())
            {
                reserva.Id = int.Parse(leitor["ID"].ToString());
                reserva.IdSala = int.Parse(leitor["ID_SALA"].ToString());
                reserva.HorarioInicio = DateTime.Parse(leitor["HORARIO_INICIO"].ToString());
                reserva.HorarioFim = DateTime.Parse(leitor["HORARIO_FIM"].ToString());
                reserva.IdFuncionario = int.Parse(leitor["ID_FUNCIONARIO"].ToString());
            }

            return reserva;
        }

        private void ConverterObjetoEmSql(SqlCommand comando, Reserva reserva)
        {
            comando.Parameters.AddWithValue("@Id", reserva.Id);
            comando.Parameters.AddWithValue("@HorarioInicio", reserva.HorarioInicio);
            comando.Parameters.AddWithValue("@HorarioFim", reserva.HorarioFim);
            comando.Parameters.AddWithValue("@IdSala", reserva.IdSala);
            comando.Parameters.AddWithValue("@IdFuncionario", reserva.IdFuncionario);
        }
    }
}
