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
    public class DaoPatients
    {
        public bool Delete(int id)
        {
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "delete Patients where id = " + id;

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);


            connection1.Open();
            command.ExecuteNonQuery();
            connection1.Close();
            return true;

        }
        public bool Update(Patients p)
        {
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "update Patients set nom = @nom, prenom = @prenom, age = @age, adresse = @adresse, telephone = @telephone where id = @id;";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            command.CommandText = sql;

            command.Parameters.Add("id", SqlDbType.Int).Value = p.Id;
            command.Parameters.Add("nom", SqlDbType.NVarChar).Value = p.Nom;
            command.Parameters.Add("prenom", SqlDbType.NVarChar).Value = p.Prenom;
            command.Parameters.Add("age", SqlDbType.Int).Value = p.Age;
            command.Parameters.Add("adresse", SqlDbType.NVarChar).Value = p.Adresse;
            command.Parameters.Add("telephone", SqlDbType.NVarChar).Value = p.Telephone;

            connection1.Open();
            command.ExecuteNonQuery();
            connection1.Close();
            return true;

        }
        public List<Patients> SelectAll()
        {
            List<Patients> liste = new List<Patients>();
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "select * from Patients";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            connection1.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                liste.Add(new Patients(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5)));
            }
            connection1.Close();

            return liste;
        }
        public Patients SelectById(int id)
        {

            Patients p = null;
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "select * from Patients where id= " + id;

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            connection1.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                p = new Patients(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));

            connection1.Close();

            return p;
        }

        public bool Insert(Patients p)
        {
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "insert into Patients values(@id,@nom,@prenom,@age,@adresse,@telephone)";


            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = connection1.CreateCommand();
            command.CommandText = sql;

            command.Parameters.Add("id", SqlDbType.Int).Value = p.Id;
            command.Parameters.Add("nom", SqlDbType.NVarChar).Value = p.Nom;
            command.Parameters.Add("prenom", SqlDbType.NVarChar).Value = p.Prenom;
            command.Parameters.Add("age", SqlDbType.Int).Value = p.Age;
            command.Parameters.Add("adresse", SqlDbType.NVarChar).Value = p.Adresse;
            command.Parameters.Add("telephone", SqlDbType.NVarChar).Value = p.Telephone;


            connection1.Open();
            command.ExecuteNonQuery();
            connection1.Close();

            return true;
        }
    }
}
