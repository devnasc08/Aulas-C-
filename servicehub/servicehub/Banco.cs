using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceHubClass;


using MySql.Data.MySqlClient;

namespace Servicehub
{
    public class Banco
    {
        

        // -- String de conexão com o Banco de Dados (MariaDB)
        public static string? StrConn { get; set; }

        /*
         Método para abrir conexão com o banco - Entrega uma conexão aberta,
         no objeto de comandos MySql (Um objeto do tipo MySqlCommand)
        */

        public static MySqlCommand Abrir(string strconn = "")
        {
            MySqlCommand cmd = new MySqlCommand();
            // cmd - Objeto MySql
            StrConn = strconn;
            if (strconn == string.Empty)
                // Expressão Regular
                StrConn = $@"server = 10.91.47.120;database=comercialti101;user=root;password=202720";
            MySqlConnection cn = new(StrConn);
            try
            {
                cn.Open();
                cmd.Connection = cn;
               // cn  
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cmd;
        }
        

    }
}
