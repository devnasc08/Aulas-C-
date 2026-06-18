using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAcademyClasses
{
    internal class Pagamento
    {

        // ============================
        // ATRIBUTOS / PROPRIEDADES
        // ============================

        public int IdPagamento { get; set; }

        public int IdAluno { get; set; }

        public decimal Valor { get; set; }

        public DateTime Vencimento { get; set; }

        public string Status { get; set; }


        // ============================
        // CONSTRUTOR VAZIO
        // ============================

        public Pagamento()
        {

        }


        // ============================
        // CONSTRUTOR COMPLETO
        // ============================

        public Pagamento(
            int idPagamento,
            int idAluno,
            decimal valor,
            DateTime vencimento,
            string status)
        {
            IdPagamento = idPagamento;

            IdAluno = idAluno;

            Valor = valor;

            Vencimento = vencimento;

            Status = status;
        }


        // ============================
        // VERIFICAR STATUS
        // ============================

        /*
         * Se a data atual ultrapassar
         * o vencimento e ainda não estiver pago,
         * o status passa para atrasado.
         */

        public void VerificarStatus()
        {
            if (Status != "pago")
            {
                if (DateTime.Now.Date > Vencimento.Date)
                {
                    Status = "atrasado";
                }
                else
                {
                    Status = "pendente";
                }
            }
        }


        // ============================
        // MARCAR COMO PAGO
        // ============================

        public void RealizarPagamento()
        {
            Status = "pago";
        }


        // ============================
        // INSERIR
        // ============================

        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_pagamento_insert";

            cmd.Parameters.AddWithValue("p_id_aluno", IdAluno);

            cmd.Parameters.AddWithValue("p_valor", Valor);

            cmd.Parameters.AddWithValue("p_vencimento", Vencimento);

            cmd.Parameters.AddWithValue("p_status", Status);

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
        }


        // ============================
        // ALTERAR
        // ============================

        public void Alterar()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_pagamento_update";

            cmd.Parameters.AddWithValue("p_id_pagamento", IdPagamento);

            cmd.Parameters.AddWithValue("p_valor", Valor);

            cmd.Parameters.AddWithValue("p_vencimento", Vencimento);

            cmd.Parameters.AddWithValue("p_status", Status);

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
        }


        // ============================
        // EXCLUIR
        // ============================

        public void Excluir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_pagamento_delete";

            cmd.Parameters.AddWithValue("p_id_pagamento", IdPagamento);

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
        }


        // ============================
        // LISTAR
        // ============================

        public static DataTable Listar()
        {
            DataTable tabela = new DataTable();

            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_pagamento_select";

            tabela.Load(cmd.ExecuteReader());

            cmd.Connection.Close();

            return tabela;
        }


    }
}
