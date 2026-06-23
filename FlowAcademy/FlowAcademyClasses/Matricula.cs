using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Matricula
    {



        /// <summary>
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// AJUSTAR OS NOMES DAS PROCEDURES E AS COLUNAS DE ACORDO COM O BANCO DE DADOS
        /// </summary>







        // Propriedades
        public int IdMatricula { get; set; }
        public int IdAluno { get; set; }
        public int IdTurma { get; set; }
        public DateTime DataMatricula { get; set; }
        public string? Status { get; set; }

        // Objetos de relacionamento
        public Aluno? Aluno { get; set; }
        public Turma? Turma { get; set; }

        // Construtor vazio
        public Matricula()
        {
            IdMatricula = 0;
            DataMatricula = DateTime.Today;
            Status = "ativa";
        }

        // Construtor com ID
        public Matricula(int idMatricula)
        {
            IdMatricula = idMatricula;
        }

        // Construtor completo
        public Matricula(int idMatricula, int idAluno, int idTurma, DateTime dataMatricula, string? status)
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
            bool inserido = false;
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_inserir_matricula";

                cmd.Parameters.AddWithValue("p_id_aluno", IdAluno);
                cmd.Parameters.AddWithValue("spidturma", IdTurma);
                cmd.Parameters.AddWithValue("spdatamatricula", DataMatricula);
                cmd.Parameters.AddWithValue("spstatus", Status);

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
            bool atualizado = false;
            if (IdMatricula < 1) return atualizado;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_matricula_update";

                cmd.Parameters.AddWithValue("spidmatricula", IdMatricula);
                cmd.Parameters.AddWithValue("spidaluno", IdAluno);
                cmd.Parameters.AddWithValue("spidturma", IdTurma);
                cmd.Parameters.AddWithValue("spdatamatricula", DataMatricula);
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
            if (IdMatricula < 1) return excluido;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_matricula_delete";

                cmd.Parameters.AddWithValue("spidmatricula", IdMatricula);

                if (cmd.ExecuteNonQuery() > 0)
                    excluido = true;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Matricula ObterPorId(int idMatricula)
        {
            Matricula matricula = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
                SELECT

                id_matricula,
                id_aluno,
                id_turma,
                data_matricula,
                status

                FROM matriculas

                WHERE id_matricula = @id";

                cmd.Parameters.AddWithValue("@id", idMatricula);

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

                    // Carrega os objetos relacionados de forma automatizada
                    matricula.Aluno = Aluno.ObterPorId(matricula.IdAluno);
                    matricula.Turma = Turma.ObterPorId(matricula.IdTurma);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return matricula;
        }

        // ==========================
        // LISTAR (Retorna List<Matricula>)
        // ==========================
        public static List<Matricula> ObterLista()
        {
            List<Matricula> matriculas = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"

                SELECT

                id_matricula,
                id_aluno,
                id_turma,
                data_matricula,
                status

                FROM matriculas";   

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var matricula = new Matricula(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetInt32(2),
                        dr.GetDateTime(3),
                        dr.IsDBNull(4) ? null : dr.GetString(4)
                    );

                    matricula.Aluno = Aluno.ObterPorId(matricula.IdAluno);
                    matricula.Turma = Turma.ObterPorId(matricula.IdTurma);

                    matriculas.Add(matricula);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return matriculas;
        }

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