using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public int IdAluno { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public string? Status { get; set; }
        public Aluno? Aluno { get; set; }

        public Pagamento()
        {
            IdPagamento = 0;
            Status = "pendente";
        }

        public Pagamento(int idPagamento)
        {
            IdPagamento = idPagamento;
        }

        public Pagamento(int idPagamento, int idAluno, decimal valor, DateTime vencimento, string? status)
        {
            IdPagamento = idPagamento;
            IdAluno = idAluno;
            Valor = valor;
            Vencimento = vencimento;
            Status = status;
        }

        public Pagamento(int idAluno, decimal valor, DateTime vencimento, string? status)
        {
            IdAluno = idAluno;
            Valor = valor;
            Vencimento = vencimento;
            Status = status;
        }

        public bool Inserir()
        {
            bool inserido = false;
            VerificarStatus();

            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"insert into pagamentos (id_aluno, valor, vencimento, status)
                    values (@id_aluno, @valor, @vencimento, @status);
                    select last_insert_id();";

                cmd.Parameters.AddWithValue("@id_aluno", IdAluno);
                cmd.Parameters.AddWithValue("@valor", Valor);
                cmd.Parameters.AddWithValue("@vencimento", Vencimento.Date);
                cmd.Parameters.AddWithValue("@status", string.IsNullOrEmpty(Status) ? "pendente" : Status);

                IdPagamento = Convert.ToInt32(cmd.ExecuteScalar());
                inserido = IdPagamento > 0;
                cmd.Connection.Close();
            }

            return inserido;
        }

        public bool Atualizar()
        {
            bool atualizado = false;
            if (IdPagamento < 1) return atualizado;

            VerificarStatus();

            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"update pagamentos
                    set id_aluno = @id_aluno,
                        valor = @valor,
                        vencimento = @vencimento,
                        status = @status
                    where id_pagamento = @id_pagamento";

                cmd.Parameters.AddWithValue("@id_pagamento", IdPagamento);
                cmd.Parameters.AddWithValue("@id_aluno", IdAluno);
                cmd.Parameters.AddWithValue("@valor", Valor);
                cmd.Parameters.AddWithValue("@vencimento", Vencimento.Date);
                cmd.Parameters.AddWithValue("@status", string.IsNullOrEmpty(Status) ? "pendente" : Status);

                if (cmd.ExecuteNonQuery() > 0)
                    atualizado = true;

                cmd.Connection.Close();
            }

            return atualizado;
        }

        public bool Alterar()
        {
            return Atualizar();
        }

        public bool Excluir()
        {
            bool excluido = false;
            if (IdPagamento < 1) return excluido;

            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from pagamentos where id_pagamento = @id_pagamento";
                cmd.Parameters.AddWithValue("@id_pagamento", IdPagamento);

                if (cmd.ExecuteNonQuery() > 0)
                    excluido = true;

                cmd.Connection.Close();
            }

            return excluido;
        }

        public static Pagamento ObterPorId(int idPagamento)
        {
            Pagamento pagamento = new();
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select id_pagamento, id_aluno, valor, vencimento, status
                    from pagamentos
                    where id_pagamento = @id_pagamento";
                cmd.Parameters.AddWithValue("@id_pagamento", idPagamento);

                var dr = cmd.ExecuteReader();
                if (dr.Read())
                    pagamento = MontarPagamento(dr);

                dr.Close();
                cmd.Connection.Close();
            }

            return pagamento;
        }

        public static List<Pagamento> ObterLista(string busca = "")
        {
            List<Pagamento> pagamentos = new();
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select p.id_pagamento, p.id_aluno, p.valor, p.vencimento, p.status
                    from pagamentos p
                    inner join alunos a on a.id_aluno = p.id_aluno
                    inner join usuarios u on u.id_usuario = a.id_usuario
                    where u.nome like @busca or p.status like @busca
                    order by p.vencimento";
                cmd.Parameters.AddWithValue("@busca", $"%{busca}%");

                var dr = cmd.ExecuteReader();
                while (dr.Read())
                    pagamentos.Add(MontarPagamento(dr));

                dr.Close();
                cmd.Connection.Close();
            }

            return pagamentos;
        }

        public static DataTable Listar()
        {
            DataTable tabela = new();
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select p.*, u.nome as aluno
                    from pagamentos p
                    inner join alunos a on a.id_aluno = p.id_aluno
                    inner join usuarios u on u.id_usuario = a.id_usuario
                    order by p.vencimento";
                tabela.Load(cmd.ExecuteReader());
                cmd.Connection.Close();
            }

            return tabela;
        }

        public void VerificarStatus()
        {
            if (Status == "pago" || Status == "cancelado")
                return;

            Status = DateTime.Today > Vencimento.Date ? "atrasado" : "pendente";
        }

        public void RealizarPagamento()
        {
            Status = "pago";
        }

        private static Pagamento MontarPagamento(IDataRecord dr)
        {
            return new(
                dr.GetInt32(0),
                dr.GetInt32(1),
                dr.GetDecimal(2),
                dr.GetDateTime(3),
                dr.GetString(4)
            );
        }
    }
}
