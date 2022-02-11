using System;

namespace Banque
{
  
    // Compte Banquaire
  
    public class CompteBanq
    {
        private double solde;


            //Constructeur sans initialisation du solde
        public CompteBanq()
        {
        }


        //Constructeur avc initialisation du solde
        public CompteBanq(double solde)
        {
            this.solde = solde;
        }

        //getter pour acceder  a la variable privee Solde
        public double Solde
        {
            get { return solde; }
        }

        //Methode dajout dun montant au compte bancaire
        public void Ajouter(double montant)
        {
            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant));
            }

            solde += montant;
            Console.WriteLine($"Ajout de {montant} dans votre compte effectué.");
        }

        //Methode de retrait de largent dans le compte
        public void Retrait(double montant)
        {
            if (montant > solde)
            {
                throw new ArgumentOutOfRangeException(nameof(montant));
            }

            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant));
            }

            solde -= montant;
            Console.WriteLine($"Retrait de {montant} dans votre compte effectué.");
        }

        //Methode de transfert dargent vers un autre compte
        public void TransferDeDo(CompteBanq autreCompt, double montant)
        {
            if (autreCompt is null)
            {
                throw new ArgumentNullException(nameof(autreCompt));
            }

            Retrait(montant);
            autreCompt.Ajouter(montant);
            Console.WriteLine($"Transfert de {montant} vers autre compte effectué.");
        }

            //Affiche de la methode
        public void AfficheInfosCompte(CompteBanq unCompt)
        {
           
            if (unCompt is null)
            {
                throw new ArgumentNullException(nameof(unCompt));
            }
            Console.WriteLine($"Montant Solde du compte: {Solde}");
            
            
            
        }



        public static void Main( String[ ] arg)
        {
            
            Console.WriteLine($"Bienvenue dans votre espace!");
            Console.WriteLine();
            CompteBanq c1 = new CompteBanq(5000);
            CompteBanq c2 = new CompteBanq(3000);
            c1.AfficheInfosCompte(c1);

            c1.Ajouter(700);
            c1.AfficheInfosCompte(c1);
            Console.WriteLine("");

            c1.Retrait(1000);
            c1.AfficheInfosCompte(c1);
            Console.WriteLine("");


            c1.TransferDeDo(c2, 2350);
            c1.AfficheInfosCompte(c1);
            Console.WriteLine("");



            Console.WriteLine($"Infos solde compte2:"); 
            c2.AfficheInfosCompte(c2);





        }




    }
}
