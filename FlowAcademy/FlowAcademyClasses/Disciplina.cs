using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Disciplina
    {
        // Propriedades
        public int IdDisciplina { get; set; }
        public int IdCurso { get; set; }
        public string? Nome { get; set; }
        public int CargaHoraria { get; set; }

        // Objeto de relacionamento
        public Curso? Curso { get; set; }

        // Construtor vazio
        public Disciplina()
        {
            IdDisciplina = 0;
            IdCurso = 0;
            Nome = "";
            CargaHoraria = 0;
        }

        // Construtor com ID
        public Disciplina(int idDisciplina)
        {
            IdDisciplina = idDisciplina;
        }

        // Construtor completo
        public Disciplina(int idDisciplina, int idCurso, string? nome, int cargaHoraria)
        {
            IdDisciplina = idDisciplina;
            IdCurso = idCurso;
            Nome = nome;
            CargaHoraria = cargaHoraria;
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
                cmd.CommandText = "sp_disciplina_insert";

                cmd.Parameters.AddWithValue("spidcurso", IdCurso);
                cmd.Parameters.AddWithValue("spnome", Nome);
                cmd.Parameters.AddWithValue("spcargahoraria", CargaHoraria);

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
                cmd.CommandText = "sp_disciplina_update";

                cmd.Parameters.AddWithValue("spiddisciplina", IdDisciplina);
                cmd.Parameters.AddWithValue("spidcurso", IdCurso);
                cmd.Parameters.AddWithValue("spnome", Nome);
                cmd.Parameters.AddWithValue("spcargahoraria", CargaHoraria);

                if (cmd.ExecuteNonQuery() > 0)
                    atualizado = true;

                cmd.Connection.Close();
            }

            return atualizado;
        }

        public bool Alterar()
        {
            return Atualizar();
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
                cmd.CommandText = "sp_disciplina_delete";

                cmd.Parameters.AddWithValue("spiddisciplina", IdDisciplina);

                if (cmd.ExecuteNonQuery() > 0)
                    excluido = true;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Disciplina ObterPorId(int idDisciplina)
        {
            Disciplina disciplina = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_disciplina_getbyid";
                cmd.Parameters.AddWithValue("spiddisciplina", idDisciplina);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    disciplina = new Disciplina(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.GetInt32(3)
                    );

                    // Carrega o objeto relacionado Curso de forma automatizada
                    disciplina.Curso = Curso.ObterPorId(disciplina.IdCurso);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return disciplina;
        }

        // ==========================
        // LISTAR (Retorna List<Disciplina>)
        // ==========================
        public static List<Disciplina> ObterLista(string busca = "")
        {
            List<Disciplina> disciplinas = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Se houver parâmetro de busca, utiliza a procedure de busca filtrada; caso contrário, a listagem geral
                if (string.IsNullOrEmpty(busca))
                {
                    cmd.CommandText = "sp_disciplina_getall";
                }
                else
                {
                    cmd.CommandText = "sp_disciplina_search";
                    cmd.Parameters.AddWithValue("spbusca", $"%{busca}%");
                }

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var disciplina = new Disciplina(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.GetInt32(3)
                    );

                    // Preenche o relacionamento de chave estrangeira
                    disciplina.Curso = Curso.ObterPorId(disciplina.IdCurso);

                    disciplinas.Add(disciplina);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return disciplinas;
        }
    }
}