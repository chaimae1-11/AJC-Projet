using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion
{
    public class Authentification
    {
        private string login;
        private string password;
        private string nom;
        private int metier;
        public Authentification(string login, string password, string nom, int metier)
        {
            this.login = login;
            this.password = password;
            this.nom = nom;
            this.metier = metier;
        }
        public string Login
        {
            get
            {
                return login;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
        }
        public string Nom
        {
            get
            {
                return nom;
            }
        }
        public int Metier
        {
            get
            {
                return metier;
            }
        }

    }
}
