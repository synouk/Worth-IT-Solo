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
        string typeOfAffect;
        string BonusAdviser;
        string extension;
        
        public NewsInfo (News N, string titre, string message, string etat,int activationChance,int desactivationChance,int extensionChance, int type, string affect, string typeOfAffect, string BonusAdviser, string extension)
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
            Console.WriteLine( titre );
            Console.WriteLine( etat );
            
        }



        public void tryModifyState (int chances, int type)
        {
            
            int modify = remonter.user.rand.Next( 1, 10);
            if( modify >= chances)
            {
                if (type == 1)
                {
                    changeState();
                }
                else
                {
                    changeState();
                    activateExtension(extension);
                }
            }

        }



        public void changeState()
        {
            if (etat == "désactivé")
            {
                etat = "activé";
            }
            else {
                etat = "désactivé";
            }
        }

       public void activateExtension(string extension)
        {
            N.activateExtension( extension );
        }

        public Tuple<string, string> Check ()
       {
            if (etat == "activé")
            {
                return Tuple.Create( affect, typeOfAffect );
            }
            else
            {
                return Tuple.Create( "none", "none" );
            }
       }


       public News remonter
       {
           get { return N; }
       }

    }
}
