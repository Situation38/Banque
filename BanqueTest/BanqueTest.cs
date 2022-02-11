
using System;
using NUnit.Framework;
using Banque;

namespace BanqueNUnitTests
{

    //class de test
    public class CompteBanqTests
    {
        private CompteBanq Compte;

        [SetUp]
        public void Setup()
        {
            // ARRANGE:On Organise nos donnees
            //Le solde du compte est initialise a 1000
            Compte = new CompteBanq(1000);
        }

        //Test  sur lajout DeDO a un compte
        [Test]
        public void Ajouter_montant_MiseAJourSolde()
        {
            // ACT:On effectue une operation avec les methodes
            //ajout de 500 au solde du compte
            Compte.Ajouter(500);

            // ASSERT:On verifie que les I/O correspondent
            Assert.AreEqual(1500, Compte.Solde);
        }

        //Test Sur lajout DeDo Negatif au solde de compte
        //gestio de lexception
        [Test]
        public void Ajouter_DeDoNegatif_Exception()
        {
            // ACT + ASSERT
            //On verifie que lexception a ete bien gerer
            Assert.Throws<ArgumentOutOfRangeException>(() => Compte.Ajouter(-500));
        }


        //Test sur la methode de retraitDeDo
        [Test]
        public void Retrait_deDo_MiseAJourSolde()
        {
            // ACT:
            Compte.Retrait(500);

            // ASSERT:On verifie que les I/O correspondent
            Assert.AreEqual(500, Compte.Solde);
        }

        //Test Sur le retrait DeDo Negatif au solde de compte
        //gestion de lexception
        [Test]
        public void Retrait_montantNegative_Exception()
        {
            // ACT + ASSERT
            //On verifie que lexception a ete bien gerer
            Assert.Throws<ArgumentOutOfRangeException>(() => Compte.Retrait(-500));
        }

        //Test Sur le retrait DeDo superieur au solde de compte
        //gestion de lexception
        [Test]
        public void Retrait_superieurAuSolde_Exception()
        {
            // ACT + ASSERT
            //On verifie que lexception a ete bien gerer
            Assert.Throws<ArgumentOutOfRangeException>(() => Compte.Retrait(2000));
        }


        //Test sur le transfert DeDO entre deux compte
        [Test]
        public void Transfer_DeDo_entreDeux_Comptes()
        {
            // ARRANGE.On definit les donnees
            var autreCompte = new CompteBanq();

            // ACT:Operation de transfert avec la methode TransferDdo
            Compte.TransferDeDo(autreCompte, 500);

            // ASSERT
            Assert.AreEqual(500, Compte.Solde);
            Assert.AreEqual(500, autreCompte.Solde);
        }

        //Test Sur le transfert DeDo dans uncompte inexistant
        //gestion de lexception
        [Test]
        public void Transfer_DeDo_CompteInexistant_CompteException()
        {
            // ACT + ASSERT
            //On verifie que lexception a ete bien gerer
            Assert.Throws<ArgumentNullException>(() => Compte.TransferDeDo(null, 2000));
        }
    }
}