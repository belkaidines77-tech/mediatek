using System.Collections.Generic;
using MySql.Data.MySqlClient;
using mediatek.bddmanager;
using mediatek.Models;

namespace mediatek.dal
{
    public class personneldal
    {
        private BddManager bddManager;

        public personneldal()
        {
            bddManager = BddManager.GetInstance();
        }

        public List<personnel> GetAllPersonnels()
        {
            List<personnel> personnels = new List<personnel>();
            string query = "SELECT idpersonnel, nom, prenom, tel, mail, idservice FROM personnel";

            MySqlConnection conn = bddManager.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                personnel p = new personnel();
                p.idpersonnel = reader.GetInt32("idpersonnel");
                p.nom = reader.GetString("nom");
                p.prenom = reader.GetString("prenom");
                p.tel = reader.IsDBNull(reader.GetOrdinal("tel")) ? "" : reader.GetString("tel");
                p.mail = reader.IsDBNull(reader.GetOrdinal("mail")) ? "" : reader.GetString("mail");
                p.idservice = reader.GetInt32("idservice");
                personnels.Add(p);
            }
            reader.Close();
            conn.Close();
            return personnels;
        }

        public int AddPersonnel(personnel p)
        {
            string query = "INSERT INTO personnel (nom, prenom, tel, mail, idservice) VALUES ('" + p.nom + "', '" + p.prenom + "', '" + p.tel + "', '" + p.mail + "', " + p.idservice + ")";
            MySqlConnection conn = bddManager.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public int UpdatePersonnel(personnel p)
        {
            string query = "UPDATE personnel SET nom='" + p.nom + "', prenom='" + p.prenom + "', tel='" + p.tel + "', mail='" + p.mail + "', idservice=" + p.idservice + " WHERE idpersonnel=" + p.idpersonnel;
            MySqlConnection conn = bddManager.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public int DeletePersonnel(int id)
        {
            string query = "DELETE FROM personnel WHERE idpersonnel=" + id;
            MySqlConnection conn = bddManager.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}