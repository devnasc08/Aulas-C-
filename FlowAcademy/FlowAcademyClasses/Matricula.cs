using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAcademyClasses
{
    internal class Matricula
    {

        // ====================================
        // PROPRIEDADES
        // Correspondem à tabela matriculas
        // ====================================

        public int IdMatricula { get; set; }

        public int IdAluno { get; set; }

        public int IdTurma { get; set; }

        public DateTime DataMatricula { get; set; }

        public string Status { get; set; }



        // ====================================
        // CONSTRUTOR VAZIO
        // ====================================

        public Matricula()
        {

        }



        // ====================================
        // CONSTRUTOR COMPLETO
        // ====================================

        public Matricula(
            int idMatricula,
            int idAluno,
            int idTurma,
            DateTime dataMatricula,
            string status)
        {

            IdMatricula = idMatricula;

            IdAluno = idAluno;

            IdTurma = idTurma;

            DataMatricula = dataMatricula;

            Status = status;

        }



        // ====================================
        // INSERIR MATRÍCULA
        // ====================================

        public bool Inserir()
        {

            try
            {

                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_matricula_inserir";


                cmd.Parameters.AddWithValue(
                    "p_id_aluno",
                    IdAluno);

                cmd.Parameters.AddWithValue(
                    "p_id_turma",
                    IdTurma);

                cmd.Parameters.AddWithValue(
                    "p_data_matricula",
                    DataMatricula);

                cmd.Parameters.AddWithValue(
                    "p_status",
                    Status);


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
        // ALTERAR MATRÍCULA
        // ====================================

        public bool Alterar()
        {

            try
            {

                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_matricula_alterar";


                cmd.Parameters.AddWithValue(
                    "p_id_matricula",
                    IdMatricula);

                cmd.Parameters.AddWithValue(
                    "p_id_aluno",
                    IdAluno);

                cmd.Parameters.AddWithValue(
                    "p_id_turma",
                    IdTurma);

                cmd.Parameters.AddWithValue(
                    "p_data_matricula",
                    DataMatricula);

                cmd.Parameters.AddWithValue(
                    "p_status",
                    Status);


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
        // EXCLUIR MATRÍCULA
        // ====================================

        public bool Excluir()
        {

            try
            {

                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_matricula_excluir";


                cmd.Parameters.AddWithValue(
                    "p_id_matricula",
                    IdMatricula);


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
                    "sp_matricula_consultar_id";


                cmd.Parameters.AddWithValue(
                    "p_id_matricula",
                    IdMatricula);


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
        // LISTAR TODAS AS MATRÍCULAS
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
                    "sp_matricula_listar";


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
