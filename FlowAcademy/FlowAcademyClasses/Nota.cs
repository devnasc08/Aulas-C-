using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Nota
    {
        // Propriedades
        public int IdNota { get; set; }
        public int IdMatricula { get; set; }
        public int IdDisciplina { get; set; }

        public decimal? Prova1 { get; set; }
        public decimal? Prova2 { get; set; }
        public decimal? Trabalho { get; set; }
        public decimal? Comportamental { get; set; }

        public decimal? MediaUc { get; set; }
        public string? Status { get; set; }
        public DateTime DataLancamento { get; set; }

        // Objetos de relacionamento
        public Matricula? Matricula { get; set; }
        public Disciplina? Disciplina { get; set; }

        // Construtor vazio
        public Nota()
        {
            IdNota = 0;
            Status = "em_andamento";
            DataLancamento = DateTime.Now;
        }

        // Construtor com ID
        public Nota(int idNota)
        {
            IdNota = idNota;
        }

        // Construtor completo
        public Nota(int idNota, int idMatricula, int idDisciplina,
                    decimal? prova1, decimal? prova2, decimal? trabalho,
                    decimal? comportamental, decimal? mediaUc,
                    string? status, DateTime dataLancamento)
        {
            IdNota = idNota;
            IdMatricula = idMatricula;
            IdDisciplina = idDisciplina;
            Prova1 = prova1;
            Prova2 = prova2;
            Trabalho = trabalho;
            Comportamental = comportamental;
            MediaUc = mediaUc;
            Status = status;
            DataLancamento = dataLancamento;
        }

        // ==========================
        // INSERIR
        // ==========================
        public bool Inserir()
        {
            bool inserido = false;

            CalcularMedia();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_nota_insert";

                cmd.Parameters.AddWithValue("spidmatricula", IdMatricula);
                cmd.Parameters.AddWithValue("spiddisciplina", IdDisciplina);

                cmd.Parameters.AddWithValue("spprova_1", Prova1.HasValue ? Prova1.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("spprova_2", Prova2.HasValue ? Prova2.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("sptrabalho", Trabalho.HasValue ? Trabalho.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("spcomportamental", Comportamental.HasValue ? Comportamental.Value : (object)DBNull.Value);

                cmd.Parameters.AddWithValue("spmedia_uc", MediaUc.HasValue ? MediaUc.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("spstatus", string.IsNullOrEmpty(Status) ? "em_andamento" : Status);
                cmd.Parameters.AddWithValue("spdata_lancamento", DataLancamento);

                IdNota = Convert.ToInt32(cmd.ExecuteScalar());
                inserido = IdNota > 0;

                cmd.Connection.Close();
            }

            return inserido;
        }

        // ==========================
        // ATUALIZAR
        // ==========================
        public bool Atualizar()
        {
            bool atualizado = false;

            if (IdNota < 1)
                return atualizado;

            CalcularMedia();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_nota_update";

                cmd.Parameters.AddWithValue("spidnota", IdNota);
                cmd.Parameters.AddWithValue("spidmatricula", IdMatricula);
                cmd.Parameters.AddWithValue("spiddisciplina", IdDisciplina);

                cmd.Parameters.AddWithValue("spprova_1", Prova1.HasValue ? Prova1.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("spprova_2", Prova2.HasValue ? Prova2.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("sptrabalho", Trabalho.HasValue ? Trabalho.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("spcomportamental", Comportamental.HasValue ? Comportamental.Value : (object)DBNull.Value);

                cmd.Parameters.AddWithValue("spmedia_uc", MediaUc.HasValue ? MediaUc.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("spstatus", string.IsNullOrEmpty(Status) ? "em_andamento" : Status);

                if (cmd.ExecuteNonQuery() > 0)
                    atualizado = true;

                cmd.Connection.Close();
            }

            return atualizado;
        }

        // ==========================
        // EXCLUIR
        // ==========================
        public bool Excluir()
        {
            bool excluido = false;

            if (IdNota < 1)
                return excluido;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_nota_delete";

                cmd.Parameters.AddWithValue("spidnota", IdNota);

                if (cmd.ExecuteNonQuery() > 0)
                    excluido = true;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // MÉTODO DE CÁLCULO
        // ==========================
        public void CalcularMedia()
        {
            decimal p1 = Prova1 ?? 0;
            decimal p2 = Prova2 ?? 0;
            decimal t = Trabalho ?? 0;
            decimal c = Comportamental ?? 0;

            MediaUc = (p1 * 0.3m) + (p2 * 0.4m) + (t * 0.2m) + (c * 0.1m);

            Status = (MediaUc >= 6.0m) ? "aprovado" : "reprovado";
        }
    }
}