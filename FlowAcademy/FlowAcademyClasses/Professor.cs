using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Professor
    {
        // Propriedades
        public int IdProfessor { get; set; }
        public int IdUsuario { get; set; }
        public string? Especializacao { get; set; }
        public string? Titulacao { get; set; } // 'graduado', 'mestre', 'doutor'

        // Relacionamento com Usuário
        public Usuario? Usuario { get; set; }

        // Construtor vazio
        public Professor()
        {
            IdProfessor = 0;
            IdUsuario = 0;
            Especializacao = "";
            Titulacao = "graduado";
        }

        // Construtor com ID
        public Professor(int idProfessor)
        {
            IdProfessor = idProfessor;
        }

        // Construtor completo
        public Professor(int idProfessor, int idUsuario, string? especializacao, string? titulacao)
        {
            IdProfessor = idProfessor;
            IdUsuario = idUsuario;
            Especializacao = especializacao;
            Titulacao = titulacao;
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
                cmd.CommandText = "sp_professor_insert";

                cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
                cmd.Parameters.AddWithValue("spespecializacao", Especializacao);
                cmd.Parameters.AddWithValue("sptitulacao", Titulacao);

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
            bool atualizado = false;
            if (IdProfessor < 1) return atualizado;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_professor_update";

                cmd.Parameters.AddWithValue("spidprofessor", IdProfessor);
                cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
                cmd.Parameters.AddWithValue("spespecializacao", Especializacao);
                cmd.Parameters.AddWithValue("sptitulacao", Titulacao);

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
            if (IdProfessor < 1) return excluido;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_professor_delete";

                cmd.Parameters.AddWithValue("spidprofessor", IdProfessor);

                if (cmd.ExecuteNonQuery() > 0)
                    excluido = true;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Professor ObterPorId(int idProfessor)
        {
            Professor professor = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_professor_getbyid";
                cmd.Parameters.AddWithValue("spidprofessor", idProfessor);

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
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_professor_getall";

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