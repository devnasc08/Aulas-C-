using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Frequencia
    {
        // Propriedades
        public int IdFrequencia { get; set; }

        public int IdMatricula { get; set; }

        public int IdDisciplina { get; set; }

        public int TotalAulas { get; set; }

        public int Presencas { get; set; }

        public decimal Percentual { get; set; }


        // Objetos de relacionamento
        public Matricula? Matricula { get; set; }

        public Disciplina? Disciplina { get; set; }


        // Construtor vazio
        public Frequencia()
        {
            IdFrequencia = 0;
            IdMatricula = 0;
            IdDisciplina = 0;
            TotalAulas = 0;
            Presencas = 0;
            Percentual = 0;
        }


        // Construtor com ID
        public Frequencia(int idFrequencia)
        {
            IdFrequencia = idFrequencia;
        }


        // Construtor completo
        public Frequencia(
            int idFrequencia,
            int idMatricula,
            int idDisciplina,
            int totalAulas,
            int presencas,
            decimal percentual)
        {
            IdFrequencia = idFrequencia;
            IdMatricula = idMatricula;
            IdDisciplina = idDisciplina;
            TotalAulas = totalAulas;
            Presencas = presencas;
            Percentual = percentual;
        }


        // ==========================
        // INSERIR
        // ==========================
        public bool Inserir()
        {
            if (IdMatricula <= 0) return false;
            if (IdDisciplina <= 0) return false;
            if (TotalAulas <= 0) return false;

            bool inserido = false;

            CalcularPercentual();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_inserir_frequencia";

                cmd.Parameters.AddWithValue("p_id_matricula", IdMatricula);
                cmd.Parameters.AddWithValue("p_id_disciplina", IdDisciplina);
                cmd.Parameters.AddWithValue("p_total_aulas", TotalAulas);
                cmd.Parameters.AddWithValue("p_presencas", Presencas);
                cmd.Parameters.AddWithValue("p_percentual", Percentual);

                IdFrequencia = Convert.ToInt32(cmd.ExecuteScalar());
                inserido = IdFrequencia > 0;

                cmd.Connection.Close();
            }

            return inserido;
        }


        // ==========================
        // ATUALIZAR
        // ==========================
        public bool Atualizar()
        {
            if (IdFrequencia < 1) return false;

            bool atualizado = false;

            CalcularPercentual();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_atualizar_frequencia";

                cmd.Parameters.AddWithValue("p_id", IdFrequencia);
                cmd.Parameters.AddWithValue("p_id_matricula", IdMatricula);
                cmd.Parameters.AddWithValue("p_id_disciplina", IdDisciplina);
                cmd.Parameters.AddWithValue("p_total_aulas", TotalAulas);
                cmd.Parameters.AddWithValue("p_presencas", Presencas);
                cmd.Parameters.AddWithValue("p_percentual", Percentual);

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
            if (IdFrequencia < 1) return false;

            bool excluido = false;
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_excluir_frequencia";

                cmd.Parameters.AddWithValue("p_id", IdFrequencia);

                excluido = cmd.ExecuteNonQuery() > 0;

                cmd.Connection.Close();
            }

            return excluido;
        }


        // ==========================
        // OBTER POR ID
        // ==========================
        public static Frequencia ObterPorId(int idFrequencia)
        {
            Frequencia frequencia = new();

            var cmd = Banco.Abrir();


            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;


                cmd.CommandText = @"SELECT id_frequencia, id_matricula, id_disciplina, total_aulas,
                                    presencas, percentual FROM frequencia WHERE id_frequencia = @id";

                cmd.Parameters.AddWithValue("@id", idFrequencia);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    frequencia = new Frequencia(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetInt32(2),
                        dr.GetInt32(3),
                        dr.GetInt32(4),
                        dr.IsDBNull(5) ? 0 : dr.GetDecimal(5)
                    );

                    // Carrega os relacionamentos
                    frequencia.Matricula = Matricula.ObterPorId(frequencia.IdMatricula);
                    frequencia.Disciplina = Disciplina.ObterPorId(frequencia.IdDisciplina);

                }

                dr.Close();
                cmd.Connection.Close();
            }
            return frequencia;
        }




        // ==========================
        // LISTAR
        // ==========================
        public static List<Frequencia> ObterLista()
        {
            List<Frequencia> frequencias = new();

            var cmd = Banco.Abrir();


            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"SELECT id_frequencia, id_matricula, id_disciplina, total_aulas,
                                    presencas, percentual FROM frequencia";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var frequencia = new Frequencia(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetInt32(2),
                        dr.GetInt32(3),
                        dr.GetInt32(4),
                        dr.IsDBNull(5) ? 0 : dr.GetDecimal(5)
                    );

                    frequencia.Matricula = Matricula.ObterPorId(frequencia.IdMatricula);
                    frequencia.Disciplina = Disciplina.ObterPorId(frequencia.IdDisciplina);

                    frequencias.Add(frequencia);
                }

                dr.Close();

                cmd.Connection.Close();
            }

            return frequencias;
        }


        // ==========================
        // MÉTODOS INTERNOS
        // ==========================
        public void CalcularPercentual()
        {
            if (TotalAulas > 0)
                Percentual = (Presencas * 100m) / TotalAulas;
            else
                Percentual = 0;
        }
    }
}