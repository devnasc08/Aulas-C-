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


        public Usuario(int id, string? nome, string? email, string? senha, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Ativo = ativo;
        }

        public Usuario(int id, string? nome, string? email, Nivel? nivel, string? senha, bool ativo,)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Ativo = ativo;
            Nivel = nivel; 
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
            if (cmd.ExecuteNonQuery() > 0) ;
            atualizado = true;
            cmd.Connection.Close();
            return atualizado;
        }

    }
}
