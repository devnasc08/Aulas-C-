using ServicehubClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ServiceHubClass
{
    internal class Estoque
    {
        public int ProdutoId { get; set; } 
        public decimal Quantidade { get; set; } 
        public DateTime DataUltimoMovimento{ get; set; } 
        public Estoque(decimal quantidade, DateTime dataUltimoMovimento, int produtoId)
        {
            Quantidade = quantidade;
            DataUltimoMovimento = dataUltimoMovimento;
            ProdutoId = produtoId;
        }
         public Estoque()
        {

        }

        public bool Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_estoque_insert";

            cmd.Parameters.AddWithValue("spproduto_id", ProdutoId);
            cmd.Parameters.AddWithValue("spquantidade", Quantidade);

            ProdutoId = Convert.ToInt32(value: cmd.ExecuteScalar());

            cmd.Connection.Close();
            return ProdutoId > 0;
        }

        public bool atualizar()
        {
            bool atualizado = false;
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_estoque_update";

            cmd.Parameters.AddWithValue("spproduto_id", ProdutoId);
            cmd.Parameters.AddWithValue("spquantidade", Quantidade);

            if (cmd.ExecuteNonQuery() > 0)
                atualizado = true;
            cmd.Connection.Close();
            return atualizado;

        }
        
        public Estoque ObterPorId(int id)
        {
            Estoque est = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select * from estoque where id = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                est = new(
                    dr.GetInt32(0),
                    dr.GetDecimal(1), 
                    dr.GetDateTime(2)
                    );

            }
            dr.Close();
            cmd.Connection.Close();
            return est;
        }

        public static List<Estoque> ObterLista()
        {

        }

        public bool EntradaProduto()
        {

        }

        public bool SaidaProduto()
        {

        }
        
    
    
    
    }
}
