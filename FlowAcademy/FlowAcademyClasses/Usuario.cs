using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Usuario
    {
        // ==========================
        // PROPRIEDADES
        // ==========================
        public int IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? NivelAcesso { get; set; }
        public string? Status { get; set; }
        public DateTime DataCriacao { get; set; }

        // ==========================
        // CONSTRUTOR
        // ==========================
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

        public Usuario(int idUsuario, string? nome, string? email,
                       string? senha, string? nivelAcesso,
                       string? status, DateTime dataCriacao)
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
            if (string.IsNullOrEmpty(Nome)) return false;
            if (string.IsNullOrEmpty(Email)) return false;
            if (string.IsNullOrEmpty(Senha)) return false;

            bool inserido = false;
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_inserir_usuario";

                cmd.Parameters.AddWithValue("p_nome", Nome);
                cmd.Parameters.AddWithValue("p_email", Email);
                cmd.Parameters.AddWithValue("p_senha", Senha);
                cmd.Parameters.AddWithValue("p_perfil", NivelAcesso);
                cmd.Parameters.AddWithValue("p_status", Status);

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
            if (IdUsuario < 1) return false;

            bool atualizado = false;
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_atualizar_usuario";

                cmd.Parameters.AddWithValue("p_id", IdUsuario);
                cmd.Parameters.AddWithValue("p_nome", Nome);
                cmd.Parameters.AddWithValue("p_email", Email);
                cmd.Parameters.AddWithValue("p_senha", Senha);
                cmd.Parameters.AddWithValue("p_perfil", NivelAcesso);
                cmd.Parameters.AddWithValue("p_status", Status);

                atualizado = cmd.ExecuteNonQuery() > 0;

                cmd.Connection.Close();
            }

            return atualizado;
        }

        // ==========================
        // EXCLUIR
        // ==========================
        public bool Excluir()
        {
            if (IdUsuario < 1) return false;

            bool excluido = false;
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_excluir_usuario";

                cmd.Parameters.AddWithValue("p_id", IdUsuario);

                excluido = cmd.ExecuteNonQuery() > 0;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Usuario ObterPorId(int id)
        {
            Usuario usuario = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
                SELECT id_usuario, nome, email, senha_hash,
                       perfil, status, created_at
                FROM usuarios
                WHERE id_usuario = @id";

                cmd.Parameters.AddWithValue("@id", id);

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
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
                SELECT id_usuario, nome, email, senha_hash,
                       perfil, status, created_at
                FROM usuarios";

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

        // ==========================
        // LOGIN
        // ==========================
        public static Usuario EfetuarLogin(string email, string senha)
        {
            Usuario usuario = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_login";

                cmd.Parameters.AddWithValue("p_email", email);
                cmd.Parameters.AddWithValue("p_senha", senha);

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
