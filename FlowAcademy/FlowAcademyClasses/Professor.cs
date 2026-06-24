using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Professor
    {
        public int IdProfessor { get; set; }
        public int IdUsuario { get; set; }
        public string? Cpf { get; set; }
        public string? Especialidade { get; set; }

        public Usuario? Usuario { get; set; }

        public Professor()
        {
            IdProfessor = 0;
            IdUsuario = 0;
            Cpf = "";
            Especialidade = "";
        }

        public Professor(int idProfessor, int idUsuario, string? cpf, string? especialidade)
        {
            IdProfessor = idProfessor;
            IdUsuario = idUsuario;
            Cpf = cpf;
            Especialidade = especialidade;
        }

        // ==========================
        // INSERIR
        // ==========================
        public bool Inserir()
        {
            if (IdUsuario <= 0) return false;

            bool inserido = false;
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_inserir_professor";

                cmd.Parameters.AddWithValue("p_id_usuario", IdUsuario);
                cmd.Parameters.AddWithValue("p_cpf", Cpf);
                cmd.Parameters.AddWithValue("p_especialidade", Especialidade);

                IdProfessor = Convert.ToInt32(cmd.ExecuteScalar());
                inserido = IdProfessor > 0;

                cmd.Connection.Close();
            }

            return inserido;
        }

        // ==========================
        // ATUALIZAR
        // ==========================
        public bool Atualizar()
        {
            if (IdProfessor < 1) return false;

            var cmd = Banco.Abrir();
            bool atualizado = false;

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_atualizar_professor";

                cmd.Parameters.AddWithValue("p_id", IdProfessor);
                cmd.Parameters.AddWithValue("p_cpf", Cpf);
                cmd.Parameters.AddWithValue("p_especialidade", Especialidade);

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
            if (IdProfessor < 1) return false;

            var cmd = Banco.Abrir();
            bool excluido = false;

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_excluir_professor";

                cmd.Parameters.AddWithValue("p_id", IdProfessor);

                excluido = cmd.ExecuteNonQuery() > 0;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Professor ObterPorId(int id)
        {
            Professor professor = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
            SELECT id_professor, id_usuario, cpf, especialidade
            FROM professores
            WHERE id_professor = @id";

                cmd.Parameters.AddWithValue("@id", id);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    professor = new Professor(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3)
                    );

                    professor.Usuario = Usuario.ObterPorId(professor.IdUsuario);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return professor;
        }

        // ==========================
        // LISTAR
        // ==========================
        public static List<Professor> ObterLista()
        {
            List<Professor> professores = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
                SELECT id_professor, id_usuario, cpf, especialidade
                FROM professores";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var prof = new Professor(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3)
                    );

                    prof.Usuario = Usuario.ObterPorId(prof.IdUsuario);
                    professores.Add(prof);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return professores;
        }
    }
}