using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testProjet
{
    class NewsInfo
    {
        public News N;
        string titre;
        string message;
        string etat;
        int activationChance;
        int desactivationChance;
        int extensionChance;
        int type;
        string affect;
        double typeOfAffect;
        string BonusAdviser;
        string extension;
        
        public NewsInfo (News N, string titre, string message, string etat,int activationChance,int desactivationChance,int extensionChance, int type, string affect, double typeOfAffect, string BonusAdviser, string extension)
        {
            this.N = N;
            this.titre = titre;
            this.message = message;
            this.etat = etat;
            this.activationChance = activationChance;
            this.desactivationChance = desactivationChance;
            this.extensionChance = extensionChance;
            this.type = type;
            this.affect = affect;
            this.typeOfAffect = typeOfAffect;
            this.BonusAdviser = BonusAdviser;
            this.extension = extension;
        }

        // Mise à jours des news , try de changement d'état si news indépendante
        public void Update()
        {            
            if (type == 2)
            {
            }
            else
            {
                if( etat == "activé" )
                {
                    tryModifyState(desactivationChance,type);                                   
                }
                else 
                {
                    tryModifyState( activationChance,type ); 
                }
            }
            
        }


        // Try de changement d'état d'une news 
        public void tryModifyState (int chances, int type)
        {
            
            int modify = remonter.user.rand.Next( 1, 100);
            if( modify <= chances)
            {
                if (type == 1)
                {
                    changeState();
                }
                else
                {                    
                }
            }

        }


        //Changement d'état d'une news
        public void changeState()
        {
            if (etat == "désactivé")
            {
                etat = "activé";
                Console.WriteLine( "début de crise {0}", titre );
                Console.WriteLine( "--" );
                Console.WriteLine( "--" );
            }
            else 
            {
                if( extension != "none" )
                {
                    activateExtension( extension );
                }
                etat = "désactivé";
                Console.WriteLine( "fin de crise {0}", titre );
                Console.WriteLine( "--" );
                Console.WriteLine( "--" );
            }
        }

       //Activation d'une extension
       public void activateExtension(string extension)
        {
            N.activateExtension( extension );
        }

        //Regarde l'état de la news, son domain et son effet, puis le return
        public Tuple<string, double> Check ()
       {
            if (etat == "activé")
            {
                return Tuple.Create( affect, typeOfAffect );
            }
            else
            {
                return Tuple.Create( "none", 0.0 );
            }
       }

        
       public News remonter
       {
           get { return N; }
       }

    }
}
