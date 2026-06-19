using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Usuario
    {
        // Propriedades
        public int IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? NivelAcesso { get; set; } // 'administrador', 'professor', 'aluno'
        public string? Status { get; set; }
        public DateTime DataCriacao { get; set; }

        // Construtor vazio
        public Usuario()
        {
            IdUsuario = 0;
            Nome = "";
            Email = "";
            Senha = "";
            NivelAcesso = "aluno";
            Status = "ativo";
            DataCriacao = DateTime.Now;
        }

        // Construtor com ID
        public Usuario(int idUsuario)
        {
            IdUsuario = idUsuario;
        }

        // Construtor completo
        public Usuario(int idUsuario, string? nome, string? email, string? senha, string? nivelAcesso, string? status, DateTime dataCriacao)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            Senha = senha;
            NivelAcesso = nivelAcesso;
            Status = status;
            DataCriacao = dataCriacao;
        }

        // ==========================
        // INSERIR
        // ==========================
        public bool Inserir()
        {
            bool inserido = false;
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_insert";

                cmd.Parameters.AddWithValue("spnome", Nome);
                cmd.Parameters.AddWithValue("spemail", Email);
                cmd.Parameters.AddWithValue("spsenha", Senha); // Idealmente criptografada
                cmd.Parameters.AddWithValue("spnivelacesso", NivelAcesso);
                cmd.Parameters.AddWithValue("spstatus", Status);

                IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());
                inserido = IdUsuario > 0;

                cmd.Connection.Close();
            }

            return inserido;
        }

        // ==========================
        // ATUALIZAR
        // ==========================
        public bool Atualizar()
        {
            bool atualizado = false;
            if (IdUsuario < 1) return atualizado;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_update";

                cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
                cmd.Parameters.AddWithValue("spnome", Nome);
                cmd.Parameters.AddWithValue("spemail", Email);
                cmd.Parameters.AddWithValue("spsenha", Senha);
                cmd.Parameters.AddWithValue("spnivelacesso", NivelAcesso);
                cmd.Parameters.AddWithValue("spstatus", Status);

                if (cmd.ExecuteNonQuery() > 0)
                    atualizado = true;

                cmd.Connection.Close();
            }

            return atualizado;
        }

        // ==========================
        // EXCLUIR
        // ==========================
        public bool Excluir()
        {
            bool excluido = false;
            if (IdUsuario < 1) return excluido;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_delete";

                cmd.Parameters.AddWithValue("spidusuario", IdUsuario);

                if (cmd.ExecuteNonQuery() > 0)
                    excluido = true;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Usuario ObterPorId(int idUsuario)
        {
            Usuario usuario = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_getbyid";
                cmd.Parameters.AddWithValue("spidusuario", idUsuario);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    usuario = new Usuario(
                        dr.GetInt32(0),
                        dr.IsDBNull(1) ? null : dr.GetString(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3),
                        dr.IsDBNull(4) ? null : dr.GetString(4),
                        dr.IsDBNull(5) ? null : dr.GetString(5),
                        dr.GetDateTime(6)
                    );
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return usuario;
        }

        // ==========================
        // LISTAR
        // ==========================
        public static List<Usuario> ObterLista()
        {
            List<Usuario> usuarios = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_getall";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    usuarios.Add(new Usuario(
                        dr.GetInt32(0),
                        dr.IsDBNull(1) ? null : dr.GetString(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3),
                        dr.IsDBNull(4) ? null : dr.GetString(4),
                        dr.IsDBNull(5) ? null : dr.GetString(5),
                        dr.GetDateTime(6)
                    ));
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return usuarios;
        }

        // Efetua login validando as credenciais por procedure externa
        public static Usuario EfetuarLogin(string email, string senha)
        {
            Usuario usuario = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_login";
                cmd.Parameters.AddWithValue("spemail", email);
                cmd.Parameters.AddWithValue("spsenha", senha);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    usuario = new Usuario(
                        dr.GetInt32(0),
                        dr.IsDBNull(1) ? null : dr.GetString(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3),
                        dr.IsDBNull(4) ? null : dr.GetString(4),
                        dr.IsDBNull(5) ? null : dr.GetString(5),
                        dr.GetDateTime(6)
                    );
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return usuario;
        }
    }
}