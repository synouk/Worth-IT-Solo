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



        // Mise à jours des valeurs d'actions 
        public void Update()
        {
            if (value >= 3)
            {
                if (value >= remonter.user.rand.Next(1,5))
                {
                    if( ryse >= 1 )
                    {
                        ryse = Arrondir( ryse *remonter.user.GetRandomNumber( 0.7, 0.9 ) );
                    }
                    
                } 
            }
            if (value <= 0.33)
            {
                if( value*10 <= remonter.user.rand.Next( 1, 5 ) )
                {
                    if( ryse <= 1 )
                    {
                        ryse = Arrondir( ryse / remonter.user.GetRandomNumber( 0.7, 0.9 ) );
                    }
                    
                }
                
            }
            LimiterMouvement();
            int modify = remonter.user.rand.Next( 1, 100 );
            if( modify < 99 )
            {               

                value = Arrondir(value * ryse);
            }
            else
            {
                ryse = Arrondir (ryse * remonter.user.rand.Next( 48, 52 ) / 50);
                value = Arrondir (value * ryse);
                Console.WriteLine( "une imprévu est survenu : {0}", nom );
            }

            
                
            Console.WriteLine( "l'action {0} vaut  {1} avec une montée  de {2}", nom, value, ryse  );
            Console.WriteLine( "--" );
            Console.WriteLine( "--" );
          
        }


        public Action remonter
        {
            get { return a; }
        }


        // Mise à jours de la montée des actions concernées par une news
        internal void ModifyRyse( Tuple<string, double> result )
        {
            if (result.Item1 == type)
            {

                ryse = Arrondir (ryse * result.Item2);
            }            
            
        }

        // Arrondit un double à 3 chiffre après la virgule
        internal double Arrondir (double NombreAMofidier)
        {
            return Math.Round( NombreAMofidier, 3, MidpointRounding.AwayFromZero );
        }

        //Limite le mouvement des actions , pour éviter les trop gros écarts de chiffre 
        internal void LimiterMouvement ()
        {
            if( value < 0.4 )
            {
                value = 0.4;
                ryse = 1;
            }
            if( value > 5 )
            {
                value = 5;
                ryse = 1;
            }
            if( ryse < 0.5 )
            {
                ryse = 0.5;
            }
            if( ryse > 2 )
            {
                ryse = 2;
            }
        }
    }
}
