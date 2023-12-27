using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Gestion;

namespace Dao
{
    public class DaoAuthentification
    {
        public bool Delete(string login)
        {
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "delete Authentification where login = '" + login + "'";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);


            connection1.Open();
            command.ExecuteNonQuery();
            connection1.Close();
            return true;

        }
        public bool Update(Authentification a)
        {
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "update Authentification set password = @password, nom = @nom, metier = @metier where login = @login";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            command.CommandText = sql;

            command.Parameters.Add("login", SqlDbType.NVarChar).Value = a.Login;
            command.Parameters.Add("password", SqlDbType.NVarChar).Value = a.Password;
            command.Parameters.Add("nom", SqlDbType.NVarChar).Value = a.Nom;
            command.Parameters.Add("metier", SqlDbType.Int).Value = a.Metier;

            connection1.Open();
            command.ExecuteNonQuery();
            connection1.Close();
            return true;

        }
        public List<Authentification> SelectAll()
        {
            List<Authentification> liste = new List<Authentification>();
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "select * from Authentification";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            connection1.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                liste.Add(new Authentification(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
            }
            connection1.Close();

            return liste;
        }
        public Authentification SelectByLogin(string login)
        {

            Authentification a = null;
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "select * from Authentification where login= '" + login + "'";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            connection1.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                a = new Authentification(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));

            connection1.Close();

            return a;
        }

        public bool Insert(Authentification a)
        {
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "insert into Authentification values(@login,@password,@nom,@metier)";


            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = connection1.CreateCommand();
            command.CommandText = sql;

            command.Parameters.Add("login", SqlDbType.NVarChar).Value = a.Login;
            command.Parameters.Add("password", SqlDbType.NVarChar).Value = a.Password;
            command.Parameters.Add("nom", SqlDbType.NVarChar).Value = a.Nom;
            command.Parameters.Add("metier", SqlDbType.Int).Value = a.Metier;

            connection1.Open();
            command.ExecuteNonQuery();
            connection1.Close();

            return true;
        }
    }
}
