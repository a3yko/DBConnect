using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Npgsql;

namespace Database_Connector
{
    class Server
    {
        private DataTable output = new DataTable();
        private string username;
        private string password;
        private string db;
        private string ip;
        public Server(string username, string password, string ip, string db)
        {
            this.username = username;
            this.password = password;
            this.db = db;
            this.ip = ip;
        }

        public DataTable RunSQLQuery(string query)
        {
            string connStr = "server=" + this.ip + ";user=" + this.username + ";database=" + this.db + ";port=3306;password=" + this.password;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                MySqlCommand cmd = new MySqlCommand(query, conn);
                using(MySqlDataAdapter a = new MySqlDataAdapter(cmd))
                {
                    a.Fill(output);
                }
                conn.Close();
                Console.WriteLine("Done.");
                return output;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return output;
            }
       

        }

        public DataTable Runpsql(string query)
        {
            string connStr = "server=" + this.ip + ";user=" + this.username + ";database=" + this.db + ";port=3306;password=" + this.password;
            var conn = new NpgsqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to PostgresSQL....");
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                using(NpgsqlDataAdapter a = new NpgsqlDataAdapter(cmd))
                {
                    a.Fill(output);
                }
                conn.Close();
                Console.WriteLine("Done.");
                return output;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return output;
            }
            
        }

    }
}
