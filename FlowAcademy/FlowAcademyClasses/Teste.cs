using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAcademyClasses
{
    internal class Teste
    {


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


    }
}
