using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAcademyClasses
{
    internal class Professor
    {

        // ============================
        // ATRIBUTOS / PROPRIEDADES
        // ============================

        public int IdProfessor { get; set; }

        public int IdUsuario { get; set; }

        public string Cpf { get; set; }

        public string Especialidade { get; set; }


        // ============================
        // CONSTRUTOR VAZIO
        // ============================

        public Professor()
        {

        }


        // ============================
        // CONSTRUTOR COMPLETO
        // ============================

        public Professor(
            int idProfessor,
            int idUsuario,
            string cpf,
            string especialidade)
        {
            IdProfessor = idProfessor;

            IdUsuario = idUsuario;

            Cpf = cpf;

            Especialidade = especialidade;
        }


        // ============================
        // INSERIR
        // ============================

        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_professor_insert";

            cmd.Parameters.AddWithValue("p_id_usuario", IdUsuario);

            cmd.Parameters.AddWithValue("p_cpf", Cpf);

            cmd.Parameters.AddWithValue("p_especialidade", Especialidade);

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
        }


        // ============================
        // ALTERAR
        // ============================

        public void Alterar()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_professor_update";

            cmd.Parameters.AddWithValue("p_id_professor", IdProfessor);

            cmd.Parameters.AddWithValue("p_cpf", Cpf);

            cmd.Parameters.AddWithValue("p_especialidade", Especialidade);

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
        }


        // ============================
        // EXCLUIR
        // ============================

        public void Excluir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_professor_delete";

            cmd.Parameters.AddWithValue("p_id_professor", IdProfessor);

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
        }


        // ============================
        // LISTAR
        // ============================

        public static DataTable Listar()
        {
            DataTable tabela = new DataTable();

            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_professor_select";

            tabela.Load(cmd.ExecuteReader());

            cmd.Connection.Close();

            return tabela;
        }

    }
}
