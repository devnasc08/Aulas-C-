using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Notice.Warning.Types;

namespace FlowAcademyClasses
{
    internal class Usuario
    {
        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nome, string email, string senha, string perfil, string status, DateTime ultimo_login, DateTime created_at)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            Senha = senha;
            Perfil = perfil;
            Status = status;
            Ultimo_login = ultimo_login;
            Created_at = created_at;
        }

        public Usuario(string email, string senha)
        { 

            Email = email;
            Senha = senha;
        }



        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public string Status { get; set; }
        public DateTime Ultimo_login { get; set; }
        public DateTime Created_at { get; set; }



        public bool Inserir()
        {

            var cmd = Banco.Abrir();


            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_inserir_usuario";


            cmd.Parameters.AddWithValue("p_nome", Nome);

            cmd.Parameters.AddWithValue("p_email", Email);

            cmd.Parameters.AddWithValue("p_senha", Senha);

            cmd.Parameters.AddWithValue("p_perfil", Perfil);

            cmd.Parameters.AddWithValue("p_status", Status);


            return cmd.ExecuteNonQuery() > 0;

        }


        // ====================
        // ATUALIZAR
        // ====================

        public bool Atualizar()
        {

            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_atualizar_usuario";


            cmd.Parameters.AddWithValue("p_id", IdUsuario);

            cmd.Parameters.AddWithValue("p_nome", Nome);

            cmd.Parameters.AddWithValue("p_email", Email);

            cmd.Parameters.AddWithValue("p_senha", Senha);

            cmd.Parameters.AddWithValue("p_perfil", Perfil);

            cmd.Parameters.AddWithValue("p_status", Status);


            return cmd.ExecuteNonQuery() > 0;

        }


        // ====================
        // EXCLUIR
        // ====================

        public bool Excluir()
        {

            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_excluir_usuario";

            cmd.Parameters.AddWithValue("p_id", IdUsuario);


            return cmd.ExecuteNonQuery() > 0;

        }


        // ====================
        // LISTAR
        // ====================

        public List<Usuario> ObterListar()
        {

            List<Usuario> user= new ();

            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = $"select * from usuarios order by nome";

            var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                user.Add(new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4),
                    dr.GetString(5),
                    dr.GetDateTime(6),
                    dr.GetDateTime(7)
                    ));
            }
            dr.Close();
            cmd.Connection.Close();
            return user;
        }
    }
}
