using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class AlertaRisco
    {
        // Propriedades
        public int IdAlerta { get; set; }

        public int IdMatricula { get; set; }

        public string? TipoRisco { get; set; }

        public decimal Score { get; set; }

        public string? Status { get; set; }


        // Objeto de relacionamento
        public Matricula? Matricula { get; set; }


        // Construtor vazio
        public AlertaRisco()
        {
            IdAlerta = 0;
            IdMatricula = 0;
            TipoRisco = "";
            Score = 0;
            Status = "pendente";
        }


        // Construtor com ID
        public AlertaRisco(int idAlerta)
        {
            IdAlerta = idAlerta;
        }


        // Construtor completo
        public AlertaRisco(
            int idAlerta,
            int idMatricula,
            string? tipoRisco,
            decimal score,
            string? status)
        {
            IdAlerta = idAlerta;
            IdMatricula = idMatricula;
            TipoRisco = tipoRisco;
            Score = score;
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

                cmd.CommandText = "sp_alertarisco_insert";

                cmd.Parameters.AddWithValue("spidmatricula", IdMatricula);
                cmd.Parameters.AddWithValue("sptiporisco", TipoRisco);
                cmd.Parameters.AddWithValue("spscore", Score);
                cmd.Parameters.AddWithValue("spstatus", Status);

                IdAlerta = Convert.ToInt32(cmd.ExecuteScalar());

                inserido = IdAlerta > 0;

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

            if (IdAlerta < 1)
                return atualizado;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_alertarisco_update";

                cmd.Parameters.AddWithValue("spidalerta", IdAlerta);
                cmd.Parameters.AddWithValue("spidmatricula", IdMatricula);
                cmd.Parameters.AddWithValue("sptiporisco", TipoRisco);
                cmd.Parameters.AddWithValue("spscore", Score);
                cmd.Parameters.AddWithValue("spstatus", Status);

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

            if (IdAlerta < 1)
                return excluido;

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_alertarisco_delete";

                cmd.Parameters.AddWithValue("spidalerta", IdAlerta);

                if (cmd.ExecuteNonQuery() > 0)
                    excluido = true;

                cmd.Connection.Close();
            }

            return excluido;
        }


        // ==========================
        // OBTER POR ID
        // ==========================
        public static AlertaRisco ObterPorId(int idAlerta)
        {
            AlertaRisco alerta = new();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_alertarisco_getbyid";

                cmd.Parameters.AddWithValue("spidalerta", idAlerta);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    alerta = new AlertaRisco(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.GetDecimal(3),
                        dr.IsDBNull(4) ? null : dr.GetString(4)
                    );

                    // Carrega o objeto relacionado Matricula
                    alerta.Matricula = Matricula.ObterPorId(alerta.IdMatricula);
                }

                dr.Close();

                cmd.Connection.Close();
            }

            return alerta;
        }


        // ==========================
        // LISTAR
        // ==========================
        public static List<AlertaRisco> ObterLista()
        {
            List<AlertaRisco> alertas = new();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_alertarisco_getall";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var alerta = new AlertaRisco(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.IsDBNull(2) ? null : dr.GetString(2),
                        dr.GetDecimal(3),
                        dr.IsDBNull(4) ? null : dr.GetString(4)
                    );

                    alerta.Matricula = Matricula.ObterPorId(alerta.IdMatricula);

                    alertas.Add(alerta);
                }

                dr.Close();

                cmd.Connection.Close();
            }

            return alertas;
        }
    }
}