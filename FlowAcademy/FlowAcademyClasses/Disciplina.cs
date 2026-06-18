using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAcademyClasses
{
    internal class Disciplina
    {
        // ====================================
        // PROPRIEDADES
        // Correspondem à tabela disciplinas
        // ====================================

        public int IdDisciplina { get; set; }

        public int IdCurso { get; set; }

        public string Nome { get; set; }

        public int CargaHoraria { get; set; }


        // ====================================
        // CONSTRUTOR VAZIO
        // ====================================

        public Disciplina()
        {

        }


        // ====================================
        // CONSTRUTOR COMPLETO
        // ====================================

        public Disciplina(
            int idDisciplina,
            int idCurso,
            string nome,
            int cargaHoraria)
        {
            IdDisciplina = idDisciplina;

            IdCurso = idCurso;

            Nome = nome;

            CargaHoraria = cargaHoraria;
        }


        // ====================================
        // INSERIR DISCIPLINA
        // Procedure:
        // sp_disciplina_inserir
        // ====================================

        public bool Inserir()
        {
            try
            {
                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_disciplina_inserir";


                cmd.Parameters.AddWithValue(
                    "p_id_curso",
                    IdCurso);

                cmd.Parameters.AddWithValue(
                    "p_nome",
                    Nome);

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
        // ALTERAR DISCIPLINA
        // ====================================

        public bool Alterar()
        {
            try
            {

                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_disciplina_alterar";


                cmd.Parameters.AddWithValue(
                    "p_id_disciplina",
                    IdDisciplina);

                cmd.Parameters.AddWithValue(
                    "p_id_curso",
                    IdCurso);

                cmd.Parameters.AddWithValue(
                    "p_nome",
                    Nome);

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
        // EXCLUIR DISCIPLINA
        // ====================================

        public bool Excluir()
        {

            try
            {

                var cmd = Banco.Abrir();

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.CommandText =
                    "sp_disciplina_excluir";


                cmd.Parameters.AddWithValue(
                    "p_id_disciplina",
                    IdDisciplina);


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
                    "sp_disciplina_consultar_id";


                cmd.Parameters.AddWithValue(
                    "p_id_disciplina",
                    IdDisciplina);


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
        // LISTAR TODAS AS DISCIPLINAS
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
                    "sp_disciplina_listar";


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
