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

        public decimal Nota1
        {
            get { return Prova1 ?? 0; }
            set { Prova1 = value; }
        }

        public decimal Nota2
        {
            get { return Prova2 ?? 0; }
            set { Prova2 = value; }
        }

        public decimal MediaFinal
        {
            get { return MediaUc ?? 0; }
            set { MediaUc = value; }
        }

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
        public Nota(int idNota, int idMatricula, int idDisciplina, decimal? prova1, decimal? prova2, decimal? trabalho, decimal? comportamental, decimal? mediaUc, string? status, DateTime dataLancamento)
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
            if (IdNota < 1) return atualizado;

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
            if (IdNota < 1) return excluido;

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
        // OBTER POR ID
        // ==========================
        public static Nota ObterPorId(int idNota)
        {
            Nota nota = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_nota_getbyid";
                cmd.Parameters.AddWithValue("spidnota", idNota);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    nota = new Nota(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetInt32(2),
                        dr.IsDBNull(3) ? (decimal?)null : dr.GetDecimal(3),
                        dr.IsDBNull(4) ? (decimal?)null : dr.GetDecimal(4),
                        dr.IsDBNull(5) ? (decimal?)null : dr.GetDecimal(5),
                        dr.IsDBNull(6) ? (decimal?)null : dr.GetDecimal(6),
                        dr.IsDBNull(7) ? (decimal?)null : dr.GetDecimal(7),
                        dr.IsDBNull(8) ? null : dr.GetString(8),
                        dr.GetDateTime(9)
                    );

                    nota.Matricula = Matricula.ObterPorId(nota.IdMatricula);
                    nota.Disciplina = Disciplina.ObterPorId(nota.IdDisciplina);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return nota;
        }

        // ==========================
        // LISTAR (Retorna List<Nota>)
        // ==========================
        public static List<Nota> ObterLista()
        {
            List<Nota> notas = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_nota_getall";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var nota = new Nota(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetInt32(2),
                        dr.IsDBNull(3) ? (decimal?)null : dr.GetDecimal(3),
                        dr.IsDBNull(4) ? (decimal?)null : dr.GetDecimal(4),
                        dr.IsDBNull(5) ? (decimal?)null : dr.GetDecimal(5),
                        dr.IsDBNull(6) ? (decimal?)null : dr.GetDecimal(6),
                        dr.IsDBNull(7) ? (decimal?)null : dr.GetDecimal(7),
                        dr.IsDBNull(8) ? null : dr.GetString(8),
                        dr.GetDateTime(9)
                    );

                    nota.Matricula = Matricula.ObterPorId(nota.IdMatricula);
                    nota.Disciplina = Disciplina.ObterPorId(nota.IdDisciplina);

                    notas.Add(nota);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return notas;
        }

        public void CalcularMedia()
        {
            decimal p1 = Prova1 ?? 0;
            decimal p2 = Prova2 ?? 0;
            decimal t = Trabalho ?? 0;
            decimal c = Comportamental ?? 0;

            MediaUc = (p1 * 0.3m) + (p2 * 0.4m) + (t * 0.2m) + (c * 0.1m);

            if (MediaUc >= 6.0m)
                Status = "aprovado";
            else
                Status = "reprovado";
        }
    }
}