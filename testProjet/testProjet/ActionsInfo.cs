using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testProjet
{
    class ActionsInfo 
    {
        Action a;
        double value;
        double ryse;
        string type;
        string nom;
        
        public ActionsInfo(Action a, string nom, double value, double ryse, string type)
        {
            this.a = a;
            this.nom = nom;
            this.value = value;
            this.ryse = ryse;
            this.type = type;
        }
        public void Update()
        {
            int modify = remonter.user.rand.Next( 1, 100 );
            if( modify < 99 )
            {
                value = value * ryse;
                Console.WriteLine( "Un tour est passé , l'action vaut maintenant {0}", value );
            }
            else
            {
                ryse = ryse * remonter.user.rand.Next( 4, 6 ) / 5;
                value = value * ryse;
            }
            Console.WriteLine( nom );
            Console.WriteLine( ryse );
            Console.WriteLine( value );
        }

        public void UpdateRyse()
        {

        }


        public Action remonter
        {
            get { return a; }
        }


        internal void ModifyRyse( Tuple<string, string> result )
        {
            if (result.Item1 == type)
            {
                Console.WriteLine ("Une news activé est en train de prendre effet");
                if (result.Item2 == "négatif")
                {
                    ryse = ryse * 0.80;
                }
                else
                {
                    ryse = ryse * 1.20;
                }
                Console.WriteLine( ryse );
            }
        }
    }
}
