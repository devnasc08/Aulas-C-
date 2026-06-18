using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAcademyClasses
{
    public class Frequencia
    {
        // ====================================
        // PROPRIEDADES
        // Correspondem à tabela frequencia
        // ====================================

        public int IdFrequencia { get; set; }

        public int IdMatricula { get; set; }

        public int IdDisciplina { get; set; }

        public int TotalAulas { get; set; }

        public int Presencas { get; set; }

        public decimal Percentual { get; set; }



        // ====================================
        // CONSTRUTOR VAZIO
        // ====================================

        public Frequencia()
        {

        }



        // ====================================
        // CONSTRUTOR COMPLETO
        // ====================================

        public Frequencia(
            int idFrequencia,
            int idMatricula,
            int idDisciplina,
            int totalAulas,
            int presencas,
            decimal percentual)
        {

            IdFrequencia = idFrequencia;

            IdMatricula = idMatricula;

            IdDisciplina = idDisciplina;

            TotalAulas = totalAulas;

            Presencas = presencas;

            Percentual = percentual;

        }



        // ====================================
        // CALCULAR PERCENTUAL
        // Fórmula:
        // (Presencas * 100) / TotalAulas
        // ====================================

        public void CalcularPercentual()
        {

            if (TotalAulas > 0)
            {

                Percentual =
                    (Presencas * 100m)
                    / TotalAulas;

            }

            else
            {

                Percentual = 0;

            }

        }



        // ====================================
        // INSERIR FREQUÊNCIA
        // ====================================

        public bool Inserir()
        {

            try
            {

                CalcularPercentual();

                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_frequencia_inserir";


                cmd.Parameters.AddWithValue(
                    "p_id_matricula",
                    IdMatricula);

                cmd.Parameters.AddWithValue(
                    "p_id_disciplina",
                    IdDisciplina);

                cmd.Parameters.AddWithValue(
                    "p_total_aulas",
                    TotalAulas);

                cmd.Parameters.AddWithValue(
                    "p_presencas",
                    Presencas);

                cmd.Parameters.AddWithValue(
                    "p_percentual",
                    Percentual);


                cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                return true;

            }

            catch
            {

                return false;

            }

        }



        // ====================================
        // ALTERAR FREQUÊNCIA
        // ====================================

        public bool Alterar()
        {

            try
            {

                CalcularPercentual();

                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_frequencia_alterar";


                cmd.Parameters.AddWithValue(
                    "p_id_frequencia",
                    IdFrequencia);

                cmd.Parameters.AddWithValue(
                    "p_total_aulas",
                    TotalAulas);

                cmd.Parameters.AddWithValue(
                    "p_presencas",
                    Presencas);

                cmd.Parameters.AddWithValue(
                    "p_percentual",
                    Percentual);


                cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                return true;

            }

            catch
            {

                return false;

            }

        }



        // ====================================
        // EXCLUIR FREQUÊNCIA
        // ====================================

        public bool Excluir()
        {

            try
            {

                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_frequencia_excluir";


                cmd.Parameters.AddWithValue(
                    "p_id_frequencia",
                    IdFrequencia);


                cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                return true;

            }

            catch
            {

                return false;

            }

        }



        // ====================================
        // CONSULTAR POR ID
        // ====================================

        public DataTable ConsultarPorId()
        {

            DataTable dt =
                new DataTable();

            try
            {

                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_frequencia_consultar_id";


                cmd.Parameters.AddWithValue(
                    "p_id_frequencia",
                    IdFrequencia);


                MySqlDataAdapter da =
                    new MySqlDataAdapter(cmd);

                da.Fill(dt);

                cmd.Connection.Close();

            }

            catch
            {

            }

            return dt;

        }



        // ====================================
        // LISTAR TODAS AS FREQUÊNCIAS
        // ====================================

        public static DataTable Listar()
        {

            DataTable dt =
                new DataTable();

            try
            {

                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_frequencia_listar";


                MySqlDataAdapter da =
                    new MySqlDataAdapter(cmd);

                da.Fill(dt);

                cmd.Connection.Close();

            }

            catch
            {

            }

            return dt;

        }





    }
}
