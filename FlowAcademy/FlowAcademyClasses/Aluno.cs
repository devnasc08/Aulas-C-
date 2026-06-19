using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Aluno
    {
        // Propriedades
        public int IdAluno { get; set; }
        public int IdUsuario { get; set; }
        public string? Matricula { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Endereco { get; set; }
        public string? StatusAcademico { get; set; }

        // Objeto de relacionamento
        public Usuario? Usuario { get; set; }

        // Construtor vazio
        public Aluno()
        {
            IdAluno = 0;
            IdUsuario = 0;
            Matricula = "";
            Cpf = "";
            StatusAcademico = "regular";
        }

        // Construtor com ID
        public Aluno(int idAluno)
        {
            IdAluno = idAluno;
        }

        // Construtor completo
        public Aluno(int idAluno, int idUsuario, string? matricula, string? cpf, string? telefone, DateTime? dataNascimento, string? endereco, string? statusAcademico)
        {
            IdAluno = idAluno;
            IdUsuario = idUsuario;
            Matricula = matricula;
            Cpf = cpf;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            StatusAcademico = statusAcademico;
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
                cmd.CommandText = "sp_aluno_insert";

                cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
                cmd.Parameters.AddWithValue("spmatricula", Matricula);
                cmd.Parameters.AddWithValue("spcpf", Cpf);
                cmd.Parameters.AddWithValue("sptelefone", Telefone);
                cmd.Parameters.AddWithValue("spdatanascimento", DataNascimento);
                cmd.Parameters.AddWithValue("spendereco", Endereco);
                cmd.Parameters.AddWithValue("spstatusacademico", StatusAcademico);

                IdAluno = Convert.ToInt32(cmd.ExecuteScalar());
                inserido = IdAluno > 0;

                cmd.Connection.Close();
            }

            return inserido;
        }

        // ==========================
        // ATUALIZAR
        // ==========================
        public bool  Atualizar()
        {
            bool atualizado = false;
            if (IdAluno < 1) return  atualizado;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_aluno_update";

                cmd.Parameters.AddWithValue("spidaluno", IdAluno);
                cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
                cmd.Parameters.AddWithValue("spmatricula", Matricula);
                cmd.Parameters.AddWithValue("spcpf", Cpf);
                cmd.Parameters.AddWithValue("sptelefone", Telefone);
                cmd.Parameters.AddWithValue("spdatanascimento", DataNascimento);
                cmd.Parameters.AddWithValue("spendereco", Endereco);
                cmd.Parameters.AddWithValue("spstatusacademico", StatusAcademico);

                if (cmd.ExecuteNonQuery() > 0)
                    atualizado = true;

                cmd.Connection.Close();
            }

            return  atualizado;
        }

        // ==========================
        // EXCLUIR
        // ==========================
        public bool Excluir()
        {
            bool excluido = false;
            if (IdAluno < 1) return excluido;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_aluno_delete";

                cmd.Parameters.AddWithValue("spidaluno", IdAluno);

                if (cmd.ExecuteNonQuery() > 0)
                    excluido = true;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Aluno ObterPorId(int idAluno)
        {
            Aluno aluno = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_aluno_getbyid";
                cmd.Parameters.AddWithValue("spidaluno", idAluno);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    aluno = new Aluno(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3),
                        dr.IsDBNull(4) ? null : dr.GetString(4),
                        dr.IsDBNull(5) ? (DateTime?)null : dr.GetDateTime(5),
                        dr.IsDBNull(6) ? null : dr.GetString(6),
                        dr.IsDBNull(7) ? null : dr.GetString(7)
                    );

                    // Carrega o relacionamento do Usuario (se aplicável ao seu projeto)
                    aluno.Usuario = Usuario.ObterPorId(aluno.IdUsuario);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return aluno;
        }

        // ==========================
        // LISTAR (Retorna List<Aluno>)
        // ==========================
        public static List<Aluno> ObterLista()
        {
            List<Aluno> alunos = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_aluno_getall";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var aluno = new Aluno(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3),
                        dr.IsDBNull(4) ? null : dr.GetString(4),
                        dr.IsDBNull(5) ? (DateTime?)null : dr.GetDateTime(5),
                        dr.IsDBNull(6) ? null : dr.GetString(6),
                        dr.IsDBNull(7) ? null : dr.GetString(7)
                    );

                    aluno.Usuario = Usuario.ObterPorId(aluno.IdUsuario);
                    alunos.Add(aluno);
                }

                dr.Close();
                cmd.Connection.Close();
            }

            return alunos;
        }

        public bool Cadastrar()
        {
            if (IdUsuario < 1) return false;
            if (string.IsNullOrEmpty(Matricula)) return false;
            if (string.IsNullOrEmpty(Cpf)) return false;

            return Inserir();
        }
    }
}