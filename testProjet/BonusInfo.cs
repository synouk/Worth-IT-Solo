using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    class BonusInfo
    {
        Bonus B;
        string nom;
        string etat;
        int prix;

        public BonusInfo(Bonus B , string nom, string etat, int prix )
        {
            this.B = B;
            this.nom = nom;
            this.etat = etat;
            this.prix = prix;
        }

        internal void Achat( int argent, Argent Ar )
        {
            if (argent >= prix )
            {
                etat = "activé";
                remonter.user.AchatBonus( prix , Ar);

                Console.WriteLine( "Le bonus {0} a été acheté", nom );
            }
            else
            {
                Console.WriteLine ("Vous n'avez que {0} euros, un {1} coute {2}!",argent, nom, prix);
                Console.WriteLine( "--" );
            }
        }

        public Bonus remonter
        {
            get { return B; }
        }
    }
}
