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

    public class DaoVisites
    {
        private static DaoVisites instance = new DaoVisites();
        private DaoVisites()
        {

        }
        public static DaoVisites Instance
        {
            get
            {
                return instance;
            }

        }

        public bool Insert(Visite v)
        {
            string connectionString = @"Data Source=SECRETHOME;Initial Catalog=cs-db;Integrated Security=True";
            string sql = "insert into Visites values(@id,@idPatient,@date,@medecin,@num-salle,@tarif)";


            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = connection1.CreateCommand();
            command.CommandText = sql;

            command.Parameters.Add("id", SqlDbType.Int).Value = v.Id;
            command.Parameters.Add("idPatient", SqlDbType.Int).Value = v.IdPatient;
            command.Parameters.Add("date", SqlDbType.DateTime).Value = v.Date;
            command.Parameters.Add("medecin", SqlDbType.NVarChar).Value = v.Medecin;
            command.Parameters.Add("numSalle", SqlDbType.Int).Value = v.NumSalle;
            command.Parameters.Add("tarif", SqlDbType.Int).Value = v.Tarif;

            connection1.Open();
            command.ExecuteNonQuery();
            connection1.Close();

            return true;
        }
        public List<Visite> SelectAll()
        {

            List<Visite> liste = new List<Visite>();


            string connectionString = @"Data Source=SECRETHOME;Initial Catalog=cs-db;Integrated Security=True";
            string sql = "select * from Visites";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            connection1.Open();

            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                Visite v = new Visite(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));
                liste.Add(v);

            }


            connection1.Close();
            return liste;
        }


        public Visite SelectById(int id)
        {
            Visite v = null;
            string connectionString = @"Data Source=SECRETHOME;Initial Catalog=cs-db;Integrated Security=True";
            string sql = "select * from Visites where id=" + id;

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            connection1.Open();

            SqlDataReader reader = command.ExecuteReader();



            if (reader.Read())

                v = new Visite(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));


            connection1.Close();

            return v;

        }

        public Visite SelectByIdPatient(int idPatient)
        {
            Visite v = null;
            string connectionString = @"Data Source=SECRETHOME;Initial Catalog=cs-db;Integrated Security=True";
            string sql = "select * from Visites where idPatient=" + idPatient;

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            connection1.Open();

            SqlDataReader reader = command.ExecuteReader();




            if (reader.Read())

                v = new Visite(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));


            connection1.Close();

            return v;

        }
        public bool Update(Visite v)
        {
            string connectionString = @"Data Source=SECRETHOME;Initial Catalog=cs-db;Integrated Security=True";
            string sql = "update Visites set id=@id,num-salle=@num-salle where idpatient=@idpatient ";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = connection1.CreateCommand();
            command.CommandText = sql;

            command.Parameters.Add("idPatient", SqlDbType.Int).Value = v.IdPatient;
            command.Parameters.Add("id", SqlDbType.Int).Value = v.Id;
            command.Parameters.Add("NumSalle", SqlDbType.Int).Value = v.NumSalle;

            connection1.Open();
            int nb = command.ExecuteNonQuery();
            connection1.Close();
            if (nb > 0)
                return true;

            return false;

        }
        public bool Delete(int id)
        {
            string connectionString = @"Data Source=SECRETHOME;Initial Catalog=cs-db;Integrated Security=True";
            SqlConnection connection1 = new SqlConnection(connectionString);
            connection1.Open();
            //traitement
            string sql = "delete Visites where id = " + id;
            SqlCommand command = new SqlCommand(sql, connection1);
            int nb = command.ExecuteNonQuery();
            connection1.Close();

            if (nb > 0)
                return true;

            return false;

        }

    }
}
