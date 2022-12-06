using MySql.Data.MySqlClient;

namespace MyBdd
{
    public class Bdd
    {
        private MySqlConnection connection;
        public Bdd() {
            string connectionString = "SERVER=127.0.0.1; DATABASE=mli; UID=root; PASSWORD=";
            this.connection = new MySqlConnection(connectionString);
        }

        protected MySqlDataReader ExecQuery(string sql)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = sql;
            MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
            this.connection.Close();
            return mySqlDataReader;
        }
    }
}