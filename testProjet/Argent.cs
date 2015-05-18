using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    class Argent
    {
        user u;
        int argent;
        int salaire;
        string employeur;
        public Argent(user u)
        {
           this.u = u;
           argent = 500;
           salaire = 250;
           employeur = "monPremierEmplois";
        }

        public void updateArgent ()
        {
            argent = argent + salaire;

            Console.WriteLine( "Vous disposez de {0} euros", argent );
            Console.WriteLine( "--" );
            Console.WriteLine( "--" );
        }

        public int GetArgent()
        {
            return argent;
        }

        internal void UpdateApresAchat( int prix )
        {
            argent = argent - prix;

            Console.WriteLine( "Il vous reste {0} euros!" , argent);
            Console.WriteLine( "--" );

        }
    }
}
