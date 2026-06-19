using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Turma
    {
        // Propriedades
        public int IdTurma { get; set; }
        public int IdCurso { get; set; }
        public string? CodigoTurma { get; set; }
        public string? Periodo { get; set; } // 'matutino', 'vespertino', 'noturno'
        public int VagasTotais { get; set; }
        public int VagasPreenchidas { get; set; }
        public string? Status { get; set; }

        // Objetos de Relacionamento
        public Curso? Curso { get; set; }

        // Construtor vazio
        public Turma()
        {
            IdTurma = 0;
            IdCurso = 0;
            CodigoTurma = "";
            VagasTotais = 0;
            VagasPreenchidas = 0;
            Status = "planejada";
        }

        // Construtor com ID
        public Turma(int idTurma)
        {
            IdTurma = idTurma;
        }

        // Construtor completo
        public Turma(int idTurma, int idCurso, string? codigoTurma, string? periodo, int vagasTotais, int vagasPreenchidas, string? status)
        {
            IdTurma = idTurma;
            IdCurso = idCurso;
            CodigoTurma = codigoTurma;
            Periodo = periodo;
            VagasTotais = vagasTotais;
            VagasPreenchidas = vagasPreenchidas;
            Status = status;
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
                cmd.CommandText = "sp_turma_insert";

                cmd.Parameters.AddWithValue("spidcurso", IdCurso);
                cmd.Parameters.AddWithValue("spcodigoturma", CodigoTurma);
                cmd.Parameters.AddWithValue("spperiodo", Periodo);
                cmd.Parameters.AddWithValue("spvagastotais", VagasTotais);
                cmd.Parameters.AddWithValue("spstatus", Status);

                IdTurma = Convert.ToInt32(cmd.ExecuteScalar());
                inserido = IdTurma > 0;

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
            if (IdTurma < 1) return atualizado;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_turma_update";

                cmd.Parameters.AddWithValue("spidturma", IdTurma);
                cmd.Parameters.AddWithValue("spidcurso", IdCurso);
                cmd.Parameters.AddWithValue("spcodigoturma", CodigoTurma);
                cmd.Parameters.AddWithValue("spperiodo", Periodo);
                cmd.Parameters.AddWithValue("spvagastotais", VagasTotais);
                cmd.Parameters.AddWithValue("spvagaspreenchidas", VagasPreenchidas);
                cmd.Parameters.AddWithValue("spstatus", Status);

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
            if (IdTurma < 1) return excluido;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_turma_delete";

                cmd.Parameters.AddWithValue("spidturma", IdTurma);

                if (cmd.ExecuteNonQuery() > 0)
                    excluido = true;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Turma ObterPorId(int idTurma)
        {
            Turma turma = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_turma_getbyid";
                cmd.Parameters.AddWithValue("spidturma", idTurma);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    turma = new Turma(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3),
                        dr.GetInt32(4),
                        dr.GetInt32(5),
                        dr.IsDBNull(6) ? null : dr.GetString(6)
                    );

                    turma.Curso = Curso.ObterPorId(turma.IdCurso);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return turma;
        }

        // ==========================
        // LISTAR
        // ==========================
        public static List<Turma> ObterLista()
        {
            List<Turma> turmas = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_turma_getall";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var turma = new Turma(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3),
                        dr.GetInt32(4),
                        dr.GetInt32(5),
                        dr.IsDBNull(6) ? null : dr.GetString(6)
                    );

                    turma.Curso = Curso.ObterPorId(turma.IdCurso);
                    turmas.Add(turma);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return turmas;
        }

        // Lógica de verificação de vagas solicitada pelo método da Matrícula
        public bool PossuiVaga()
        {
            if (IdTurma < 1) return false;

            // Re-obtém os dados para checar de forma atualizada no banco
            var t = ObterPorId(IdTurma);
            return t.VagasPreenchidas < t.VagasTotais;
        }
    }
}