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

        public Action(user u)
        {
            this.u = u;
            ActionsInfo Ford = new ActionsInfo( this, "Ford",1.00, 1.01, "Voiture" );
//            ActionsInfo Nissan = new ActionsInfo( this, "Nissan", 1.64, 0.97, "Voiture" );
//            ActionsInfo Total = new ActionsInfo( this, "Total", 2.17, 1.02, "Pétrole" );
//            ActionsInfo Apple = new ActionsInfo( this, "Apple", 1.59, 0.97, "Info" );
//            ActionsInfo Microsoft = new ActionsInfo( this, "Microsoft", 1.37, 1.02, "Info" );
//            ActionsInfo Ubisoft = new ActionsInfo( this, "Ubisoft", 1.34, 1.03, "Informatique" );
//            ActionsInfo BNP = new ActionsInfo( this, "BNP", 1.14, 1.09, "Banque" );
//            ActionsInfo Françe = new ActionsInfo( this, "Françe", 1.01, 0.97, "Pays" );
//            ActionsInfo Axe = new ActionsInfo( this, "Axe", 1.15, 1.04, "Perso" );

            A.Add( "Ford", Ford );
 //           A.Add( "Nissan", Nissan );
//            A.Add( "Total", Total );
//            A.Add( "Apple", Apple );
//            A.Add( "Microsoft", Microsoft );
//            A.Add( "Ubisoft", Ubisoft );
//            A.Add( "BNP", BNP );
//            A.Add( "Françe", Françe );
//            A.Add( "Axe", Axe );
            

        }

        public void UpdateActions()
        {  
            foreach (var pair in A)
            {
                pair.Value.Update();               
            
            }
        }

        public void UpdateRyse()
        {
            foreach (var pair in A)
            {
                pair.Value.UpdateRyse();
            }
        }
        public user user
        {
            get { return u; }
        }



        internal void ModifyRyse( Tuple<string, string> result )
        {
            foreach( var pair in A )
            {
                pair.Value.ModifyRyse(result);
            }
        }
    }
       
}

