using MySql.Data.MySqlClient;

namespace mediatek.bddmanager
{
    public class BddManager
    {
        private static BddManager instance;
        private string connectionString;
        private MySqlConnection connection;

        private BddManager()
        {
            connectionString = "Server=localhost;Database=mediatek;Uid=mediatek;Pwd=mediatek86;";
            connection = new MySqlConnection(connectionString);
        }

        public static BddManager GetInstance()
        {
            if (instance == null)
                instance = new BddManager();
            return instance;
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}