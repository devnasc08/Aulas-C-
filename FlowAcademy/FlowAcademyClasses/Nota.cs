using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAcademyClasses
{
    public class Nota
    {
        // ============================
        // ATRIBUTOS / PROPRIEDADES
        // ============================

        public int IdNota { get; set; }

        public int IdMatricula { get; set; }

        public int IdDisciplina { get; set; }

        public decimal Nota1 { get; set; }

        public decimal Nota2 { get; set; }

        public decimal MediaFinal { get; set; }

        public string Status { get; set; }


        // ============================
        // CONSTRUTOR VAZIO
        // ============================

        public Nota()
        {

        }


        // ============================
        // CONSTRUTOR COMPLETO
        // ============================

        public Nota(
            int idNota,
            int idMatricula,
            int idDisciplina,
            decimal nota1,
            decimal nota2,
            decimal mediaFinal,
            string status)
        {
            IdNota = idNota;
            IdMatricula = idMatricula;
            IdDisciplina = idDisciplina;
            Nota1 = nota1;
            Nota2 = nota2;
            MediaFinal = mediaFinal;
            Status = status;
        }


        // ============================
        // MÉTODO PARA CALCULAR MÉDIA
        // ============================

        /*
         * Como o projeto foi simplificado,
         * todos os cálculos serão feitos em C#.
         *
         * A média é a soma das duas notas
         * dividida por 2.
         */

        public void CalcularMedia()
        {
            MediaFinal = (Nota1 + Nota2) / 2;
        }


        // ============================
        // MÉTODO PARA DEFINIR STATUS
        // ============================

        /*
         * Regra:
         *
         * Média >= 7
         * -> Aprovado
         *
         * Média < 7
         * -> Reprovado
         */

        public void VerificarStatus()
        {
            if (MediaFinal >= 7)
            {
                Status = "aprovado";
            }
            else
            {
                Status = "reprovado";
            }
        }


        // ============================
        // INSERIR
        // ============================

        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_nota_insert";

            cmd.Parameters.AddWithValue("p_id_matricula", IdMatricula);

            cmd.Parameters.AddWithValue("p_id_disciplina", IdDisciplina);

            cmd.Parameters.AddWithValue("p_nota_1", Nota1);

            cmd.Parameters.AddWithValue("p_nota_2", Nota2);

            cmd.Parameters.AddWithValue("p_media_final", MediaFinal);

            cmd.Parameters.AddWithValue("p_status", Status);

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

            cmd.CommandText = "sp_nota_update";

            cmd.Parameters.AddWithValue("p_id_nota", IdNota);

            cmd.Parameters.AddWithValue("p_nota_1", Nota1);

            cmd.Parameters.AddWithValue("p_nota_2", Nota2);

            cmd.Parameters.AddWithValue("p_media_final", MediaFinal);

            cmd.Parameters.AddWithValue("p_status", Status);

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

            cmd.CommandText = "sp_nota_delete";

            cmd.Parameters.AddWithValue("p_id_nota", IdNota);

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

            cmd.CommandText = "sp_nota_select";

            tabela.Load(cmd.ExecuteReader());

            cmd.Connection.Close();

            return tabela;
        }

    }

}
