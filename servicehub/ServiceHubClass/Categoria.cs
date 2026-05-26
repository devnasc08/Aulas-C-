using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ServicehubClass;

using System.Data;

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



    }
}
