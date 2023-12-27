using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gestion
{
    public class Patients
    {
        private int id;
        private string nom;
        private string prenom;
        private int age;
        private string adresse;
        private string telephone;

        public Patients(int id, string nom, string prenom, int age, string adresse, string telephone)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
            this.adresse = adresse;
            this.telephone = telephone;
        }
        public int Id
        {
            get
            {
                return id;
            }
        }
        public string Nom
        {
            get
            {
                return nom;
            }
        }
        public string Prenom
        {
            get
            {
                return prenom;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
        }

        public string Adresse
        {
            get
            {
                return adresse;
            }
        }
        public string Telephone
        {
            get
            {
                return telephone;
            }
        }


    }
}
