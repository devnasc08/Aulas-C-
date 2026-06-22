using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Disciplina
    {
        // ==========================
        // PROPRIEDADES
        // ==========================
        public int IdDisciplina { get; set; }
        public int IdCurso { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public string? Status { get; set; }

        // ==========================
        // CONSTRUTOR VAZIO
        // ==========================
        public Disciplina()
        {
            IdDisciplina = 0;
            IdCurso = 0;
            Nome = "";
            Descricao = "";
            CargaHoraria = 0;
            Status = "ativo";
        }

        // ==========================
        // CONSTRUTOR COMPLETO
        // ==========================
        public Disciplina(int idDisciplina, int idCurso, string? nome, string? descricao, int cargaHoraria, string? status)
        {
            IdDisciplina = idDisciplina;
            IdCurso = idCurso;
            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
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
                cmd.CommandText = "sp_inserir_disciplina";

                cmd.Parameters.AddWithValue("p_id_curso", IdCurso);
                cmd.Parameters.AddWithValue("p_nome", Nome);
                cmd.Parameters.AddWithValue("p_descricao", Descricao);
                cmd.Parameters.AddWithValue("p_carga_horaria", CargaHoraria);
                cmd.Parameters.AddWithValue("p_status", Status);

                IdDisciplina = Convert.ToInt32(cmd.ExecuteScalar());
                inserido = IdDisciplina > 0;

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

            if (IdDisciplina < 1) return atualizado;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_atualizar_disciplina";

                cmd.Parameters.AddWithValue("p_id", IdDisciplina);
                cmd.Parameters.AddWithValue("p_id_curso", IdCurso);
                cmd.Parameters.AddWithValue("p_nome", Nome);
                cmd.Parameters.AddWithValue("p_descricao", Descricao);
                cmd.Parameters.AddWithValue("p_carga_horaria", CargaHoraria);
                cmd.Parameters.AddWithValue("p_status", Status);

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

            if (IdDisciplina < 1) return excluido;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_excluir_disciplina";

                cmd.Parameters.AddWithValue("p_id", IdDisciplina);

                if (cmd.ExecuteNonQuery() > 0)
                    excluido = true;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Disciplina ObterPorId(int id)
        {
            Disciplina disciplina = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
                SELECT id_disciplina, id_curso, nome, descricao, carga_horaria, status
                FROM disciplinas
                WHERE id_disciplina = @id";

                cmd.Parameters.AddWithValue("@id", id);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    disciplina = new Disciplina(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3),
                        dr.GetInt32(4),
                        dr.IsDBNull(5) ? null : dr.GetString(5)
                    );
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return disciplina;
        }

        // ==========================
        // LISTAR
        // ==========================
        public static List<Disciplina> ObterLista()
        {
            List<Disciplina> disciplinas = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
                SELECT id_disciplina, id_curso, nome, descricao, carga_horaria, status
                FROM disciplinas";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    disciplinas.Add(new Disciplina(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3),
                        dr.GetInt32(4),
                        dr.IsDBNull(5) ? null : dr.GetString(5)
                    ));
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return disciplinas;
        }
    }
}