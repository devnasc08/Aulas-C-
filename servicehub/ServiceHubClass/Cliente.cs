using ServicehubClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ServiceHubClass
{
    internal class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateOnly Data_nasc{ get; set; }
        public DateTime Data_cad { get; set; }
        public bool ativo { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public List<Endereco> Enderecos { get; set; }





        public Cliente()
        {
            Pedidos = new List<Pedido>();
            Enderecos = new List<Endereco>();

        }

        public Cliente(int id, string? nome, string? cpf, string? telefone, string? email, DateOnly data_nasc, DateTime data_cad, bool ativo, List<Pedido> pedidos, List<Endereco> enderecos)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Data_nasc = data_nasc;
            Data_cad = data_cad;
            this.ativo = ativo;
            Pedidos = pedidos;
            Enderecos = enderecos;
        }
        public Cliente(string? nome, string? cpf, string? telefone, string? email, DateOnly data_nasc, DateTime data_cad, bool ativo, List<Pedido> pedidos, List<Endereco> enderecos)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Data_nasc = data_nasc;
            Data_cad = data_cad;
            this.ativo = ativo;
            Pedidos = pedidos;
            Enderecos = enderecos;
        }

        public Cliente(int id, string? nome, string? cpf, string? telefone, string? email, DateOnly data_nasc, DateTime data_cad, bool ativo)
        {
            Id = Id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Data_nasc = data_nasc;
            Data_cad = data_cad;
            this.ativo = ativo;
        }




        public bool Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_cliente_insert";

            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spcpf", Cpf);
            cmd.Parameters.AddWithValue("sptelefone", Telefone);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("spdatanasc", Data_nasc);
            cmd.Parameters.AddWithValue("spdatanasc", Data_nasc);
            

            Id = Convert.ToInt32(value: cmd.ExecuteScalar());

            cmd.Connection.Close();
            return Id > 0;
        }


        public bool Atualizar()
        {
            bool atualizado = false;
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_cliente_update";

            cmd.Parameters.AddWithValue("spids", Id);
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spcpf", Cpf);
            cmd.Parameters.AddWithValue("sptelefone", Telefone);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("spdatanasc", Data_nasc);
            //cmd.Parameters.AddWithValue("spdatanasc", Data_nasc);

         // Id = Convert.ToInt32(cmd.ExecuteScalar());
            //         │                 │
            //         │                 └── Executa o SELECT e pega o valor retornado
            //         └── Converte para int e salva na propriedade Id do objeto
            
            if(cmd.ExecuteNonQuery() > 0)
            atualizado = true;
            cmd.Connection.Close();
            return atualizado;
        }

        public static Cliente ObterPorId(int id)
        {
            Cliente cli = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select * from clientes where id = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cli = new(
                    dr.GetInt32(0), //id
                    dr.GetString(1), //nome
                    dr.GetString(2),
                    dr.IsDBNull(3) ? null : dr.GetString(3), //cpf                  
                    dr.GetString(4), //Email
                    DateOnly.FromDateTime(dr.GetDateTime(5)), //DataNasc
                    dr.GetDateTime(6), //DataCad
                    dr.GetBoolean(7) //Ativo
                    );
            }
            dr.Close();
            cmd.Connection.Close();
            return cli;
        }

        public static List<Cliente> ObterLista()
        {
            List<Cliente> clientes = new();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select * from clie" +
                $"ntes order by nome";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clientes.Add(new(
                    dr.GetInt32(0), //id
                    dr.GetString(1), //nome
                    dr.GetString(2),
                    dr.IsDBNull(3) ? null : dr.GetString(3), //cpf                  
                    dr.GetString(4), //Email
                    DateOnly.FromDateTime(dr.GetDateTime(5)), //DataNasc
                    dr.GetDateTime(6), //DataCad
                    dr.GetBoolean(7) //Ativo
                        )
                    );
                }
            dr.Close();
            cmd.Connection.Close();
            return clientes;
        }

        public bool Cadastrar()
        {
            // Valida campo 1
            if (string.IsNullOrEmpty(Nome))
                return false;
            if (string.IsNullOrEmpty(Cpf))
                return false;
            //if (string.IsNullOrEmpty(Telefone))
            //    return false;
            if (string.IsNullOrEmpty(Email))
                return false;


            return Inserir();


        }



    }
}
