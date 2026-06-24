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
        //public DateTime? DataNascimento { get; set; }
        public string? Endereco { get; set; }
        //public string? StatusAcademico { get; set; }

        // Objeto de relacionamento
        public Usuario? Usuario { get; set; }

        // Construtor vazio
        public Aluno()
        {
            IdAluno = 0;

            IdUsuario = 0;

            Matricula = string.Empty;

            Cpf = string.Empty;

            Telefone = string.Empty;

            Endereco = string.Empty;
        }

        // Construtor com ID
        public Aluno(int idAluno)
        {
            IdAluno = idAluno;
        }

        // Construtor completo
        public Aluno(int idAluno, int idUsuario, string? matricula, string? cpf, string? telefone, string? endereco)
        {
            IdAluno = idAluno;
            IdUsuario = idUsuario;
            Matricula = matricula;
            Cpf = cpf;
            Telefone = telefone;
            //DataNascimento = dataNascimento;
            Endereco = endereco;
            //StatusAcademico = statusAcademico;
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
                cmd.CommandText = "sp_inserir_aluno";

                cmd.Parameters.AddWithValue("p_id_usuario", IdUsuario);
                cmd.Parameters.AddWithValue("p_cpf", Cpf);
                cmd.Parameters.AddWithValue("p_matricula", Matricula);
                cmd.Parameters.AddWithValue("p_telefone", Telefone);
                cmd.Parameters.AddWithValue("p_endereco", Endereco);

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
                cmd.CommandText = "sp_atualizar_aluno";

                cmd.Parameters.AddWithValue("p_id", IdAluno);
                cmd.Parameters.AddWithValue("p_cpf", Cpf);
                cmd.Parameters.AddWithValue("p_matricula", Matricula);
                cmd.Parameters.AddWithValue("p_telefone", Telefone);
                cmd.Parameters.AddWithValue("p_endereco", Endereco);

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
                cmd.CommandText = "sp_excluir_aluno";

                cmd.Parameters.AddWithValue("p_id", IdAluno);

                if (cmd.ExecuteNonQuery() > 0)
                    excluido = true;

                cmd.Connection.Close();
            }

            return excluido;
        }

        // ==========================
        // OBTER POR ID
        // ==========================
        public static Aluno ObterPorId(int id)
        {
            Aluno aluno = new();
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"SELECT id_aluno, id_usuario, matricula," +
                    " cpf, telefone, endereco FROM alunos  WHERE id_aluno = @id";

                cmd.Parameters.AddWithValue("@id", id);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    aluno = new(

                    dr.GetInt32(0),

                    dr.GetInt32(1),

                    dr.IsDBNull(2) ? null : dr.GetString(2),

                    dr.IsDBNull(3) ? null : dr.GetString(3),

                    dr.IsDBNull(4) ? null : dr.GetString(4),

                    dr.IsDBNull(5) ? null : dr.GetString(5)

                        );
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
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"SELECT id_aluno, id_usuario, matricula, cpf, telefone, endereco FROM alunos";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Aluno aluno = new(

                    dr.GetInt32(0),

                    dr.GetInt32(1),

                    dr.IsDBNull(2) ? null : dr.GetString(2),

                    dr.IsDBNull(3) ? null : dr.GetString(3),

                    dr.IsDBNull(4) ? null : dr.GetString(4),

                    dr.IsDBNull(5) ? null : dr.GetString(5)                  

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