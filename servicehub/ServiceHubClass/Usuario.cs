using System;
using System.Collections.Generic;
using System.Data;
using ServicehubClass;

namespace ServiceHubClass
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public bool Ativo { get; set; }
        public Nivel? Nivel { get; set; }

        public Usuario()
        {
            Id = 0;
            Ativo = true;
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
            Nivel = nivel;
            Senha = senha;
            Ativo = ativo;
        }

        public Usuario(string? nome, string? email, Nivel? nivel, string? senha, bool ativo)
        {
            Nome = nome;
            Email = email;
            Nivel = nivel;
            Senha = senha;
            Ativo = ativo;
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                // Insere senha em texto puro

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"insert into usuarios (nome, email, senha, nivel_id, ativo)
                    values (@nome, @email, @senha, @nivel_id, @ativo);
                    select last_insert_id();";
                // Pegando senha como Variáveis
                cmd.Parameters.AddWithValue("@nome", Nome);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@senha", Senha);
                cmd.Parameters.AddWithValue("@nivel_id", Nivel?.Id ?? 1); 
                cmd.Parameters.AddWithValue("@ativo", Ativo);

                Id = Convert.ToInt32(cmd.ExecuteScalar()); // Retorna:  Select last_insert_is()
                cmd.Connection.Close();
            }
        }

        public bool Atualizar()
        {
            bool atualizado = false;
            if (Id < 1) return atualizado;

            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                // Atualiza todos os dados editaveis do usuario selecionado.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"update usuarios
                    set nome = @nome,
                        email = @email,
                        senha = @senha,
                        nivel_id = @nivel_id,
                        ativo = @ativo
                    where id = @id";

                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@nome", Nome);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@senha", Senha);
                cmd.Parameters.AddWithValue("@nivel_id", Nivel?.Id ?? 1);
                cmd.Parameters.AddWithValue("@ativo", Ativo);

                if (cmd.ExecuteNonQuery() > 0)
                    atualizado = true;

                cmd.Connection.Close();
            }

            return atualizado;
        }

        public static Usuario ObterPorId(int id)
        {
            Usuario user = new();
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                // A ordem das colunas acompanha a montagem do objeto Usuario abaixo.
                cmd.CommandText = @"select id, nome, email, senha, nivel_id, ativo
                    from usuarios
                    where id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    user = new(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        Nivel.ObterPorId(dr.GetInt32(4)),
                        dr.GetString(3),
                        dr.GetBoolean(5)
                    );
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return user;
        }

        public static List<Usuario> ObterLista(string busca = "")
        {
            List<Usuario> usuarios = new();
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                // Busca por nome ou email para alimentar o grid da tela.
                cmd.CommandText = @"select id, nome, email, senha, nivel_id, ativo
                    from usuarios
                    where nome like @busca or email like @busca
                    order by nome";
                cmd.Parameters.AddWithValue("@busca", $"%{busca}%");

                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuarios.Add(new(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        Nivel.ObterPorId(dr.GetInt32(4)),
                        dr.GetString(3),
                        dr.GetBoolean(5)
                    ));
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return usuarios;
        }

        public bool Autenticar()
        {
            bool autenticado = false;

            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                // Autenticacao simples: email e senha precisam bater e o usuario estar ativo.
                cmd.CommandText = @"select id, nome, email, senha, nivel_id, ativo
                    from usuarios
                    where email = @email and senha = @senha and ativo = 1";

                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@senha", Senha);

                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Id = dr.GetInt32(0);
                    Nome = dr.GetString(1);
                    Email = dr.GetString(2);
                    Senha = dr.GetString(3);
                    Nivel = Nivel.ObterPorId(dr.GetInt32(4));
                    Ativo = dr.GetBoolean(5);

                    autenticado = true;
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return autenticado;
        }

        public bool AlterarSenha()
        {
            bool alterado = false;

            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                // Mantido separado para permitir trocar senha sem mexer nos outros campos.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update usuarios set senha = @senha where id = @id";

                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@senha", Senha);

                if (cmd.ExecuteNonQuery() > 0)
                    alterado = true;

                cmd.Connection.Close();
            }

            return alterado;
        }

        public void Excluir()
        {
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                // Exclui fisicamente o registro; em sistemas reais seria comum apenas desativar.
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from usuarios where id = @id";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
    }
}
