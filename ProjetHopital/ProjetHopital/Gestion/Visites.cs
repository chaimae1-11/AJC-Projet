using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion
{
    public class Visites
    {
        private int id;
        private int idPatient;
        private string date;
        private string medecin;
        private int numSalle;
        private int tarif;
        public Visites(int idPatient, string date, string medecin, int numSalle, int tarif)
        {
            this.idPatient = idPatient;
            this.date = date;
            this.medecin = medecin;
            this.numSalle = numSalle;
            this.tarif = tarif;
        }
        public Visites(int id, int idPatient, string date, string medecin, int numSalle, int tarif)
        {
            this.id = id;
            this.idPatient = idPatient;
            this.date = date;
            this.medecin = medecin;
            this.numSalle = numSalle;
            this.tarif = tarif;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int IdPatient
        {
            get
            {
                return idPatient;
            }
        }
        public string Date
        {
            get
            {
                return date;
            }
        }
        public string Medecin
        {
            get
            {
                return medecin;
            }
        }
        public int NumSalle
        {
            get
            {
                return numSalle;
            }
        }
        public int Tarif
        {
            get
            {
                return tarif;
            }
        }


    }
}
