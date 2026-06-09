using ServicehubClass;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Data;

namespace ServiceHubClass

{

    public class Produto

    {

        // propriedades

        public int Id { get; set; }

        public string? CodBarras { get; set; }

        public string? Descricao { get; set; }

        public double ValorUnit { get; set; }

        public string? UnidadeVenda { get; set; }

        public Categoria? Categoria { get; set; }

        public double EstoqueMinimo { get; set; }

        public double ClasseDesconto { get; set; }

        public byte[] Imagem { get; set; }

        public DateTime DataCad { get; set; }

        public bool Descontinuado { get; set; }


        public Produto(string? codBarras, string? descricao, double valorUnit, string? unidadeVenda, Categoria? categoria, double estoqueMinimo, double classeDesconto)

        {

            CodBarras = codBarras;

            Descricao = descricao;

            ValorUnit = valorUnit;

            UnidadeVenda = unidadeVenda;

            Categoria = categoria;

            EstoqueMinimo = estoqueMinimo;

            ClasseDesconto = classeDesconto;

        }


        public Produto(int id, string? codBarras, string? descricao, double valorUnit, string? unidadeVenda, Categoria? categoria, double estoqueMinimo, double classeDesconto, byte[] imagem, DateTime dataCad, bool descontinuado)

        {

            Id = id;

            CodBarras = codBarras;

            Descricao = descricao;

            ValorUnit = valorUnit;

            UnidadeVenda = unidadeVenda;

            Categoria = categoria;

            EstoqueMinimo = estoqueMinimo;

            ClasseDesconto = classeDesconto;

            Imagem = imagem;

            DataCad = dataCad;

            Descontinuado = descontinuado;

        }



        // Métodos (Inserir/BuscarPorId/ObterLista(texto="")/Atualizar)

        public void Inserir()

        {

            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_produto_insert";

            cmd.Parameters.AddWithValue("spcod_barras", CodBarras);

            cmd.Parameters.AddWithValue("spdescricao", Descricao);

            cmd.Parameters.AddWithValue("spvalor_unit", ValorUnit);

            cmd.Parameters.AddWithValue("spunidade_venda", UnidadeVenda);

            cmd.Parameters.AddWithValue("spcategoria_id", Categoria.Id);

            cmd.Parameters.AddWithValue("spestoque_minimo", EstoqueMinimo);

            cmd.Parameters.AddWithValue("spclasse_desconto", ClasseDesconto);

            Id = Convert.ToInt32(value: cmd.ExecuteScalar());

            cmd.Connection.Close();

        }


        public bool Atualizar()

        {
            bool atualizado = false;
           
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_produto_update";

            cmd.Parameters.AddWithValue("spids", Id);

            cmd.Parameters.AddWithValue("spcod_barras", CodBarras);

            cmd.Parameters.AddWithValue("spdescricao", Descricao);

            cmd.Parameters.AddWithValue("spvalor_unit", ValorUnit);

            cmd.Parameters.AddWithValue("spunidade_venda", UnidadeVenda);

            cmd.Parameters.AddWithValue("spcategoria_id", Categoria.Id);

            cmd.Parameters.AddWithValue("spestoque_minimo", EstoqueMinimo);

            cmd.Parameters.AddWithValue("spclasse_desconto", ClasseDesconto);

            Id = Convert.ToInt32(cmd.ExecuteScalar());
            if(cmd.ExecuteNonQuery() > 0)
            atualizado = true;
            cmd.Connection.Close();
            return atualizado;
        }

        public static List <Produto> ObterPorId()
        {
            List<Produto> produtos = new();
            //Produto produto = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select * from produtos order by descricao";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                produtos.Add(new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetDouble(3),
                    dr.GetString(4),
                    Categoria.ObterPorId(dr.GetInt32(5)),
                    dr.GetDouble(6),
                    dr.GetDouble(7),
                    //(byte[])dr.GetValue(8)??null,
                    // dr.GetBytes(8)??null,
                    null,
                    dr.GetDateTime(9),
                    dr.GetBoolean(10)
                    )
                );

            }
            dr.Close();
            cmd.Connection.Close();
            return produtos;
        }

        public static List<Produto> ObterLista()
        {
            List<Produto> produtos = new(); //Vazio
            //Produto produto = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select * from produtos order by descricao";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                produtos.Add(new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetDouble(3),
                    dr.GetString(4),
                    Categoria.ObterPorId(dr.GetInt32(5)),
                    dr.GetDouble(6),
                    dr.GetDouble(7),
                    //(byte[])dr.GetValue(8)??null,
                    // dr.GetBytes(8)??null,
                    null,
                    dr.GetDateTime(9),
                    dr.GetBoolean(10)
                    )
                );

            }
            dr.Close();
            cmd.Connection.Close();
            return produtos;
        }


    }

}

