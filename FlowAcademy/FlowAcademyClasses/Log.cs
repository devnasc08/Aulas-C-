using System;
using System.Collections.Generic;
using System.Data;

namespace FlowAcademyClasses
{
    public class Log
    {
        // Propriedades
        public int IdLog { get; set; }

        public int IdUsuario { get; set; }

        public string? Acao { get; set; }

        public string? Ip { get; set; }

        public DateTime DataEvento { get; set; }


        // Objeto de relacionamento
        public Usuario? Usuario { get; set; }


        // Construtor vazio
        public Log()
        {
            IdLog = 0;
            IdUsuario = 0;
            Acao = "";
            Ip = "";
            DataEvento = DateTime.Now;
        }


        // Construtor com ID
        public Log(int idLog)
        {
            IdLog = idLog;
        }


        // Construtor completo
        public Log(
            int idLog,
            int idUsuario,
            string? acao,
            string? ip,
            DateTime dataEvento)
        {
            IdLog = idLog;
            IdUsuario = idUsuario;
            Acao = acao;
            Ip = ip;
            DataEvento = dataEvento;
        }


        // Construtor parcial para registro simplificado
        public Log(int idUsuario, string? acao, string? ip)
        {
            IdUsuario = idUsuario;
            Acao = acao;
            Ip = ip;
            DataEvento = DateTime.Now;
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

                cmd.CommandText = "sp_log_insert";

                cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
                cmd.Parameters.AddWithValue("spacao", Acao);
                cmd.Parameters.AddWithValue("spip", Ip);

                IdLog = Convert.ToInt32(cmd.ExecuteScalar());

                inserido = IdLog > 0;

                cmd.Connection.Close();
            }

            return inserido;
        }


        // ==========================
        // OBTER POR ID
        // ==========================
        public static Log ObterPorId(int idLog)
        {
            Log log = new();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_log_getbyid";

                cmd.Parameters.AddWithValue("spidlog", idLog);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    log = new Log(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3),
                        dr.GetDateTime(4)
                    );

                    // Carrega o objeto Usuario (caso o método estático exista na classe Usuario)
                    log.Usuario = Usuario.ObterPorId(log.IdUsuario);
                }

                dr.Close();

                cmd.Connection.Close();
            }

            return log;
        }


        // ==========================
        // LISTAR
        // ==========================
        public static List<Log> ObterLista()
        {
            List<Log> logs = new();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_log_getall";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var log = new Log(
                        dr.GetInt32(0),
                        dr.GetInt32(1),
                        dr.GetString(2),
                        dr.IsDBNull(3) ? null : dr.GetString(3),
                        dr.GetDateTime(4)
                    );

                    log.Usuario = Usuario.ObterPorId(log.IdUsuario);

                    logs.Add(log);
                }

                dr.Close();

                cmd.Connection.Close();
            }

            return logs;
        }


        // ==========================
        // MÉTODOS ESTÁTICOS DE AUXÍLIO
        // ==========================
        public static bool Registrar(int idUsuario, string? acao, string? ip = null)
        {
            Log log = new(idUsuario, acao, ip);
            return log.Inserir();
        }
    }
}