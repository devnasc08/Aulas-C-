using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAcademyClasses
{
    internal class Turma
    {

        // ============================
        // ATRIBUTOS / PROPRIEDADES
        // ============================

        public int IdTurma { get; set; }

        public int IdCurso { get; set; }

        public int IdProfessor { get; set; }

        public string CodigoTurma { get; set; }

        public string Turno { get; set; }

        public int CapacidadeMaxima { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public string Status { get; set; }


        // ============================
        // CONSTRUTOR VAZIO
        // ============================

        public Turma()
        {

        }


        // ============================
        // CONSTRUTOR COMPLETO
        // ============================

        public Turma(
            int idTurma,
            int idCurso,
            int idProfessor,
            string codigoTurma,
            string turno,
            int capacidadeMaxima,
            DateTime dataInicio,
            DateTime dataFim,
            string status)
        {
            IdTurma = idTurma;

            IdCurso = idCurso;

            IdProfessor = idProfessor;

            CodigoTurma = codigoTurma;

            Turno = turno;

            CapacidadeMaxima = capacidadeMaxima;

            DataInicio = dataInicio;

            DataFim = dataFim;

            Status = status;
        }


        // ============================
        // VERIFICAR STATUS
        // ============================

        /*
         * Se a data atual ultrapassar
         * a data final da turma,
         * ela será encerrada.
         */

        public void VerificarStatus()
        {
            if (DateTime.Now.Date > DataFim.Date)
            {
                Status = "encerrada";
            }
            else
            {
                Status = "ativa";
            }
        }


        // ============================
        // INSERIR
        // ============================

        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_turma_insert";

            cmd.Parameters.AddWithValue("p_id_curso", IdCurso);

            cmd.Parameters.AddWithValue("p_id_professor", IdProfessor);

            cmd.Parameters.AddWithValue("p_codigo_turma", CodigoTurma);

            cmd.Parameters.AddWithValue("p_turno", Turno);

            cmd.Parameters.AddWithValue("p_capacidade_maxima", CapacidadeMaxima);

            cmd.Parameters.AddWithValue("p_data_inicio", DataInicio);

            cmd.Parameters.AddWithValue("p_data_fim", DataFim);

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

            cmd.CommandText = "sp_turma_update";

            cmd.Parameters.AddWithValue("p_id_turma", IdTurma);

            cmd.Parameters.AddWithValue("p_id_curso", IdCurso);

            cmd.Parameters.AddWithValue("p_id_professor", IdProfessor);

            cmd.Parameters.AddWithValue("p_codigo_turma", CodigoTurma);

            cmd.Parameters.AddWithValue("p_turno", Turno);

            cmd.Parameters.AddWithValue("p_capacidade_maxima", CapacidadeMaxima);

            cmd.Parameters.AddWithValue("p_data_inicio", DataInicio);

            cmd.Parameters.AddWithValue("p_data_fim", DataFim);

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

            cmd.CommandText = "sp_turma_delete";

            cmd.Parameters.AddWithValue("p_id_turma", IdTurma);

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

            cmd.CommandText = "sp_turma_select";

            tabela.Load(cmd.ExecuteReader());

            cmd.Connection.Close();

            return tabela;
        }

    }
}
