using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Matricula
    {
        // ==========================
        // PROPRIEDADES
        // ==========================
        public int IdMatricula { get; set; }
        public int IdAluno { get; set; }
        public int IdTurma { get; set; }
        public DateTime DataMatricula { get; set; }
        public string? Status { get; set; }

        // Relacionamentos
        public Aluno? Aluno { get; set; }
        public Turma? Turma { get; set; }

        // ==========================
        // CONSTRUTOR
        // ==========================
        public Matricula()
        {
            IdMatricula = 0;
            DataMatricula = DateTime.Today;
            Status = "ativa";
        }

        public Matricula(int idMatricula, int idAluno, int idTurma,
                         DateTime dataMatricula, string? status)
        {
            IdMatricula = idMatricula;
            IdAluno = idAluno;
            IdTurma = idTurma;
            DataMatricula = dataMatricula;
            Status = status;
        }

        // ==========================
        // INSERIR
        // ==========================
        public bool Inserir()
        {
            if (IdAluno <= 0) return false;
            if (IdTurma <= 0) return false;

            bool inserido = false;
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_inserir_matricula";

                cmd.Parameters.AddWithValue("p_id_aluno", IdAluno);
                cmd.Parameters.AddWithValue("p_id_turma", IdTurma);
                cmd.Parameters.AddWithValue("p_data_matricula", DataMatricula);
                cmd.Parameters.AddWithValue("p_status",
                    string.IsNullOrEmpty(Status) ? "ativa" : Status);

                IdMatricula = Convert.ToInt32(cmd.ExecuteScalar());
                inserido = IdMatricula > 0;

                cmd.Connection.Close();
            }

            return inserido;
        }

        // ==========================
        // ATUALIZAR
        // ==========================
        public bool Atualizar()
        {
            if (IdMatricula < 1) return false;

            bool atualizado = false;
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_atualizar_matricula";

                cmd.Parameters.AddWithValue("p_id", IdMatricula);
                cmd.Parameters.AddWithValue("p_id_aluno", IdAluno);
                cmd.Parameters.AddWithValue("p_id_turma", IdTurma);
                cmd.Parameters.AddWithValue("p_data_matricula", DataMatricula);
                cmd.Parameters.AddWithValue("p_status", Status);

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
            if (IdMatricula < 1) return false;

            bool excluido = false;
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_excluir_matricula";

                cmd.Parameters.AddWithValue("p_id", IdMatricula);

                excluido = cmd.ExecuteNonQuery() > 0;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Matricula ObterPorId(int id)
        {
            Matricula matricula = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
                SELECT id_matricula, id_aluno, id_turma, data_matricula, status
                FROM matriculas
                WHERE id_matricula = @id";

                cmd.Parameters.AddWithValue("@id", id);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    matricula = new Matricula(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetInt32(2),
                        dr.GetDateTime(3),
                        dr.IsDBNull(4) ? null : dr.GetString(4)
                    );

                    matricula.Aluno = Aluno.ObterPorId(matricula.IdAluno);
                    matricula.Turma = Turma.ObterPorId(matricula.IdTurma);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return matricula;
        }

        // ==========================
        // LISTAR
        // ==========================
        public static List<Matricula> ObterLista()
        {
            List<Matricula> matriculas = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
                SELECT id_matricula, id_aluno, id_turma, data_matricula, status
                FROM matriculas";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Matricula m = new Matricula(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetInt32(2),
                        dr.GetDateTime(3),
                        dr.IsDBNull(4) ? null : dr.GetString(4)
                    );

                    m.Aluno = Aluno.ObterPorId(m.IdAluno);
                    m.Turma = Turma.ObterPorId(m.IdTurma);

                    matriculas.Add(m);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return matriculas;
        }

        // ==========================
        // REGRA DE NEGÓCIO
        // ==========================
        public bool RealizarMatricula()
        {
            if (!new Turma(IdTurma).PossuiVaga())
                return false;

            DataMatricula = DateTime.Today;
            Status = "ativa";

            return Inserir();
        }
    }
}