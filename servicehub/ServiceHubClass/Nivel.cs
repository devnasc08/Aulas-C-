using ServicehubClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace ServiceHubClass
{
    public class Nivel
    {

        // Atributos | id nome sigla 

        //private int id;
        //private string? nome;
        //private string? sigla;


        // Propriedades
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sigla { get; set; }

        // Construtores (Métodos)
        public Nivel()
        {
            Id = 0;
        }

        public Nivel(int id)
        {
            Id = id;
        }

        public Nivel(string? nome, string? sigla )
        {
            Nome = nome;
            Sigla = sigla;
        }
        public Nivel(int id, string? nome, string? sigla)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
        }

         public bool Inserir()
        {
            bool inserido = true;
            if (Id < 1) return inserido;
            var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_nivel_insert";
                cmd.Parameters.AddWithValue("spnome", Nome);
                cmd.Parameters.AddWithValue("spsigla", Sigla);

            if (cmd.ExecuteNonQuery() > 0) inserido = true;
                cmd.Connection.Close();
            return inserido;

        }

        // Método ObterPorId
        public static Nivel ObterPorId(int id)
        {
            Nivel niv = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select * from niveis where id = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                niv = new(dr.GetInt32(0), dr.GetString(1), dr.GetString(2));
            }
            dr.Close();
            cmd.Connection.Close();
            return niv;
        }

        // Listar
        public static List<Nivel> ObterLista(string busca = "")
        {
            List<Nivel> niveis = new List<Nivel>();

            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                if (busca != "")
                {
                    cmd.CommandText = "Select * from niveis where nome like '%"+busca+"%' order by nome";
                }
                else
                {
                    cmd.CommandText = "Select * from niveis order by nome";
                }
                cmd.CommandType = CommandType.Text;
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    niveis.Add(new(dr.GetInt32(0), dr.GetString(1), dr.GetString(2) ?? ""));
                }
                dr.Close();
                cmd.Connection.Close();
            }
            return niveis;
        }

        public bool Update()
        {
            // Já deve ter propriedades com valores atribuídos antes de chamá-lo

            bool atualizada = false;
            if (Id < 1) return atualizada;
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_niveis_update";
            
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spsigla", Sigla);
            
            if (cmd.ExecuteNonQuery() > 0) atualizada = true;
            
            cmd.Connection.Close();
            
            return atualizada;
        }

        public void Excluir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_niveis_delete";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

    }
}
