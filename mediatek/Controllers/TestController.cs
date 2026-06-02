using Microsoft.AspNetCore.Mvc;
using mediatek.bddmanager;
using MySql.Data.MySqlClient;

namespace mediatek.Controllers
{
    public class TestController : Controller
    {
        public string Index()
        {
            try
            {
                BddManager bdd = BddManager.GetInstance();
                MySqlConnection conn = bdd.GetConnection();
                conn.Open();
                string result = "Connexion reussie a la base 'mediatek' !";
                conn.Close();
                return result;
            }
            catch (MySqlException e)
            {
                return "ERREUR : " + e.Message;
            }
        }
    }
}