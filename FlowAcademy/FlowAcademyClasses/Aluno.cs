using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAcademyClasses
{
    public class Aluno
    {
        public Aluno(int idUsuario, string nome, string email, string senhaHash, string perfil, string status, DateTime? ultimoLogin, DateTime createdAt)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Perfil = perfil;
            Status = status;
            UltimoLogin = ultimoLogin;
            CreatedAt = createdAt;
        }

        public Aluno()
        {

        }

        public int IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string SenhaHash { get; set; }

        public string Perfil { get; set; }

        public string Status { get; set; }

        public DateTime? UltimoLogin { get; set; }

        public DateTime CreatedAt { get; set; }


        // ========================================
        // INSERIR USUÁRIO
        // Chama a procedure sp_usuario_inserir
        // ========================================

        public bool Inserir()
        {
            try
            {
                var cmd = Banco.Abrir();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_usuario_inserir";


                cmd.Parameters.AddWithValue("p_nome", Nome);

                cmd.Parameters.AddWithValue("p_email", Email);

                cmd.Parameters.AddWithValue("p_senha_hash", SenhaHash);

                cmd.Parameters.AddWithValue("p_perfil", Perfil);


                cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                return true;
            }

            catch
            {
                return false;
            }
        }


        // ========================================
        // ALTERAR USUÁRIO
        // ========================================

        public bool Alterar()
        {
            try
            {
                var cmd = Banco.Abrir();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_usuario_alterar";


                cmd.Parameters.AddWithValue("p_id_usuario", IdUsuario);

                cmd.Parameters.AddWithValue("p_nome", Nome);

                cmd.Parameters.AddWithValue("p_email", Email);

                cmd.Parameters.AddWithValue("p_perfil", Perfil);

                cmd.Parameters.AddWithValue("p_status", Status);


                cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                return true;
            }

            catch
            {
                return false;
            }
        }


        // ========================================
        // EXCLUIR USUÁRIO
        // ========================================

        public bool Excluir()
        {
            try
            {
                var cmd = Banco.Abrir();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_usuario_excluir";

                cmd.Parameters.AddWithValue("p_id_usuario", IdUsuario);


                cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                return true;
            }

            catch
            {
                return false;
            }
        }


        // ========================================
        // CONSULTAR POR ID
        // Retorna um DataTable
        // ========================================

        public DataTable ConsultarPorId()
        {
            DataTable dt = new DataTable();

            try
            {
                var cmd = Banco.Abrir();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_usuario_consultar_id";


                cmd.Parameters.AddWithValue(
                    "p_id_usuario",
                    IdUsuario
                );


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


        // ========================================
        // LISTAR TODOS
        // ========================================

        public static DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                var cmd = Banco.Abrir();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_usuario_listar";


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