using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    class Action
    {
        user u;
        Dictionary<string,ActionsInfo> A = new Dictionary<string, ActionsInfo>();

        //Création des actions et ajout dans le dictionary
        public Action(user u)
        {
            this.u = u;
            ActionsInfo Ford = new ActionsInfo( this, "Ford",1.00, 1.01, "Voiture" );
            ActionsInfo Total = new ActionsInfo( this, "Total", 1.17, 1.02, "Pétrole" );
            ActionsInfo Ubisoft = new ActionsInfo( this, "Ubisoft", 1.34, 0.99, "Informatique" );

            A.Add( "Ford", Ford );
            A.Add( "Total", Total );
            A.Add( "Ubisoft", Ubisoft );

            

        }

        //Mise à jours des actions
        public void UpdateActions()
        {  
            foreach (var pair in A)
            {
                pair.Value.Update();               
            
            }
        }

        public user user
        {
            get { return u; }
        }


        //Modifie la valeur de monté des actions concernées par une news
        internal void ModifyRyse( Tuple<string, double> result )
        {
            foreach( var pair in A )
            {
                pair.Value.ModifyRyse(result);
            }
        }
    }
       
}

