using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestions;
using Dao;

namespace Program
{
    class Program
    
    {
        private static DaoVisite daoVisite = DaoVisite.Instance;
        static void Main(string[] args)
        {
            TestAuthentification();

        }
        static void TestAuthentification()
        {
           
            Hopital hopital = Hopital.Instance;
            //Authentification gestionAuthentification = Authentification.Instance;

            Console.Write("Entrez votre login : ");
            string login = Console.ReadLine();


            Console.Write("Entrez votre mot de passe : ");
            string password = Console.ReadLine();
            Utilisateur utilisateur = new Utilisateur(login, password);

            Utilisateur utilisateurAuthentifie = gestionAuthentification.Authentifier(login, password);
            if (utilisateurAuthentifie != null)
            {
                switch (utilisateurAuthentifie.Role)
                {


                    case Role.secretaire:
                        afficherMenuSecretaire(utilisateur);

                        break;

                    case Role.medecin1:

                        afficherMenuMedecin(utilisateur);
                        break;
                    case Role.medecin2:
                        Console.WriteLine("Menu pour médecin");
                        break;
                    default:
                        Console.WriteLine("Métier inconnu");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Échec de l'authentification. Accès refusé.");

            }



        }
        static void afficherMenuSecretaire(Utilisateur utilisateurAuthentifie)
        {
            int choixSec;
            do
            {
                Console.WriteLine("Menu secrétaire :");

                Console.WriteLine("1. Rajouter un patient à la file d'attente");


                Console.WriteLine("2. Afficher l'état de la liste d'attente");


                Console.WriteLine("3. Afficher le prochain patient de la liste d'attente");

                Console.WriteLine("4. Afficher les visites d'un patient");
                Console.WriteLine("5. Quitter l'interface secrétaire et revenir au menu principal");

                Console.Write("Entrez votre choix : ");
                choixSec = Convert.ToInt32(Console.ReadLine());
                switch (choixSec)
                {
                    case 1:
                        // Logique pour ajouter un patient à la file d'attente


                        ajouterPatientEnAttente(utilisateurAuthentifie);

                        break;

                    case 2:
                        // Logique pour  Afficher l'état de la liste d'attentee

                        afficherListeAttente(utilisateurAuthentifie);

                        break;

                    case 3:
                        // Logique pour Afficher le prochain patient de la liste d'attente"
                        afficherProchainPatient(utilisateurAuthentifie);

                        break;

                    case 4:
                        // Logique pour Afficher les visites d'un patient

                        break;
                    case 5:
                        // Logique pour Quitter l'interface secrétaire et revenir au menu principal
                        Console.WriteLine("Retour au menu principal.");
                        afficherMenuSecretaire(utilisateurAuthentifie);
                        break;

                    default:
                        Console.WriteLine("Option invalide. Veuillez choisir à nouveau.");
                        break;
                }


            } while (choixSec != 5);




        }

        static void afficherMenuMedecin(Utilisateur utilisateurAuthentifie)
        {
            int choixSec;
            do
            {
                Console.WriteLine("Menu medecin :");

                Console.WriteLine("1. Rendre la salle dispo");
                Console.WriteLine("2. afficher la file d attente");
                Console.WriteLine("3. afficher la liste des visites");
                Console.WriteLine("4. Quitter l'interface medecin et revenir au menu principal");

                Console.Write("Entrez votre choix : ");
                choixSec = Convert.ToInt32(Console.ReadLine());
                switch (choixSec)
                {
                    case 1:
                        // Logique pour Rendre la salle dispo



                        break;

                    case 2:
                        // Logique pour  fficher la file d attente
                        afficherListeAttente(utilisateurAuthentifie);


                        break;

                    case 3:
                        // Logique pour afficher la liste des visites"
                        afficherListeVisites(utilisateurAuthentifie);

                        break;
                    case 4:
                        // Logique pour Quitter l'interface medecin et revenir au menu principal"
                        Console.WriteLine("Retour au menu principal.");
                        afficherMenuMedecin(utilisateurAuthentifie);

                        break;



                    default:
                        Console.WriteLine("Option invalide. Veuillez choisir à nouveau.");
                        break;
                }


            } while (choixSec != 4);




        }
        static void ajouterPatientEnAttente(Hopital  hopital)
        {
        
            // Exemple d'ajout de patient à la file d'attente
            Console.WriteLine("Entrez le nom du patient à ajouter à la file d'attente : ");
            string nomPatient = Console.ReadLine();
            Console.WriteLine("Entrez le prenom du patient à ajouter à la file d'attente : ");
            string prenomPatient = Console.ReadLine();
            //Console.WriteLine("Entrez l'age du patient à ajouter à la file d'attente : ");
            //int agePatient = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Entrez l'adresse du patient à ajouter à la file d'attente : ");
            string adressePatient = Console.ReadLine();
            Console.WriteLine("Entrez telephone du patient à ajouter à la file d'attente : ");
            string telephonePatient = Console.ReadLine();


            //utilisateurAuthentifie.ajouterPatientEnAttente(new Patient(nomPatient, prenomPatient, agePatient, adressePatient, telephonePatient));
            hopital.Add(new Patient(nomPatient, prenomPatient, adressePatient, telephonePatient));


        }

        static void afficherListeAttente(Utilisateur utilisateurAuthentifie)
        {

            utilisateurAuthentifie.afficherListeAttente();
        }
        static void afficherProchainPatient(Utilisateur utilisateurAuthentifie)
        {
            utilisateurAuthentifie.afficherProchainPatient();


        }
        static void afficherListeVisites()
        {

            List<Visite> visite = daoVisite.SelectAll();
            foreach (Visite v in visite)
                Console.WriteLine(v.Id + "\t" + v.IdPatient + "\t" + v.Date + "\t" + v.Medecin + "\t" + v.NumSalle + "\t" + v.Tarif);
        }

        static void afficherListeVisitesPatient()
        {

            int idPatient = 6;

          Visite v = daoVisite.SelectByIdPatient(idPatient);
            if (v != null)
                Console.WriteLine(v.Id + "\t" + v.IdPatient + "\t" + v.Date + "\t" + v.Medecin + "\t" + v.NumSalle + "\t" + v.Tarif);
            else
                Console.WriteLine("visite " + idPatient + "  introuvable");




        }

    }

}
