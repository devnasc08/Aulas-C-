using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Digests;
using ServicehubClass;

namespace ServiceHubClass
{
    public class Usuario
    {

        // Propriedades
        // id int, nome string, email string, senha string, ativo bool

        public int Id {get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public Nivel? Nivel { get; set; }

        public Usuario()
        {
            Id = 0;
        }

        public Usuario(int id)
        {
            Id = id;
        }

        public Usuario(int id, string? nome, string? email, string? senha, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Ativo = ativo;
        }

        public Usuario(int id, string? nome, string? email, Nivel? nivel, string? senha, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Ativo = ativo;
            Nivel = nivel;
            Senha = senha;
            Ativo = ativo;
        }

        public Usuario (string? nome, string? email, string? senha, bool ativo)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Ativo = ativo;
        }


        //  ===== Métodos =====

        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_usuario_inserir";

            cmd.Parameters.AddWithValue("sp_nome", Nome);
            cmd.Parameters.AddWithValue("sp_email", Email);
            cmd.Parameters.AddWithValue("sp_senha", Senha);
            cmd.Parameters.AddWithValue("sp_ativo", Ativo);

            Id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close(); 
        }

        public bool Atualizar()
        {
            bool atualizado = false;
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_usuario_update";

            cmd.Parameters.AddWithValue("spids", Id);
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("spsenha", Senha);
            cmd.Parameters.AddWithValue("spativo", Ativo);

            Id = Convert.ToInt32(cmd.ExecuteScalar());
            if (cmd.ExecuteNonQuery() > 0)
            atualizado = true;
            cmd.Connection.Close();
            return atualizado;
        }

        // ObterPorId
        public static Usuario ObterPorId(int id)
        {
            Usuario user = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = $"Select * from usuarios where id = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                user = new(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetBoolean(4));
            }
            dr.Close();
            cmd.Connection.Close();
            return user;

        }

        // ObterLista
        public static List<Usuario> ObterLista()
        {
            List<Usuario> usuarios = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"Select * from produtos order by nome";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                usuarios.Add(new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    Nivel.ObterPorId(dr.GetInt32(3)),
                    dr.GetString(4),
                    dr.GetBoolean(5)
                    )
                );
            }
            dr.Close();
            cmd.Connection.Close();
            return usuarios;
        } 


        // Autenticar

        public bool Autenticar()
        {
            bool autenticado = false;

            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "sp_usuario";

            cmd.Parameters.AddWithValue("sp_email", Email);
            cmd.Parameters.AddWithValue("sp_senha", Senha);

            var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Email = dr.GetString(2);
                Senha = dr.GetString(3);
                Ativo = dr.GetBoolean(4);

                autenticado = true;
            }
            dr.Close();
            cmd.Connection.Close();

            return autenticado;
        }


        // Alterar Senha

        public bool AlterarSenha()
        {
            bool alterado = false;

            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_usuario_altera";

            cmd.Parameters.AddWithValue("sp_id", Id);
            cmd.Parameters.AddWithValue("sp_senha", Senha);

            if(cmd.ExecuteNonQuery() > 0)
                alterado = true;

                cmd.Connection.Close();
                return alterado;
        }

    }
}
