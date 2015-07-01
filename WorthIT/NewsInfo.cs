using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testProjet
{
    [Serializable]
    public class NewsInfo
    {
        public News N;
        public string title;
        string message;
        string state;
        int activationChance;
        int desactivationChance;
        int extensionChance;
        int type;
        public string affect;
        public double typeOfAffect;
        public string BonusAdviser;
        string extension;
        
        public NewsInfo (News N, string title, string message, string state,int activationChance,int desactivationChance,int extensionChance, int type, string affect, double typeOfAffect, string BonusAdviser, string extension)
        {
            this.N = N;
            this.title = title;
            this.message = message;
            this.state = state;
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
                if( state == "activé" )
                {
                    tryModifyState(desactivationChance,type);
                    N.stopNewsAction(title, affect);               
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
            
            int modify = up.user.rand.Next( 1, 100);
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
            if (state == "désactivé")
            {
                state = "activé";

            }
            else 
            {
                if( extension != "none" )
                {
                    activateExtension( extension );
                }
                state = "désactivé";

            }
        }

       //Activation d'une extension
       public void activateExtension(string extension)
        {
           
        }

        //Regarde l'état de la news, son domain et son effet, puis le return
        public Tuple<string, double, string> Check ()
       {
            if (state == "activé")
            {
                return Tuple.Create( affect, typeOfAffect, title );
            }
            else
            {
                return Tuple.Create( "none", 0.0,"" );
            }
       }

        
       public News up
       {
           get { return N; }
       }


       internal Tuple<string , string> GetActivateNews()
       {
           if( state == "activé" )
           {
               return Tuple.Create(title, message);
           }
           else
           {
               return Tuple.Create(title, "désactivé");
           }
       }
    }
}
