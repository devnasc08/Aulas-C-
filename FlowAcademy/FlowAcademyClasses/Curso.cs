using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAcademyClasses
{
    internal class Curso
    {
        // ====================================
        // PROPRIEDADES
        // Correspondem à tabela cursos
        // ====================================

        public int IdCurso { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int CargaHoraria { get; set; }

        public string Status { get; set; }


        // ====================================
        // CONSTRUTOR VAZIO
        // ====================================

        public Curso()
        {

        }


        // ====================================
        // CONSTRUTOR COMPLETO
        // ====================================

        public Curso(
            int idCurso,
            string nome,
            string descricao,
            int cargaHoraria,
            string status)
        {
            IdCurso = idCurso;

            Nome = nome;

            Descricao = descricao;

            CargaHoraria = cargaHoraria;

            Status = status;
        }


        // ====================================
        // INSERIR CURSO
        // Chama a procedure:
        // sp_curso_inserir
        // ====================================

        public bool Inserir()
        {
            try
            {
                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_curso_inserir";


                cmd.Parameters.AddWithValue(
                    "p_nome",
                    Nome);

                cmd.Parameters.AddWithValue(
                    "p_descricao",
                    Descricao);

                cmd.Parameters.AddWithValue(
                    "p_carga_horaria",
                    CargaHoraria);


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
        // ALTERAR CURSO
        // ====================================

        public bool Alterar()
        {
            try
            {
                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_curso_alterar";


                cmd.Parameters.AddWithValue(
                    "p_id_curso",
                    IdCurso);

                cmd.Parameters.AddWithValue(
                    "p_nome",
                    Nome);

                cmd.Parameters.AddWithValue(
                    "p_descricao",
                    Descricao);

                cmd.Parameters.AddWithValue(
                    "p_carga_horaria",
                    CargaHoraria);

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
        // EXCLUIR CURSO
        // ====================================

        public bool Excluir()
        {
            try
            {
                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_curso_excluir";


                cmd.Parameters.AddWithValue(
                    "p_id_curso",
                    IdCurso);


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
        // CONSULTAR CURSO POR ID
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
                    "sp_curso_consultar_id";


                cmd.Parameters.AddWithValue(
                    "p_id_curso",
                    IdCurso);


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
        // LISTAR TODOS OS CURSOS
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
                    "sp_curso_listar";


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
