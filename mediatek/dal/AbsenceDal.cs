using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using mediatek.bddmanager;
using mediatek.Models;

namespace mediatek.dal
{
    public class AbsenceDal
    {
        private BddManager _bddManager;

        public AbsenceDal()
        {
            _bddManager = BddManager.GetInstance();
        }

        public List<absence> GetAbsencesByPersonnel(int idpersonnel)
        {
            List<absence> absences = new List<absence>();
            string query = "SELECT idpersonnel, datedebut, datefin, idmotif FROM absence WHERE idpersonnel = @idpersonnel ORDER BY datedebut DESC";

            MySqlConnection conn = _bddManager.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idpersonnel", idpersonnel);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                absence a = new absence();
                a.idpersonnel = reader.GetInt32("idpersonnel");
                a.datedebut = reader.GetDateTime("datedebut");
                a.datefin = reader.GetDateTime("datefin");
                a.idmotif = reader.GetInt32("idmotif");
                absences.Add(a);
            }
            reader.Close();
            conn.Close();
            return absences;
        }

        // Vérifie si une absence chevauche une autre (pour ajout ou modification)
        public bool IsChevauchement(int idpersonnel, DateTime datedebut, DateTime datefin, DateTime? ancienneDebut = null)
        {
            string query = @"
                SELECT COUNT(*) FROM absence 
                WHERE idpersonnel = @idpersonnel 
                AND datedebut < @datefin 
                AND datefin > @datedebut";

            if (ancienneDebut.HasValue)
            {
                query += " AND datedebut != @ancienneDebut";
            }

            MySqlConnection conn = _bddManager.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idpersonnel", idpersonnel);
            cmd.Parameters.AddWithValue("@datedebut", datedebut);
            cmd.Parameters.AddWithValue("@datefin", datefin);
            if (ancienneDebut.HasValue)
                cmd.Parameters.AddWithValue("@ancienneDebut", ancienneDebut.Value);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return count > 0;
        }

        public string AddAbsence(absence a)
        {
            if (IsChevauchement(a.idpersonnel, a.datedebut, a.datefin))
                return "Erreur : chevauchement avec une absence existante";

            string query = @"
                INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif) 
                VALUES (@idpersonnel, @datedebut, @datefin, @idmotif)";

            MySqlConnection conn = _bddManager.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idpersonnel", a.idpersonnel);
            cmd.Parameters.AddWithValue("@datedebut", a.datedebut);
            cmd.Parameters.AddWithValue("@datefin", a.datefin);
            cmd.Parameters.AddWithValue("@idmotif", a.idmotif);
            cmd.ExecuteNonQuery();
            conn.Close();
            return "OK";
        }

        public string UpdateAbsence(absence a, DateTime ancienneDebut)
        {
            if (IsChevauchement(a.idpersonnel, a.datedebut, a.datefin, ancienneDebut))
                return "Erreur : chevauchement avec une absence existante";

            string query = @"
                UPDATE absence 
                SET datedebut = @datedebut, datefin = @datefin, idmotif = @idmotif 
                WHERE idpersonnel = @idpersonnel AND datedebut = @ancienneDebut";

            MySqlConnection conn = _bddManager.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@datedebut", a.datedebut);
            cmd.Parameters.AddWithValue("@datefin", a.datefin);
            cmd.Parameters.AddWithValue("@idmotif", a.idmotif);
            cmd.Parameters.AddWithValue("@idpersonnel", a.idpersonnel);
            cmd.Parameters.AddWithValue("@ancienneDebut", ancienneDebut);
            cmd.ExecuteNonQuery();
            conn.Close();
            return "OK";
        }

        public int DeleteAbsence(int idpersonnel, DateTime datedebut)
        {
            string query = "DELETE FROM absence WHERE idpersonnel = @idpersonnel AND datedebut = @datedebut";
            MySqlConnection conn = _bddManager.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idpersonnel", idpersonnel);
            cmd.Parameters.AddWithValue("@datedebut", datedebut);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}