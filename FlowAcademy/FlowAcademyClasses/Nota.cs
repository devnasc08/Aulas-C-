using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Nota
    {
        // ==========================
        // PROPRIEDADES
        // ==========================
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

        public Matricula? Matricula { get; set; }
        public Disciplina? Disciplina { get; set; }

        // ==========================
        // CONSTRUTOR
        // ==========================
        public Nota()
        {
            IdNota = 0;
            Status = "em_andamento";
            DataLancamento = DateTime.Now;
        }

        public Nota(int idNota, int idMatricula, int idDisciplina,
            decimal? prova1, decimal? prova2,
            decimal? trabalho, decimal? comportamental,
            decimal? mediaUc, string? status,
            DateTime dataLancamento)
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
            if (IdMatricula <= 0) return false;
            if (IdDisciplina <= 0) return false;

            bool inserido = false;

            CalcularMedia();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_inserir_nota";

                cmd.Parameters.AddWithValue("p_id_matricula", IdMatricula);
                cmd.Parameters.AddWithValue("p_id_disciplina", IdDisciplina);

                cmd.Parameters.AddWithValue("p_prova_1", Prova1 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_prova_2", Prova2 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_trabalho", Trabalho ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_comportamental", Comportamental ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("p_media_uc", MediaUc ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("p_status",
                    string.IsNullOrEmpty(Status) ? "em_andamento" : Status);

                cmd.Parameters.AddWithValue("p_data_lancamento", DataLancamento);

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
            if (IdNota < 1) return false;

            bool atualizado = false;

            CalcularMedia();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_atualizar_nota";

                cmd.Parameters.AddWithValue("p_id", IdNota);
                cmd.Parameters.AddWithValue("p_id_matricula", IdMatricula);
                cmd.Parameters.AddWithValue("p_id_disciplina", IdDisciplina);

                cmd.Parameters.AddWithValue("p_prova_1", Prova1 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_prova_2", Prova2 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_trabalho", Trabalho ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_comportamental", Comportamental ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("p_media_uc", MediaUc ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("p_status",
                    string.IsNullOrEmpty(Status) ? "em_andamento" : Status);

                atualizado = cmd.ExecuteNonQuery() > 0;

                cmd.Connection.Close();
            }

            return atualizado;
        }

        // ==========================
        // EXCLUIR
        // ==========================
        public bool Excluir()
        {
            if (IdNota < 1) return false;

            bool excluido = false;
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_excluir_nota";

                cmd.Parameters.AddWithValue("p_id", IdNota);

                excluido = cmd.ExecuteNonQuery() > 0;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // REGRA DE NEGÓCIO
        // ==========================
        // ==========================
        // REGRA DE NEGÓCIO
        // ==========================
        private void CalcularMedia()
        {
            decimal p1 = Prova1 ?? 0;
            decimal p2 = Prova2 ?? 0;
            decimal t = Trabalho ?? 0;
            decimal c = Comportamental ?? 0;

            MediaUc = (p1 * 0.3m) + (p2 * 0.4m) + (t * 0.2m) + (c * 0.1m);

            if (Prova1.HasValue && Prova2.HasValue)
                Status = MediaUc >= 6 ? "aprovado" : "reprovado";
            else
                Status = "em_andamento";
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Nota ObterPorId(int id)
        {
            Nota nota = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
                SELECT id_nota, id_matricula, id_disciplina,
                       prova_1, prova_2, trabalho, comportamental,
                       media_uc, status, data_lancamento
                FROM notas
                WHERE id_nota = @id";

                cmd.Parameters.AddWithValue("@id", id);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    nota = new Nota(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetInt32(2),
                        dr.IsDBNull(3) ? null : dr.GetDecimal(3),
                        dr.IsDBNull(4) ? null : dr.GetDecimal(4),
                        dr.IsDBNull(5) ? null : dr.GetDecimal(5),
                        dr.IsDBNull(6) ? null : dr.GetDecimal(6),
                        dr.IsDBNull(7) ? null : dr.GetDecimal(7),
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
        // LISTAR
        // ==========================
        public static List<Nota> ObterLista()
        {
            List<Nota> notas = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
                SELECT id_nota, id_matricula, id_disciplina,
                       prova_1, prova_2, trabalho, comportamental,
                       media_uc, status, data_lancamento
                FROM notas";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Nota nota = new Nota(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetInt32(2),
                        dr.IsDBNull(3) ? null : dr.GetDecimal(3),
                        dr.IsDBNull(4) ? null : dr.GetDecimal(4),
                        dr.IsDBNull(5) ? null : dr.GetDecimal(5),
                        dr.IsDBNull(6) ? null : dr.GetDecimal(6),
                        dr.IsDBNull(7) ? null : dr.GetDecimal(7),
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
    }
}
