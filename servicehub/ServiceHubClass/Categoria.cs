using System;
using System.Collections.Generic; // List<T> está aqui
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ServicehubClass; 
using System.Data;
// ConnectionState está aqui! 


namespace ServiceHubClass
{
    public class Categoria
    {
        // Atributos (Campos)
        /*
        private int id;
        private string? nome;
        private string? sigla;
        readonly = SOMENTE LEITURA
        */

        // Propriedades | Criando Diretamente
        public int Id { get; set; }
        public string? Nome { get ; set; }
        public string? Sigla { get; set; }
        

        // Construtores (Métodos)
        public Categoria() 
        {
            Id = 0;
        }

        public Categoria(string? nome, string? sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }

        public Categoria(int id, string? nome, string? sigla)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
        }


        // Métodos (Funcionalidades - RFs) - Inserir, Atualizar, Listar, obterPorId(id), Excluir(id)
        
        // Não Retorna valor    
        public void Inserir()
        {
            // O método é chamado

            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_categoria_insert";
                cmd.Parameters.AddWithValue("spnome", Nome);
                cmd.Parameters.AddWithValue("spsigla", Sigla);
                Id = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Connection.Close();
            }
        }

        public static Categoria ObterPorId(int id)
        {
            Categoria cat = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select * from categorias where id = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                // 
                cat = new(dr.GetInt32(0), dr.GetString(1), dr.GetString(2));
            }
            dr.Close();
            cmd.Connection.Close();
            return cat;
        }


        // Método Listar
        public static List<Categoria> ObterLista(string busca = "")
        {
            // Lista categorias só suporta objetos do tipo categoria
            List<Categoria> categorias = new List<Categoria>();
            //Retorna um objeto mysql comand 
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                if (busca != "")
                {
                    cmd.CommandText = "Select * from categorias " +
                        "where nome like '%"+busca+"%' order by nome";
                    
                }
                else
                {
                    cmd.CommandText = "Select * from categorias order by nome";
                }
                cmd.CommandType = CommandType.Text;
                var dr = cmd.ExecuteReader();
                while (dr.Read()) //Enquanto
                {
                    categorias.Add(new(dr.GetInt32(0),dr.GetString(1),dr.GetString(2)??""));
                        
                }
                dr.Close();
                cmd.Connection.Close();
            }
            return categorias;
        }

        public bool Atualizar() {
        // Como este método não é estático, precisamos considerar 
        // que as propriedades já possuam valores atribuídos antes de chamá-lo

        bool atualizada = false;
        if (Id < 1) return atualizada;
        var cmd = Banco.Abrir();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_categoria_update";
        //cmd.Parameters.Add("spid", MySqlDbType.Int32).Value = Id;
        cmd.Parameters.AddWithValue("spid", Id);
        cmd.Parameters.AddWithValue("spnome", Nome);
        cmd.Parameters.AddWithValue("spsigla", Sigla);
        if (cmd.ExecuteNonQuery() > 0) atualizada = true;
        cmd.Connection.Close();
        return atualizada;
        }

        public void Excluir(int id)
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_categoria_delete";
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }




    }
}
