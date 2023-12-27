//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Gestions;
//using Dao;

//namespace Program
//{
//    class Program

//    {
        

     

//        static void Main(string[] args)
//        {
//            TestAuthentification();

//        }
//        static void TestAuthentification()
//        {
          
//            Hopital hopital = Hopital.Instance;
          

//            Console.Write("Entrez votre login : ");
//            string login = Console.ReadLine();


//            Console.Write("Entrez votre mot de passe : ");
//            string password = Console.ReadLine();
//            Authentification authentifie = new Authentification(login, password);
//            Authentification auth = DaoAuthentification.SelectByLogin(login);
//            if (authentifie == auth)
//            {
//                //switch (authentifie.Metier)
//                //{


//                //    //case authentifie.Metier:
//                //    //    afficherMenuSecretaire(hopital);

//                //    //    break;

//                //    //case Metier.medecin1:

//                //    //    //afficherMenuMedecin(authentifie);
//                //    //    break;
//                //    //case Metier.medecin2:
//                //    //    Console.WriteLine("Menu pour médecin");
//                //    //    break;
//                //    //default:
//                //    //    Console.WriteLine("Métier inconnu");
//                //    //    break;

//                //}
//            }
//            else
//            {
//                Console.WriteLine("Échec de l'authentification. Accès refusé.");

//            }



//        }
//        static void afficherMenuSecretaire(Hopital hopital)
//        {
//            int choixSec;
//            do
//            {
//                Console.WriteLine("Menu secrétaire :");

//                Console.WriteLine("1. Rajouter un patient à la file d'attente");


//                Console.WriteLine("2. Afficher l'état de la liste d'attente");


//                Console.WriteLine("3. Afficher le prochain patient de la liste d'attente");

//                Console.WriteLine("4. Afficher les visites d'un patient");
//                Console.WriteLine("5. Quitter l'interface secrétaire et revenir au menu principal");

//                Console.Write("Entrez votre choix : ");
//                choixSec = Convert.ToInt32(Console.ReadLine());
//                switch (choixSec)
//                {
//                    case 1:
//                        // Logique pour ajouter un patient à la file d'attente
//                        int id = 0;

//                        hopital.Add(DaoPatients.SelectById(id));
//                        Console.WriteLine("le patient avec l'ID " + id + " est ajoute a la file d'attente");
//                        break;

//                    case 2:
//                        // Logique pour  Afficher l'état de la liste d'attentee
//                        Console.WriteLine("l'etat de la liste d'attente " +" \n" + hopital.CheckQueue());
                   

//                        break;

//                    case 3:
//                        // Logique pour Afficher le prochain patient de la liste d'attente"
//                      hopital.Next();
//                        Console.WriteLine("le prochain patient est " + " \n" + hopital.Next());

//                        break;

//                    case 4:
//                        // Logique pour Afficher les visites d'un patient
//                        int idPatient = 0;
//                       Visites v= DaoVisites.SelectByIdPatient(idPatient);
//                        if (v != null)
//                            Console.WriteLine(v.Id + "\t" + v.IdPatient + "\t" + v.Date + "\t" + v.Medecin + "\t" + v.NumSalle + "\t" + v.Tarif);
//                        else
//                            Console.WriteLine("visite  de " + idPatient + "  introuvable");

//                        break;
//                    case 5:
//                        // Logique pour Quitter l'interface secrétaire et revenir au menu principal
//                        Console.WriteLine("Retour au menu principal.");
//                        afficherMenuSecretaire( hopital);
//                        break;

//                    default:
//                        Console.WriteLine("Option invalide. Veuillez choisir à nouveau.");
//                        break;
//                }


//            } while (choixSec != 5);




//        }

//        static void afficherMenuMedecin(Hopital hopital)
//        {
//            int choixSec;
//            do
//            {
//                Console.WriteLine("Menu medecin :");

//                Console.WriteLine("1. Rendre la salle dispo");
//                Console.WriteLine("2. afficher la file d attente");
//                Console.WriteLine("3. afficher la liste des visites");
//                Console.WriteLine("4. Quitter l'interface medecin et revenir au menu principal");

//                Console.Write("Entrez votre choix : ");
//                choixSec = Convert.ToInt32(Console.ReadLine());
//                switch (choixSec)
//                {
//                    case 1:
//                        // Logique pour Rendre la salle dispo



//                        break;

//                    case 2:
//                        // Logique pour  fficher la file d attente
//                        Console.WriteLine("l'etat de la liste d'attente " + " \n" + hopital.CheckQueue());


//                        break;

//                    case 3:
//                        // Logique pour afficher la liste des visites"
//                        List<Visites> visite = DaoVisites.SelectAll();
//                        foreach (Visites v in visite)
//                            Console.WriteLine(v.Id + "\t" + v.IdPatient + "\t" + v.Date + "\t" + v.Medecin + "\t" + v.NumSalle + "\t" + v.Tarif);

//                        break;
//                    case 4:
//                        // Logique pour Quitter l'interface medecin et revenir au menu principal"
//                        Console.WriteLine("Retour au menu principal.");
//                        afficherMenuMedecin(hopital);

//                        break;



//                    default:
//                        Console.WriteLine("Option invalide. Veuillez choisir à nouveau.");
//                        break;
//                }


//            } while (choixSec != 4);




//        }
     

     
       


//    }

//}
