using MySql.Data.MySqlClient;


namespace FlowAcademyClasses

{
    public class Banco
    {
        public static string? StrConn { get; set; }

        public static MySqlCommand Abrir(string strconn = "")
        {
            MySqlCommand cmd = new MySqlCommand();

            StrConn = strconn;

            if (strconn == string.Empty)
                StrConn = @"Server=localhost;Port=3306;Database=flow_academy;Uid=root;Pwd=;";

            MySqlConnection cn = new(StrConn);
            try
            {
                cn.Open();
                cmd.Connection = cn;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cmd;

        }
    }
}
